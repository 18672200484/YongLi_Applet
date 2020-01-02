using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace CMCS.Common.Utilities
{
    public class UtilHttpPostWebService
    {
        public static string HttpPostWebService(string url, string num1)
        {
            string result = string.Empty;
            string param = string.Empty;
            byte[] bytes = null;
            Stream writer = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            param = HttpUtility.UrlEncode("Data") + "=" + HttpUtility.UrlEncode(num1);
            bytes = Encoding.UTF8.GetBytes(param);

            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            try
            {
                //获取用于写入请求数据的Stream对象
                writer = request.GetRequestStream();        
            }
            catch (Exception ex)
            {
                Log4Neter.Error("UtilHttpPostWebService：写入请求数据的Stream对象数据异常：", ex);
                return "";
            }
            //把参数数据写入请求数据流
            writer.Write(bytes, 0, bytes.Length);       
            writer.Close();

            try
            {
                //获得响应
                response = (HttpWebResponse)request.GetResponse();      
            }
            catch (WebException ex)
            {
                Log4Neter.Error("UtilHttpPostWebService：获得响应数据异常：", ex);
                return "";
            }

            #region 这种方式读取到的是一个返回的结果字符串
            Stream stream = response.GetResponseStream();        //获取响应流
            XmlTextReader Reader = new XmlTextReader(stream);
            Reader.MoveToContent();
            result = Reader.ReadInnerXml();
            #endregion

            #region 这种方式读取到的是一个Xml格式的字符串
            //StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            //result = reader.ReadToEnd();
            #endregion 

            response.Dispose();
            response.Close();

            Reader.Dispose();
            Reader.Close();

            stream.Dispose();
            stream.Close();

            return result;
        }
    }
}
