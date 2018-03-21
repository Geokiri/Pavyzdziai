using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandymas
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = "Some text some text.";
            string upperContent = content.ToUpper();

            File.WriteAllText(@"C:\Users\gkirilovas\Desktop\c#", upperContent);

            Console.ReadLine();
        }
    }
}
