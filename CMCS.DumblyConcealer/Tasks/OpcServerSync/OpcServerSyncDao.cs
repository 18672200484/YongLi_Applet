using CMCS.Common.Dao;
using CMCS.Common.Entities.OpcServerSync;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.Common.Utilities.InfluxDBs;
using CMCS.Common.Utilities.MongoDbs;
using CMCS.Common.Utilities.RedisLib;
using CMCS.DumblyConcealer.Tasks.OpcServerSync.Entities;
using InfluxData.Net.InfluxDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.OpcServerSync
{
	public class OpcServerSyncDao
	{
		static CommonDAO commonDAO = CommonDAO.GetInstance();
		//点表路径
		static string pathString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "points.csv");
		//获取点表集合
		List<PointsEntity> pointList = commonDAO.GetPointsEntityList(pathString);
		//是否打印数据
		public static readonly string frmOpcIsPrintData = ConfigurationManager.AppSettings["FrmOpcIsPrintData"] ?? "0";
		public int SyncData(Action<string, eOutputType> output)
		{
			int addRes = 0;
			//获取网闸数据集合
			var listData = new List<BsonDocumentResult>();
			try
			{
				#region 获取网闸数据
				var mongoDbHelper = new MongoDbCsharpHelper(commonDAO.appConfig.MongoDbUrl, commonDAO.appConfig.MongoDbDataBase);
				IMongoCollection<BsonDocument> coll = mongoDbHelper.GetMongoCollection<BsonDocument>("tagRealValueTable");
				//创建约束生成器
				FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
				ProjectionDefinitionBuilder<BsonDocument> builderProjection = Builders<BsonDocument>.Projection;
				//Include 包含某元素    Exclude  不包含某元素
				ProjectionDefinition<BsonDocument> projection = builderProjection.Include("tagname").Include("value").Exclude("_id");
				var result = coll.Find<BsonDocument>(builderFilter.Empty).Project(projection).ToList();

				foreach (var item in result)
				{
					var jsonData = item.AsBsonValue.ToJson();
					var itemBson = JsonConvert.DeserializeObject<BsonDocumentResult>(jsonData);
					listData.Add(itemBson);
				}
				#endregion

				#region 数据存储
				RedisHelper redis = new RedisHelper(commonDAO.appConfig.DefaultRedisDatabase);
				InfluxDBSdkHelper client = new InfluxDBSdkHelper(commonDAO.appConfig.InfluxDbUrlAndPort, commonDAO.appConfig.InfluxDbUser, commonDAO.appConfig.InfluxDbPwd);
				var valDictionary = new Dictionary<string, object>();
				string now = string.Format("{0:s}", UtilDate.ToDate(DateTime.Now));
				double sum = 0;
				foreach (var item in pointList)
				{
					var selectItem = listData.FirstOrDefault(t => !string.IsNullOrEmpty(t.tagname) && t.tagname.ToLower() == item.Name.ToLower());
					if (selectItem != null)
					{
						double.TryParse(selectItem.value, out sum);
					}
					item.Value = sum;

					#region redis数据存储
					redis.HashSet(item.Name, "Name", item.Name);
					redis.HashSet(item.Name, "Description", item.Description);
					redis.HashSet(item.Name, "LastUpdateTime", now);
					redis.HashSet(item.Name, "Value", Math.Round(item.Value, 2));
					#endregion

					#region BossienDbDictionary
					valDictionary.Add("GG:" + item.Name, item.Value);
					#endregion
				}

				#region BossienDb
				var point_model = new Point()
				{
					Name = "GG",
					Tags = new Dictionary<string, object>() { { "TagId", DateTime.Now.ToString("yyyyMMddHHmmss") } },
					Fields = valDictionary
				};
				client.Write(commonDAO.appConfig.InfluxDbName, point_model);
				#endregion

				#endregion

				output(string.Format("同步数据成功，点表数据：{0}，网闸数据：{1}", pointList.Count, listData.Count), eOutputType.Normal);
			}
			catch (Exception ex)
			{
				output(string.Format("同步数据失败，点表数据：{0}，网闸数据：{1} 错误信息：{2}", pointList.Count, listData.Count, ex.Message), eOutputType.Error);
				Log4Neter.Error("同步DCS数据", ex);
			}
			return addRes;
		}
	}
}
