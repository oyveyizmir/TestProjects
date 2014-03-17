using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Numbers.N4);
            var t = new Enumerator(3, 9);
            string s = t.TransformText();
            Console.WriteLine(s);
        }
    }
}
