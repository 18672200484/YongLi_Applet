using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using InfluxData.Net.InfluxDb.Models;
using System;
using System.Collections.Generic;

namespace CMCS.Common.Utilities.InfluxDBs
{
    public class InfluxDBSdkHelper
    {
        private InfluxDbClient _client;
        /// <summary>
        /// 操作状态回调
        /// </summary>
        /// <param name="status"></param>
        public delegate void StatusCallBack(bool status);

        /// <summary>
        /// 操作结果回调
        /// </summary>
        /// <param name="json"></param>
        public delegate void ResultCallBack(string json);

        public InfluxDBSdkHelper(string infuxUrl, string infuxUser, string infuxPwd)
        {
            _client = new InfluxDbClient(infuxUrl, infuxUser, infuxPwd, InfluxDbVersion.Latest);
        }
        /// <summary>
        /// 往InfluxDB中写入数据
        /// </summary>
        public async void Write(string dbName, Point point)
        {
            //基于InfluxData.Net.InfluxDb.Models.Point实体准备数据
            var point_model = new Point()
            {
                Name = "Reading",//表名
                Tags = new Dictionary<string, object>(){{ "Id", 158}},
                Fields = new Dictionary<string, object>(){{ "Val", "webInfo" }},
                Timestamp = DateTime.UtcNow
            };
            //从指定库中写入数据，支持传入多个对象的集合
            var response = await _client.Client.WriteAsync(point, dbName);
            //StatusCallBack?.Invoke(response.Success);
        }
    }
}
