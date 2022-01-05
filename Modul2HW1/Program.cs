using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Modul2HW1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var starter = new Starter();
            starter.BackUpHandler += starter.Run;
            starter.BackUpHandler += starter.Run;

            int number = starter.GetN();
            Task task = Task.Run(() => starter.BackUpHandler(5));
            task.Wait();

            Directory.CreateDirectory("B");
                    }
    }
}
