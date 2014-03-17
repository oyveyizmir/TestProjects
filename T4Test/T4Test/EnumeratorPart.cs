using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Test
{
    partial class Enumerator
    {
        readonly int _from;
        readonly int _to;

        public Enumerator(int from, int to)
        {
            _from = from;
            _to = to;
        }
    }
}
