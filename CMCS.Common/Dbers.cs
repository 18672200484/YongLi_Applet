using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CMCS.DapperDber.Dbs.AccessDb;
// 
using CMCS.DapperDber.Dbs.OracleDb;
using CMCS.DapperDber.Dbs.SqlServerDb;
using CMCS.Common.DapperDber_etc;
using CMCS.DapperDber.Dbs.MySqlDb;

namespace CMCS.Common
{
	/// <summary>
	/// 数据库访问
	/// </summary>
	public class Dbers
	{
		private static Dbers instance;

		public static Dbers GetInstance()
		{
			if (instance == null)
			{
				instance = new Dbers();
			}

			return instance;
		}

		private Dbers()
		{
			CommonAppConfig appConfig = CommonAppConfig.GetInstance();

			SelfDber = new OracleDapperDber_iEAA(appConfig.SelfConnStr);
			SelfDber.SqlWatch += new DapperDber.Dbs.BaseDber.SqlWatchEventHandler(FuelMisDber_SqlWatch);

			MySqlDber = new MySqlDapperDber(appConfig.MySqlConnStr);
			MySqlDber.SqlWatch += new DapperDber.Dbs.BaseDber.SqlWatchEventHandler(FuelMisDber_SqlWatch);

			DoorSqlDber = new AccessDapperDber(appConfig.DoorSqlConnStr);
			DoorSqlDber.SqlWatch += new DapperDber.Dbs.BaseDber.SqlWatchEventHandler(FuelMisDber_SqlWatch);

		}

		void FuelMisDber_SqlWatch(string type, string sql)
		{
			//BasisPlatform.Util.Log4netUtil.Info(sql);
		}

		/// <summary>
		/// 燃料集中管控 Oracle 访问
		/// </summary>
		public OracleDapperDber_iEAA SelfDber;

		/// <summary>
		/// 人脸识别 MySql 访问
		/// </summary>
		public MySqlDapperDber MySqlDber;

		/// <summary>
		/// 门禁 Access 访问
		/// </summary>
		public AccessDapperDber DoorSqlDber;
	}
}
