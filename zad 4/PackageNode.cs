using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_4
{
    internal class PackageNode
    {
        public Package Data;
        public PackageNode Left;
        public PackageNode Right;
        public PackageNode(Package data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
