using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Utilities
{
   public class UtilHttpPost
    {
        public static string doHttpPost(string body, string url, string header)
        {
            byte[] bytes = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //获取请求的方式
            request.Method = "post";
            request.Timeout = 20000;
            request.ContentType = "application/json";
            if (!string.IsNullOrEmpty(header))
            {
                request.Headers.Add("Authorization", header);
            }
            bytes = Encoding.UTF8.GetBytes(body);
            request.ContentLength = bytes.Length;
            Stream strStream = request.GetRequestStream();
            strStream.Write(bytes, 0, bytes.Length);
            strStream.Close();
            //就收应答
            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
            Stream strStream1 = null;
            strStream1 = httpResponse.GetResponseStream();
            string responseContent = new StreamReader(strStream1, Encoding.UTF8).ReadToEnd();
            return responseContent;
        }
        public static string doTokenHttpPost(string body, string url, string header)
        {
            byte[] bytes = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //获取请求的方式

            request.Method = "post";
            request.Timeout = 20000;
            request.ContentType = "application/json";
            request.Headers.Add("token", header);
            bytes = Encoding.UTF8.GetBytes(body);
            request.ContentLength = bytes.Length;
            Stream strStream = request.GetRequestStream();
            strStream.Write(bytes, 0, bytes.Length);
            strStream.Close();
            //就收应答
            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
            Stream strStream1 = null;
            strStream1 = httpResponse.GetResponseStream();
            string responseContent = new StreamReader(strStream1, Encoding.UTF8).ReadToEnd();
            return responseContent;
        }

        public static string PostWebApi(string data, string uri)
        {
            //创建Web访问对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(uri);
            //把用户传过来的数据转成“UTF-8”的字节流
            byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(data);

            myRequest.Method = "POST";
            myRequest.ContentLength = buf.Length;
            myRequest.ContentType = "application/json";
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;
            //发送请求
            Stream stream = myRequest.GetRequestStream();
            stream.Write(buf, 0, buf.Length);
            stream.Close();

            //获取接口返回值
            //通过Web访问对象获取响应内容
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            //通过响应内容流创建StreamReader对象，因为StreamReader更高级更快
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            //string returnXml = HttpUtility.UrlDecode(reader.ReadToEnd());//如果有编码问题就用这个方法
            string returnXml = reader.ReadToEnd();//利用StreamReader就可以从响应内容从头读到尾
            reader.Close();
            myResponse.Close();
            return returnXml;

        }
    }
}
