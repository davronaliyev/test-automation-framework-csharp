using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgerEye.Framework.Utilities
{
    public class ComparisonOptions
    {
        public byte Threshold { get; set; }
        public bool CreateDifferenceImage { get; set; }
        public bool ShowCellValues { get; set; }

        public ComparisonOptions()
        {
            CreateDifferenceImage = true;
        }
    }
}
