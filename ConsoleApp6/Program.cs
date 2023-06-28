using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Transactions;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Пример
            //Файл находится в ConsoleApp6\ConsoleApp6\bin\Debug
            string pathTojson = "..\\input.json";
            DataIn d = JsonConvert.DeserializeObject<DataIn>(File.ReadAllText(pathTojson));

            var dOut = Calc.CalcAndWriteDataOut(d, "..\\output.json");
            Console.WriteLine();
        }
    }
}