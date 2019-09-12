using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgerEye.Framework.Utilities
{
    public class ComparisonResult
    {
        public bool Match { get; set; }
        public float DifferencePercentage { get; set; }
        public Image DifferenceImage { get; set; }
    }
}
