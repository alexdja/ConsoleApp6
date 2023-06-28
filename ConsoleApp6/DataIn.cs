using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    //Класс для чтения в входного json файла
    [Serializable]
    internal class DataIn
    {
        public double Density_20 { get; set; }
        public double Volume { get; set; }
        public double Temperature { get; set; }
        public DataIn(double d, double v, double t) { 
            Density_20 = d; 
            Volume = v;
            Temperature = t;
        }
    }
}
