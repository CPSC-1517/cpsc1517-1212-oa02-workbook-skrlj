using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo01
{
    internal struct Resolution
    {
        public Resolution(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }
}
