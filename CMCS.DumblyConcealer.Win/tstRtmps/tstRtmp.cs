using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Win.tstRtmps
{
    public  class tstRtmp
    {
        //安装的ffmpeg的路径 写在配置文件的 你也可以直接写你的路径 D:\ffmpeg\bin\ffmpeg.exe
        static string FFmpegPath = System.Configuration.ConfigurationManager.AppSettings["ffmepg"];

        /// <summary>
        /// 视频转码为ts文件
        /// </summary>
        /// <param name="videoUrl"></param>
        /// <param name="targetUrl"></param>
        public static void VideoToTs(string videoUrl, string targetUrl)
        {
            //视频转码指令
            string para = $@"ffmpeg -y -i {videoUrl} -vcodec copy -acodec copy -vbsf h264_mp4toannexb {targetUrl}";
            RunMyProcess(para);
        }

        /// <summary>
        /// 将ts文件转换为mu3u8文件
        /// </summary>
        /// <param name="tsUrl"></param>
        /// <param name="m3u8Url">这个路径不要带扩展名</param>
        public static void TsToM3u8(string tsUrl, string m3u8Url)
        {
            //视频转码指令
            //string para = $@"ffmpeg -i {tsUrl} -c copy -map 0 -f segment -segment_list {m3u8Url}.m3u8 -segment_time 5 {m3u8Url}-%03d.ts";
            //这里是关键点，一般平时切视频都是用FFmpeg -i  地址 -c这样，但是在服务器时，这样调用可能找不到ffmpeg的路径 所以这里直接用ffmpeg.exe来执行命令
            string para = $@"{FFmpegPath} -i {tsUrl} -c copy -map 0 -f segment -segment_list {m3u8Url}.m3u8 -segment_time 5 {m3u8Url}-%03d.ts";
            RunMyProcess(para);
        }

        /// <summary>
        /// 执行cmd指令
        /// </summary>
        /// <param name="Parameters"></param>
        public static void RunMyProcess(string Parameters)
        {
            using (Process p = new Process())
            {
                try
                {
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
                    p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                    p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                    p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                    p.StartInfo.CreateNoWindow = false;//不显示程序窗口                                                
                    p.Start();//启动程序
                    //向cmd窗口发送输入信息
                    p.StandardInput.WriteLine(Parameters + "&&exit");
                    p.StandardInput.AutoFlush = true;
                    p.StandardInput.Close();
                    //获取cmd窗口的输出信息
                    string output = p.StandardError.ReadToEnd(); //可以输出output查看具体报错原因

                    //等待程序执行完退出进程
                    p.WaitForExit();
                    p.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
