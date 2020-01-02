using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Utilities
{
   public static class ModbusHelper
    {
        /// <summary>
        /// 把字符串转byte数组
        /// </summary>
        /// <param name="hexString">需要发送的数据</param>
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");

            if (hexString.Length % 2 != 0)
                hexString += "0";

            byte[] numArray = new byte[hexString.Length / 2];

            for (int index = 0; index < numArray.Length; ++index)
            {
                try
                {
                    numArray[index] = Convert.ToByte(hexString.Substring(index * 2, 2), 16);
                }
                catch (Exception ex)
                {
                    Log4Neter.Error("输入可能错误:", ex);
                }
            }

            return numArray;
        }

        #region crc效验
        public static byte[] addCrcHexByte(byte[] strHexByte)
        {
            byte[] numArray = new byte[strHexByte.Length + 2];

            for (int index = 0; index < strHexByte.Length; ++index)
            {
                try
                {
                    numArray[index] = strHexByte[index];
                }
                catch (Exception ex)
                {
                    Log4Neter.Error("发送数据可能错误:", ex);
                }
            }

            byte[] numArray2 = callcrc(strHexByte, strHexByte.Length);
            numArray[strHexByte.Length + 0] = numArray2[0];
            numArray[strHexByte.Length + 1] = numArray2[1];
            return numArray;
        }
        public static byte[] callcrc(byte[] ss, int num)
        {
            ushort num1 = ushort.MaxValue;
            byte[] numArray = ss;

            for (byte index1 = 0; (int)index1 < num; ++index1)
            {
                num1 ^= (ushort)numArray[(int)index1];

                for (byte index2 = 0; (int)index2 < 8; ++index2)
                {
                    if (((int)num1 & 1) > 0)
                        num1 = (ushort)((uint)(ushort)((uint)num1 >> 1) ^ 40961U);
                    else
                        num1 >>= 1;
                }
            }

            byte num2 = (byte)((uint)num1 >> 8);
            return new byte[2]
            {
            (byte)((uint) num1 & (uint) byte.MaxValue),
            num2
            };
        }
        #endregion
    }
}
