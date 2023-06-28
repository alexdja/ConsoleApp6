using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    //Класс для сериализации в выходной json файл
    [Serializable]
    internal class DataOut
    {
        public double Weight { get; set; }
        public double Density_WorkCond { get; set; }
        public double Density_15 { get; set; }
        public double Volume_15 { get; set; }
        public DataOut(double w, double v, double d_wс, double d_15)
        {
            Density_15 = d_15;
            Volume_15 = v;
            Density_WorkCond = d_wс;
            Weight = w;
        }
    }
    internal static class Calc
    {
        //Рассчет и создание json файла
        public static DataOut CalcAndWriteDataOut(DataIn dataIn, string path)
        {
            double a_ct = 0.000012, a_s = 0.000012,
                   t_ct = dataIn.Temperature,
                   p_15;
            double Volume_c_15 = dataIn.Volume * (1 + (2 * a_ct + a_s) + (t_ct - 20))
                                 * CTL_v(dataIn.Density_20, t_ct - 15, t_ct - 15, out p_15);
            double weight = Volume_c_15 * p_15;
            
            DataOut dataOut = new DataOut(weight, Volume_c_15, weight / Volume_c_15, p_15);
            var jsonString = JsonSerializer.Serialize(dataOut);
            File.WriteAllText(path, jsonString);
            return dataOut;
        }
        static double CTL_v(double p, double t_p, double t_v, out double p_15)
        {
            double CTL_p, tmp, b_15 = 0;
            p_15 = p;
            do
            {
                tmp = p_15;
                b_15 = (186.9696 + 0.4862 * p_15) / (p_15 * p_15);
                CTL_p = Math.Exp(-b_15 * t_p * (1 + 0.8 * b_15 * t_p));
                p_15 = p / CTL_p;
            }
            while (Math.Abs(tmp - p_15) <= 0.01);
            return Math.Exp(-b_15 * t_v * (1 + 0.8 * b_15 * t_v));
        }
    }
}
