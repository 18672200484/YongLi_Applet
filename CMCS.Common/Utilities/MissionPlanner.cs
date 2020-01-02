using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Utilities
{
    public class ST_GPSXY_POINT
    {
        public double x;  // X坐标
        public double y;  // Y坐标
    }

    public class ST_GPS_POINT
    {
        public double sgp_lon;  // 经度
        public double sgp_lat;  // 纬度
    }
    public class MissionPlanner
    {
        public static double L0;
        //地球半径，单位米
        private const double EARTH_RADIUS = 6378137;
        /// <summary>
        /// 将WGS84坐标转换为北京54平面坐标点
        /// </summary>
        /// <param name="gpsPoint">GPS位置</param>
        /// <returns>坐标位置</returns>
        public static ST_GPSXY_POINT getScreenPoint(ST_GPS_POINT gpsPoint)
        {
            const double PI = 3.1415926535898;
            double MyL0;  //中央子午线
            double a, f, e2, e12;
            double A1, A2, A3, A4;
            double B, L;  //中央子午线弧度、纬度弧度、经度弧度
            double X;   //由赤道至纬度为B的子午线弧长   （P106   5-41）
            double N;   //椭球的卯酉圈曲率半径
            double t, t2, m, m2, ng2, cosB, sinB;
            ST_GPSXY_POINT ret = new ST_GPSXY_POINT();

            a = 6378245;  //长半径
            f = 298.3;   //扁率的倒数 （扁率：(a-b)/a）
            e2 = 1 - ((f - 1) / f) * ((f - 1) / f);        //第一偏心率的平方
            e12 = (f / (f - 1)) * (f / (f - 1)) - 1;       //第二偏心率的平方

            // 克拉索夫斯基椭球
            A1 = 111134.8611;
            A2 = -16036.4803;
            A3 = 16.8281;
            A4 = -0.0220;

            //计算当地中央子午线，3度带
            MyL0 = Math.Abs(gpsPoint.sgp_lon);
            MyL0 = Math.Floor(MyL0);
            MyL0 = 3 * Math.Floor(MyL0 / 3);
            L0 = Degree2Rad(MyL0); //将中央子午线转换为弧度
            B = Degree2Rad(gpsPoint.sgp_lat);
            L = Degree2Rad(gpsPoint.sgp_lon);

            X = A1 * B * 180.0 / PI + A2 * Math.Sin(2 * B) + A3 * Math.Sin(4 * B) + A4 * Math.Sin(6 * B);
            sinB = Math.Sin(B);
            cosB = Math.Cos(B);
            t = Math.Tan(B);
            t2 = t * t;

            N = a / Math.Sqrt(1 - e2 * sinB * sinB);
            m = cosB * (L - L0);
            m2 = m * m;
            ng2 = cosB * cosB * e2 / (1 - e2);
            ret.x = X + N * t * ((0.5 + ((5 - t2 + 9 * ng2 + 4 * ng2 * ng2) / 24.0 + (61 - 58 * t2 + t2 * t2) * m2 / 720.0) * m2) * m2);
            ret.y = N * m * (1 + m2 * ((1 - t2 + ng2) / 6.0 + m2 * (5 - 18 * t2 + t2 * t2 + 14 * ng2 - 58 * ng2 * t2) / 120.0));

            return ret;
        }

        /// <summary>
        /// 将北京54平面坐标点转换为WGS84坐标
        /// </summary>
        /// <param name="point">GPS位置</param>
        /// <returns>坐标位置</returns>
        public static ST_GPS_POINT getScreenPointToGps(ST_GPSXY_POINT point)
        {
            double N;   //椭球的卯酉圈曲率半径
            double t, t2, ng2, cosB, sinB, V, yN, preB0, B0, eta;
            double a, f, e2, e12;
            double A1, A2, A3, A4;
            double x, y;
            const double PI = 3.1415926535898;
            double sgp_lat, sgp_lon;
            ST_GPS_POINT ret = new ST_GPS_POINT();

            a = 6378245;  //长半径
            f = 298.3;   //扁率的倒数 （扁率：(a-b)/a）
            e2 = 1 - ((f - 1) / f) * ((f - 1) / f);        //第一偏心率的平方
            e12 = (f / (f - 1)) * (f / (f - 1)) - 1;       //第二偏心率的平方

            // 克拉索夫斯基椭球
            A1 = 111134.8611;
            A2 = -16036.4803;
            A3 = 16.8281;
            A4 = -0.0220;

            x = point.x;
            y = point.y;

            B0 = x / A1;
            do
            {
                preB0 = B0;
                B0 = B0 * PI / 180.0;
                B0 = (x - (A2 * Math.Sin(2 * B0) + A3 * Math.Sin(4 * B0) + A4 * Math.Sin(6 * B0))) / A1;
                eta = Math.Abs(B0 - preB0);
            } while (eta > 0.000000001);

            B0 = B0 * PI / 180.0;
            sinB = Math.Sin(B0);
            cosB = Math.Cos(B0);
            t = Math.Tan(B0);
            t2 = t * t;
            N = a / Math.Sqrt(1 - e2 * sinB * sinB);
            ng2 = cosB * cosB * e2 / (1 - e2);
            V = Math.Sqrt(1 + ng2);
            yN = y / N;

            sgp_lat = B0 - (yN * yN - (5 + 3 * t2 + ng2 - 9 * ng2 * t2) * yN * yN * yN * yN / 12.0 + (61 + 90 * t2 + 45 * t2 * t2) * yN * yN * yN * yN * yN * yN / 360.0) * V * V * t / 2;
            sgp_lon = L0 + (yN - (1 + 2 * t2 + ng2) * yN * yN * yN / 6.0 + (5 + 28 * t2 + 24 * t2 * t2 + 6 * ng2 + 8 * ng2 * t2) * yN * yN * yN * yN * yN / 120.0) / cosB;
            ret.sgp_lat = Rad2Degree(sgp_lat);
            ret.sgp_lon = Rad2Degree(sgp_lon);

            return ret;
        }

        /// <summary>
        /// 度转换为弧度
        /// </summary>
        /// <param name="Degree">经纬度（单位：度）</param>
        /// <returns>弧度</returns>
        public static double Degree2Rad(double Degree)
        {
            const double PI = 3.1415926535898;
            int Sign;
            double Rad;
            if (Degree >= 0)
            {
                Sign = 1;
            }
            else
            {
                Sign = -1;
            }
            Degree = Math.Abs(Degree); //绝对值
            Rad = Sign * Degree * PI / 180.0;
            return Rad;
        }
        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }

        /// <summary>
        /// 弧度转换为度
        /// </summary>
        /// <param name="Rad">弧度</param>
        /// <returns>经纬度（单位：度）</returns>
        public static double Rad2Degree(double Rad)
        {
            const double PI = 3.1415926535898;
            double Degree;
            int Sign;
            if (Rad >= 0)
            {
                Sign = 1;
            }
            else
            {
                Sign = -1;
            }
            Rad = Math.Abs(Rad * 180.0 / PI);
            Degree = Sign * Rad;
            return Degree;
        }

        /// <summary>
        /// 求两平面坐标点间距离
        /// </summary>
        /// <param name="point1">平面坐标位置</param>
        /// <param name="point2">平面坐标位置</param>
        /// <returns>距离</returns>
        public static double getDistanceForPoint(ST_GPSXY_POINT point1, ST_GPSXY_POINT point2)
        {
            double x = 0;
            double y = 0;
            double distance = 0;

            x = point1.x - point2.x;
            y = point1.y - point2.y;

            distance = Math.Sqrt(x * x + y * y);
            if (distance < 0)
            {
                distance = -distance;
            }

            return distance;
        }

        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns></returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }


        /// <summary>
        /// 根据两个gps点的趋势确定方向，根据距离，推算一条直线上第三个gps点
        /// </summary>
        /// <param name="gpsPoint1">两个GPS点位置（方向：gpsPoint2->gpsPoint1</param>
        /// <param name="gpsPoint2">两个GPS点位置（方向：gpsPoint2->gpsPoint1）</param>
        /// <param name="len">距离</param>
        /// <returns>GPS点位置</returns>
        public static ST_GPS_POINT getExcursionGpsInfo(ST_GPS_POINT gpsPoint1, ST_GPS_POINT gpsPoint2, double len)
        {//gpsPoint2->gpsPoint1
            ST_GPS_POINT ret = new ST_GPS_POINT();
            ST_GPSXY_POINT zb1 = new ST_GPSXY_POINT();
            ST_GPSXY_POINT zb2 = new ST_GPSXY_POINT();
            ST_GPSXY_POINT point = new ST_GPSXY_POINT();
            double rate, c = 0;
            double x1, x2, y1, y2;

            //将WGS84坐标转换为北京54平面坐标点

            zb1 = getScreenPoint(gpsPoint1);
            zb2 = getScreenPoint(gpsPoint2);
            c = getDistanceForPoint(zb1, zb2);//取得两个gps之间的距离
            // rate = (c + len) / c;//第三个点与第一个点的距离比，根据平行定理，计算出第三个点的坐标
            rate = len / c;//   距离/总长

            x1 = Math.Abs(zb1.x);
            x2 = Math.Abs(zb2.x);
            y1 = Math.Abs(zb1.y);
            y2 = Math.Abs(zb2.y);

            //取得第三点的平面坐标

            if (x1 < x2)//确定趋势
            {
                //point.x = zb2.x - rate * (zb2.x - zb1.x);
                point.x = zb1.x - rate * (zb1.x - zb2.x);
            }
            else
            {
                //point.x = rate * (zb1.x - zb2.x) + zb2.x;
                point.x = zb1.x + rate * (zb2.x - zb1.x);
            }
            if (y1 > y2)//确定趋势
            {
                //point.y = rate * (zb1.y - zb2.y) + zb2.y;
                point.y = zb1.y + rate * (zb2.y - zb1.y);
            }
            else
            {
                //point.y = zb2.y - rate * (zb2.y - zb1.y);
                point.y = zb1.y - rate * (zb1.y - zb2.y);
            }

            ret = getScreenPointToGps(point);//将平面坐标转换为经纬度

            return ret;
        }

//        楼主明显不知道啥是GOOGLE，啥是BAIDU。

//计算两点之间的角度公式是：

//假设点一（X1,Y1），点二（X2,Y2）

//double angleOfLine = Math.Atan2((Y2 - Y1), (X2 - X2)) * 180 / Math.PI

//假设点一是坐标原点（0,0）点二是（1,0）则这两点之间的连线角度是：0；

//假设点一是坐标原点（0,0）点二是（1,1）则这两点之间的连线角度是：45；

//假设点一是坐标原点（0,0）点二是（0,1）则这两点之间的连线角度是：90；

//假设点一是坐标原点（0,0）点二是（-1,1）则这两点之间的连线角度是：135；

//假设点一是坐标原点（0,0）点二是（-1,0）则这两点之间的连线角度是：180；

//假设点一是坐标原点（0,0）点二是（-1,-1）则这两点之间的连线角度是：-135；

//假设点一是坐标原点（0,0）点二是（0,-1）则这两点之间的连线角度是：-90；

//假设点一是坐标原点（0,0）点二是（1,-1）则这两点之间的连线角度是：-45；

//其实两个点之间的连线是分正负角度的，最少C#是这么区分的，他不是360度
    }
}
