using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CMCS.Common
{
	/// <summary>
	/// 程序配置
	/// </summary>
	public class CommonAppConfig
	{
		private static string ConfigXmlPath = "Common.AppConfig.xml";

		private static CommonAppConfig instance;

		public static CommonAppConfig GetInstance()
		{
			return instance;
		}

		static CommonAppConfig()
		{
			instance = CMCS.Common.Utilities.XOConverter.LoadConfig<CommonAppConfig>(ConfigXmlPath);
		}

		/// <summary>
		/// 保存配置
		/// </summary>
		public void Save()
		{
			CMCS.Common.Utilities.XOConverter.SaveConfig(instance, ConfigXmlPath);
		}

		/// <summary>
		/// 程序唯一标识
		/// </summary>
		[Description("程序唯一标识")]
		public string AppIdentifier { get; set; }

		/// <summary>
		/// 集中管控Oracle数据库连接字符串
		/// </summary>
		[Description("集中管控Oracle数据库连接字符串")]
		public string SelfConnStr { get; set; }

		/// <summary>
		/// 人脸识别MySql数据库连接字符串
		/// </summary>
		[Description("人脸识别MySql数据库连接字符串")]
		public string MySqlConnStr { get; set; }

		/// <summary>
		/// 门禁Access数据库连接字符串
		/// </summary>
		[Description("门禁Access数据库连接字符串")]
		public string DoorSqlConnStr { get; set; }

		#region Redis
		/// <summary>
		/// RedisStr数据库连接字符串
		/// </summary>
		[Description("RedisStr数据库连接字符串")]
		public string RedisStr { get; set; }

		/// <summary>
		/// RedisKey
		/// </summary>
		[Description("RedisKey")]
		public string RedisKey { get; set; }

		/// <summary>
		/// RedisIP
		/// </summary>
		[Description("RedisIP")]
		public string RedisIP { get; set; }

		/// <summary>
		/// DefaultRedisDatabase
		/// </summary>
		[Description("DefaultRedisDatabase")]
		public int DefaultRedisDatabase { get; set; }

		/// <summary>
		/// 人员定位RedisDatabase
		/// </summary>
		[Description("DefaultRedisDatabase")]
		public int UserRedisDatabase { get; set; }

		#endregion

		#region InfluxDB
		/// <summary>
		/// InfluxDbUrlAndPort
		/// </summary>
		[Description("InfluxDbUrlAndPort")]
		public string InfluxDbUrlAndPort { get; set; }

		/// <summary>
		/// InfluxDbUser
		/// </summary>
		[Description("InfluxDbUser")]
		public string InfluxDbUser { get; set; }

		/// <summary>
		/// InfluxDbPwd
		/// </summary>
		[Description("InfluxDbPwd")]
		public string InfluxDbPwd { get; set; }

		/// <summary>
		/// InfluxDbName
		/// </summary>
		[Description("InfluxDbName")]
		public string InfluxDbName { get; set; }

		/// <summary>
		/// 人员定位
		/// </summary>
		[Description("InfluxDbLocationUserTableName")]
		public string InfluxDbLocationUserTableName { get; set; }

		/// <summary>
		/// 可燃有毒气体
		/// </summary>
		[Description("InfluxDbToxicGasTableName")]
		public string InfluxDbToxicGasTableName { get; set; }
		#endregion

		#region MongoDb
		/// <summary>
		/// MongoDbUrl
		/// </summary>
		[Description("MongoDbUrl")]
		public string MongoDbUrl { get; set; }
		/// <summary>
		/// MongoDbDataBase
		/// </summary>
		[Description("MongoDbDataBase")]
		public string MongoDbDataBase { get; set; }
		#endregion

		#region 人员定位系统相关
		/// <summary>
		/// 人员定位接口请求地址(查询所有人员)
		/// </summary>
		[Description("Locationlicence")]
		public string Locationlicence { get; set; }

		/// <summary>
		///人员定位查询报警信息的Url
		/// </summary>
		[Description("SearchEmployeeUrl")]
		public string SearchEmployeeUrl { get; set; }

		/// <summary>
		///人员定位查询区域人员的Url
		/// </summary>
		[Description("SearchAreaUrl")]
		public string SearchAreaUrl { get; set; }

		/// <summary>
		/// 人员定位请求的用户名
		/// </summary>
		[Description("LocationUserName")]
		public string LocationUserName { get; set; }

		/// <summary>
		/// 人员定位请求的密码
		/// </summary>
		[Description("LocationPassWord")]
		public string LocationPassWord { get; set; }

		/// <summary>
		///地图原点经度
		/// </summary>
		[Description("Xcoor")]
		public double Xcoor { get; set; }

		/// <summary>
		///地图原点纬度
		/// </summary>
		[Description("Ycoor")]
		public double Ycoor { get; set; }

		/// <summary>
		///左下角经度
		/// </summary>
		[Description("LeftDownXcoor")]
		public double LeftDownXcoor { get; set; }

		/// <summary>
		///左下角纬度
		/// </summary>
		[Description("LeftDownYcoor")]
		public double LeftDownYcoor { get; set; }

		/// <summary>
		///右上角经度
		/// </summary>
		[Description("RightUpXcoor")]
		public double RightUpXcoor { get; set; }

		/// <summary>
		///右上角纬度
		/// </summary>
		[Description("RightUpYcoor")]
		public double RightUpYcoor { get; set; }

		/// <summary>
		///人员微调减去多少米
		/// </summary>
		[Description("TempLength")]
		public double TempLength { get; set; }
		/// <summary>
		///判断人员Y坐标是否小于这个
		/// </summary>
		[Description("TempLength2")]
		public double TempLength2 { get; set; }

		/// <summary>
		///用于在地图显示人员的高低
		/// </summary>
		[Description("Zcoor")]
		public double Zcoor { get; set; }
		#endregion

		#region 门禁接口
		/// <summary>
		///门禁接口URL
		/// </summary>
		[Description("AccessControlUrl")]
		public string AccessControlUrl { get; set; }

		[Description("AccessControlVoid")]
		public string AccessControlVoid { get; set; }

		/// <summary>
		/// 门禁LED区域人数统计URL
		/// </summary>
		[Description("BuildWebServiceUrl")]
		public string BuildWebServiceUrl { get; set; }
		#endregion

		#region 有毒气体
		/// <summary>
		/// 压缩机房串口
		/// </summary>
		[Description("ysjfCom")]
		public string ysjfCom { get; set; }
		/// <summary>
		/// 压缩机房设备ID
		/// </summary>
		[Description("ysjfDeviceId")]
		public int ysjfDeviceId { get; set; }
		/// <summary>
		/// 压缩机房探测器数量
		/// </summary>
		[Description("ysjfDetectorsNum")]
		public int ysjfDetectorsNum { get; set; }

		/// <summary>
		/// 甲类异丁烯罐区串口
		/// </summary>
		[Description("jlydxCom")]
		public string jlydxCom { get; set; }
		/// <summary>
		/// 甲类异丁烯设备ID
		/// </summary>
		[Description("jlydxDeviceId")]
		public int jlydxDeviceId { get; set; }
		/// <summary>
		/// 甲类异丁烯罐区探测器数量
		/// </summary>
		[Description("jlydxDetectorsNum")]
		public int jlydxDetectorsNum { get; set; }

		/// <summary>
		/// 抗一车间串口
		/// </summary>
		[Description("kycjCom")]
		public string kycjCom { get; set; }
		/// <summary>
		/// 抗一车间设备ID
		/// </summary>
		[Description("kycjDeviceId")]
		public int kycjDeviceId { get; set; }
		/// <summary>
		/// 抗一车间探测器数量
		/// </summary>
		[Description("kycjDetectorsNum")]
		public int kycjDetectorsNum { get; set; }

		/// <summary>
		/// 抗二车间串口
		/// </summary>
		[Description("kecjCom")]
		public string kecjCom { get; set; }
		/// <summary>
		/// 抗二车间设备ID
		/// </summary>
		[Description("kecjDeviceId")]
		public int kecjDeviceId { get; set; }
		/// <summary>
		/// 抗二车间探测器数量
		/// </summary>
		[Description("kecjDetectorsNum")]
		public int kecjDetectorsNum { get; set; }

		/// <summary>
		/// 烷化车间串口
		/// </summary>
		[Description("whcjCom")]
		public string whcjCom { get; set; }
		/// <summary>
		/// 烷化车间设备ID
		/// </summary>
		[Description("whcjDeviceId")]
		public int whcjDeviceId { get; set; }
		/// <summary>
		/// 烷化车间探测器数量
		/// </summary>
		[Description("whcjDetectorsNum")]
		public int whcjDetectorsNum { get; set; }


		/// <summary>
		/// 能源车间串口
		/// </summary>
		[Description("nycjCom")]
		public string nycjCom { get; set; }
		/// <summary>
		/// 能源车间设备ID
		/// </summary>
		[Description("nycjDeviceId")]
		public int nycjDeviceId { get; set; }
		/// <summary>
		/// 能源车间探测器数量
		/// </summary>
		[Description("nycjDetectorsNum")]
		public int nycjDetectorsNum { get; set; }
		#endregion
	}
}
