using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo01
{
    internal class VideoMode
    {
        public Resolution Resolution { get; set; } = new Resolution();
        public bool Interlaced { get; set; } = false;
        public double FrameRate { get; set; } = 0;
        public string? Name { get; set; } = null;
    }
}
