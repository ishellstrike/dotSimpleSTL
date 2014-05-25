using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSTL
{
    public static class SstlHelper
    {
        public static float Clamp(float value, float min, float max)
        {
            return value > max ? max : value < min ? min : value;
        }
    }
}
