using CMCS.Common.Dao;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.ToxicGas
{
    public class ToxicGasDao1
    {
        static CommonDAO commonDAO = CommonDAO.GetInstance();
        SerialPort portYsjf = new SerialPort(commonDAO.appConfig.ysjfCom);

        public int SyncData(Action<string, eOutputType> output)
        {
            int addRes = 0;

            //压缩机房
            portYsjf.BaudRate = 9600;//波特率
            portYsjf.DataBits = 8;//数据位
            portYsjf.Parity = Parity.None;//校验位
            portYsjf.StopBits = StopBits.One;//停止位
            portYsjf.Open();
            portYsjf.DataReceived += new SerialDataReceivedEventHandler(serialportYsjf_DataReceived);
            //设备地址、功能码、寄存器起始地址、寄存器结束地址
            byte[] toHexByte = ModbusHelper.strToToHexByte("01" + "03" + "0000" + "000D");
            byte[] buffer = ModbusHelper.addCrcHexByte(toHexByte);
            portYsjf.Write(buffer, 0, buffer.Length);

            //发送的内容
            string str = string.Empty;
            for (int index = 0; index < buffer.Length; ++index)
                str = (int)buffer[index] >= 16 ? str + Convert.ToString(buffer[index], 16) + " " : str + "0" + Convert.ToString(buffer[index], 16) + " ";



            output(string.Format("同步数量：{0}", 1), eOutputType.Normal);
            return addRes;
        }
        /// <summary>
        /// //压缩机房返回数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialportYsjf_DataReceived(object sender, EventArgs e)
        {
            int bytesToRead = this.portYsjf.BytesToRead;

            if (bytesToRead == 0)
                return;

            //TBRCV.Text = "";
            bool flag = true;

            while (flag)
            {
                Thread.Sleep(50);

                if (this.portYsjf.BytesToRead == bytesToRead)
                    flag = false;
                else
                    bytesToRead = this.portYsjf.BytesToRead;
            }

            byte[] numArray1 = new byte[bytesToRead];
            this.portYsjf.Read(numArray1, 0, bytesToRead);
            byte[] numArray2 = ModbusHelper.callcrc(numArray1, bytesToRead - 2);
            string str = string.Empty;

            for (int index = 0; index < numArray1.Length; ++index)
                str = (int)numArray1[index] >= 16 ? str + Convert.ToString(numArray1[index], 16) + " " : str + "0" + Convert.ToString(numArray1[index], 16) + " ";

            if ((int)numArray2[0] == (int)numArray1[bytesToRead - 2] &&
                    (int)numArray2[1] == (int)numArray1[bytesToRead - 1])
            {
                //TBRCV.BeginInvoke(new MyInitDelegate(DelegateInitMethod), new object[] { TBRCV, str.ToUpper() });
            }
            else
            {
                //this.TBRCV.Text = str.ToUpper() + "接收错误  CRC有误";
            }
        }
    }
}
