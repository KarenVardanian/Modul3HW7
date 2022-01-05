using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Modul2HW1
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<Ожидание>")]

    public class Starter
    {
        private const string FilePath = "log3.txt";
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:Elements should be ordered by access", Justification = "<Ожидание>")]
        public Func<double, Task> BackUpHandler;
#pragma warning disable SA1201 // Elements should appear in the correct order
        private readonly Actions _action;
#pragma warning restore SA1201 // Elements should appear in the correct order
        private readonly Logger _logger;
        public Starter()
        {
            _action = new Actions();
            _logger = Logger.Instance;
        }

        public int GetN()
        {
             string n = "N.txt";

            // using (StreamWriter sw = new StreamWriter(n, false, System.Text.Encoding.Default))
            // {
            //     sw.WriteLine(15);
            // }
             int number;
             using (StreamReader sr = new StreamReader(n))
            {
                string line = sr.ReadLine();
                number = Convert.ToInt32(line);
                Console.WriteLine(number);
            }

             return number;
        }

        public async Task Run(double n)
        {
            var rnd = new Random();
            var result = new Result();

            for (double i = 1; i < 51; i++)
            {
                switch (rnd.Next(3))
                {
                    case 0:
                        result = _action.Method_1();
                        break;
                    case 1:
                        result = _action.Method_2();
                        break;
                    case 2:
                        result = _action.Method_3();
                        break;
                }

                if (!result.Status)
                {
                    _logger.LogError($"Action failed by a reason: {result.ErrorMessage}");
                }

                if (i % 5.0 == 0)
                {
                    string filename = string.Format(
                    DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss") + "..txt");
                    string p = Directory.GetCurrentDirectory();
                    _logger.WriteToFile(filename);

                    Task.Delay(1000).Wait();
                    filename = " ";
                }
            }

            await Task.Delay(1000);
        }
    }
}
