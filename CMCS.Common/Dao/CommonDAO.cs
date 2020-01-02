using Aspose.Cells;
using CMCS.Common.Entities.LocationToken;
using CMCS.Common.Entities.OpcServerSync;
using CMCS.Common.Entities.UserSync;
using CMCS.DapperDber.Dbs.MySqlDb;
using CMCS.DapperDber.Dbs.OracleDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Dao
{
    public class CommonDAO
    {
        private static CommonDAO instance;
        public static CommonDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new CommonDAO();
            }

            return instance;
        }

        private CommonDAO()
        { }
        public OracleDapperDber SelfDber
        {
            get { return Dbers.GetInstance().SelfDber; }
        }
        public MySqlDapperDber MySqlDber
        {
            get { return Dbers.GetInstance().MySqlDber; }
        }
        public CommonAppConfig appConfig
        {
            get { return CommonAppConfig.GetInstance();}
        }
		
        /// <summary>
        /// 查询所有人员
        /// </summary>
        /// <returns></returns>
        public List<JiyiSyncAllUser> GetJiyiAllUser()
        {
            var jiyiSyncAllUser = SelfDber.Entities<JiyiSyncAllUser>();
            return jiyiSyncAllUser;
        }

        /// <summary>
        /// 读取点表配置
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<PointsEntity> GetPointsEntityList(string path)
        {
            List<PointsEntity> listResult = new List<PointsEntity>();
            Aspose.Cells.TxtLoadOptions lo = new TxtLoadOptions();
            lo.Encoding = Encoding.Default;//设置编码方式
            Workbook workbook = new Workbook(path, lo);
            //配置读取文件的类型（CSV）
            workbook.FileFormat = FileFormatType.CSV;//可在此配置Excel文件类型
            Worksheet worksheet = workbook.Worksheets[0];//默认第一个Sheet页
            Cells cells = worksheet.Cells;
            object[,] obj = cells.ExportArray(1, 0, cells.MaxDataRow, 2);
            PointsEntity model;

            object[] objTemp = new object[obj.GetLength(0)];

            for (int i = 0; i < objTemp.Length; i++)
            {
                model = new PointsEntity();
                model.Name = obj[i, 0].ToString();
                model.Description= obj[i, 1].ToString();
                listResult.Add(model);
            }

            //释放资源         
            workbook = null;
            worksheet = null;
            return listResult;
        }
    }
}
