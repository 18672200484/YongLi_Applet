using CMCS.Common.Dao;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.Common.Utilities.InfluxDBs;
using CMCS.Common.Utilities.RedisLib;
using CMCS.DumblyConcealer.Tasks.ToxicGas.Entities;
using InfluxData.Net.InfluxDb.Models;
using Modbus.Device;
using Modbus.Utility;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.ToxicGas
{
    public class ToxicGasDao
    {
        CommonDAO commonDAO = CommonDAO.GetInstance();
        public int SyncData(Action<string, eOutputType> output)
        {
            List<ToxicGasResult> listRestlt = new List<ToxicGasResult>();
            int addRes = 0;
            try
            {
                #region 获取数据
                //压缩机房
                using (SerialPort port = new SerialPort(commonDAO.appConfig.ysjfCom))
                {
                    port.BaudRate = 9600;//波特率
                    port.DataBits = 8;//数据位
                    port.Parity = Parity.None;//校验位
                    port.StopBits = StopBits.One;//停止位
                    port.Open();
                    // create modbus master
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(port);
                    //很重要是设备的id，一般默认是1
                    byte slaveId = Convert.ToByte(commonDAO.appConfig.ysjfDeviceId);
                    //表示从哪开始读
                    ushort startAddress = 0000;
                    //表示读60个寄存器对应30个探测器最多一次读30个探测器
                    ushort numofPoints = 60;

                    //读取寄存器数据到register数组中
                    ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numofPoints);
                    if (registers.Length > 0)
                    {
                        List<ToxicGasResult> outResult = new List<ToxicGasResult>();
                        AddResultToList(registers, commonDAO.appConfig.ysjfDetectorsNum, "压缩机房",out outResult);
                        listRestlt=listRestlt.Union(outResult).ToList();
                    }
                }

                //甲类异丁烯罐区
                using (SerialPort port = new SerialPort(commonDAO.appConfig.jlydxCom))
                {
                    port.BaudRate = 9600;//波特率
                    port.DataBits = 8;//数据位
                    port.Parity = Parity.None;//校验位
                    port.StopBits = StopBits.One;//停止位
                    port.Open();
                    // create modbus master
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(port);
                    //很重要是设备的id，一般默认是1
                    byte slaveId = Convert.ToByte(commonDAO.appConfig.jlydxDeviceId);
                    //表示从哪开始读
                    ushort startAddress = 0000;
                    //表示读60个寄存器对应30个探测器最多一次读30个探测器
                    ushort numofPoints = 60;

                    //读取寄存器数据到register数组中
                    ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numofPoints);
                    if (registers.Length > 0)
                    {
                        List<ToxicGasResult> outResult = new List<ToxicGasResult>();
                        AddResultToList(registers, commonDAO.appConfig.jlydxDetectorsNum, "甲类异丁烯罐区", out outResult);
                        listRestlt = listRestlt.Union(outResult).ToList();
                    }
                }

                //抗一车间
                using (SerialPort port = new SerialPort(commonDAO.appConfig.kycjCom))
                {

                    port.BaudRate = 9600;//波特率
                    port.DataBits = 8;//数据位
                    port.Parity = Parity.None;//校验位
                    port.StopBits = StopBits.One;//停止位
                    port.Open();
                    // create modbus master
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(port);
                    //很重要是设备的id，一般默认是1
                    byte slaveId = Convert.ToByte(commonDAO.appConfig.kycjDeviceId);
                    //表示从哪开始读
                    ushort startAddress = 0000;
                    //表示读60个寄存器对应30个探测器最多一次读30个探测器
                    ushort numofPoints = 60;

                    //读取寄存器数据到register数组中
                    ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numofPoints);
                    if (registers.Length > 0)
                    {
                        List<ToxicGasResult> outResult = new List<ToxicGasResult>();
                        AddResultToList(registers, commonDAO.appConfig.kycjDetectorsNum, "抗一车间", out outResult);
                        listRestlt.Union(outResult);
                        listRestlt = listRestlt.Union(outResult).ToList();
                    }

                }

                //抗二车间
                using (SerialPort port = new SerialPort(commonDAO.appConfig.kecjCom))
                {

                    port.BaudRate = 9600;//波特率
                    port.DataBits = 8;//数据位
                    port.Parity = Parity.None;//校验位
                    port.StopBits = StopBits.One;//停止位
                    port.Open();
                    // create modbus master
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(port);
                    //很重要是设备的id，一般默认是1
                    byte slaveId = Convert.ToByte(commonDAO.appConfig.kecjDeviceId);
                    //表示从哪开始读
                    ushort startAddress = 0000;
                    //表示读60个寄存器对应30个探测器最多一次读30个探测器
                    ushort numofPoints = 60;

                    //读取寄存器数据到register数组中
                    ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numofPoints);
                    if (registers.Length > 0)
                    {
                        List<ToxicGasResult> outResult = new List<ToxicGasResult>();
                        AddResultToList(registers, commonDAO.appConfig.kecjDetectorsNum, "抗二车间", out outResult);
                        listRestlt = listRestlt.Union(outResult).ToList();
                    }

                }

                //烷化车间
                using (SerialPort port = new SerialPort(commonDAO.appConfig.whcjCom))
                {

                    port.BaudRate = 9600;//波特率
                    port.DataBits = 8;//数据位
                    port.Parity = Parity.None;//校验位
                    port.StopBits = StopBits.One;//停止位
                    port.Open();
                    // create modbus master
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(port);
                    //很重要是设备的id，一般默认是1
                    byte slaveId = Convert.ToByte(commonDAO.appConfig.whcjDeviceId);
                    //表示从哪开始读
                    ushort startAddress = 0000;
                    //表示读60个寄存器对应30个探测器最多一次读30个探测器
                    ushort numofPoints = 60;

                    //读取寄存器数据到register数组中
                    ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numofPoints);
                    if (registers.Length > 0)
                    {
                        List<ToxicGasResult> outResult = new List<ToxicGasResult>();
                        AddResultToList(registers, commonDAO.appConfig.whcjDetectorsNum, "烷化车间", out outResult);
                        listRestlt = listRestlt.Union(outResult).ToList();
                    }

                }

                //能源车间
                using (SerialPort port = new SerialPort(commonDAO.appConfig.nycjCom))
                {

                    port.BaudRate = 9600;//波特率
                    port.DataBits = 8;//数据位
                    port.Parity = Parity.None;//校验位
                    port.StopBits = StopBits.One;//停止位
                    port.Open();
                    // create modbus master
                    IModbusMaster master = ModbusSerialMaster.CreateRtu(port);
                    //很重要是设备的id，一般默认是1
                    byte slaveId = Convert.ToByte(commonDAO.appConfig.nycjDeviceId);
                    //表示从哪开始读
                    ushort startAddress = 0000;
                    //表示读60个寄存器对应30个探测器最多一次读30个探测器
                    ushort numofPoints = 60;

                    //读取寄存器数据到register数组中
                    ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numofPoints);
                    if (registers.Length > 0)
                    {
                        List<ToxicGasResult> outResult = new List<ToxicGasResult>();
                        AddResultToList(registers, commonDAO.appConfig.nycjDetectorsNum, "能源车间", out outResult);
                        listRestlt = listRestlt.Union(outResult).ToList();
                    }
                }
                #endregion
                #region 数据存储
                RedisHelper redis = new RedisHelper(commonDAO.appConfig.DefaultRedisDatabase);
                //InfluxDB
                InfluxDBSdkHelper client = new InfluxDBSdkHelper(commonDAO.appConfig.InfluxDbUrlAndPort, commonDAO.appConfig.InfluxDbUser, commonDAO.appConfig.InfluxDbPwd);
                var valDictionary = new Dictionary<string, object>();
                DateTimeOffset dtOff = DateTimeOffset.UtcNow;
                foreach (var item in listRestlt)
                {
                    redis.HashSet(item.Name, "name", item.Name);
                    redis.HashSet(item.Name, "description", item.Description);
                    redis.HashSet(item.Name, "lastUpdateTime", dtOff.ToLocalTime());
                    redis.HashSet(item.Name, "Value", item.Value);

                    var point_model = new Point()
                    {
                        Name = commonDAO.appConfig.InfluxDbToxicGasTableName,//表名
                        Tags = new Dictionary<string, object>() { { "name", item.Name } },
                        Fields = new Dictionary<string, object>() { { "description", item.Description }, { "lastUpdateTime", DateTime.Now}, { "Value", item.Value } },
                    };
                    client.Write(commonDAO.appConfig.InfluxDbName, point_model);
                }
               
                #endregion 

                output(string.Format("同步数量：{0}", listRestlt.Count), eOutputType.Normal);
            }
            catch (Exception ex)
            {
                output(string.Format("有毒有害气体同步异常：{0}", listRestlt.Count), eOutputType.Error);
            }
            return addRes;
        }
        /// <summary>
        /// 添加结果
        /// </summary>
        /// <param name="registers">寄存器数据</param>
        /// <param name="sum">探测器数量</param>
        /// <param name="name">哪个车间</param>
        public void AddResultToList(ushort[] registers, int sum, string name,out List<ToxicGasResult> listData)
        {
            listData = new List<ToxicGasResult>();
            int count = 1;
            int length = sum * 2;
            //每一个探测器需要2个寄存器，第一个寄存器为状态，第二个寄存器为值
            for (int i = 0; i <= length-1; i++)
            {
                switch (Convert.ToInt32(registers[i]))
                {
                   
                    case (int)EToxicGasType.有毒探测器正常:
                        i = i + 1;
                        //ppm单位需要除于10
                        var value1 = Convert.ToInt32(registers[i]) / 10;
                        listData.Add(new ToxicGasResult
                        {
                            Name = "" + name + "有毒探测器"+ count,
                            Description = "" + name + "有毒探测器正常,单位ppm",
                            lastUpdateTime = DateTime.UtcNow,
                            Value = value1
                        });
                        break;
                    case (int)EToxicGasType.有毒探测器故障:
                        i = i + 1;
                        var value2 = Convert.ToInt32(registers[i]) / 10;
                        listData.Add(new ToxicGasResult
                        {
                            Name = "" + name + "有毒探测器" + count,
                            Description = "" + name + "有毒探测器故障,单位ppm",
                            lastUpdateTime = DateTime.UtcNow,
                            Value = value2
                        });
                        break;
                    case (int)EToxicGasType.有毒探测器报警:
                        i = i + 1;
                        var value3 = Convert.ToInt32(registers[i]) / 10;
                        listData.Add(new ToxicGasResult
                        {
                            Name = "" + name + "有毒探测器" + count,
                            Description = "" + name + "有毒探测器报警,单位ppm",
                            lastUpdateTime = DateTime.UtcNow,
                            Value = value3
                        });

                        break;
                    case (int)EToxicGasType.可燃探测器正常:
                        i = i + 1;
                        var value4 = Convert.ToInt32(registers[i]);
                        listData.Add(new ToxicGasResult
                        {
                            Name = "" + name + "可燃探测器" + count,
                            Description = "" + name + "可燃探测器正常,单位lel(%)",
                            lastUpdateTime = DateTime.UtcNow,
                            Value = value4
                        });

                        break;
                    case (int)EToxicGasType.可燃探测器故障:
                        i = i + 1;
                        var value5 = Convert.ToInt32(registers[i]);
                        listData.Add(new ToxicGasResult
                        {
                            Name = "" + name + "可燃探测器" + count,
                            Description = "" + name + "可燃探测器故障,单位lel(%)",
                            lastUpdateTime = DateTime.UtcNow,
                            Value = value5
                        });

                        break;
                    case (int)EToxicGasType.可燃探测器报警:
                        i = i + 1;
                        var value6 = Convert.ToInt32(registers[i]);
                        listData.Add(new ToxicGasResult
                        {
                            Name = "" + name + "可燃探测器" + count,
                            Description = "" + name + "可燃探测器报警,单位lel(%)",
                            lastUpdateTime = DateTime.UtcNow,
                            Value = value6
                        });

                        break;
                    case (int)EToxicGasType.氧气探测器正常:
                        i = i + 1;
                        var value7 = Convert.ToInt32(registers[i]) / 10;
                        listData.Add(new ToxicGasResult
                        {
                            Name = "" + name + "氧气探测器" + count,
                            Description = "" + name + "氧气探测器正常,单位ppm",
                            lastUpdateTime = DateTime.UtcNow,
                            Value = value7
                        });

                        break;
                    case (int)EToxicGasType.氧气探测器故障:
                        i = i + 1;
                        var value8 = Convert.ToInt32(registers[i]) / 10;
                        listData.Add(new ToxicGasResult
                        {
                            Name = "" + name + "氧气探测器" + count,
                            Description = "" + name + "氧气探测器故障,单位ppm",
                            lastUpdateTime = DateTime.UtcNow,
                            Value = value8
                        });
                        break;
                    default: i = i + 1;

                        break;
                }
                count++;
            }
        }
    }
}
