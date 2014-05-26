//#define FASTINVSQRT
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

        public static int NearestMod(int i, int mod) {
            var t = i%mod;
            if (t > 0) {
                return mod * (i / mod + 1);
            }
            return i; 
        }

        public unsafe static float Sqrt(float n)
        {
#if FASTINVSQRT
                        long i;
                        float x2, y;
 
                        x2 = n * 0.5f;
                        y = n;
 
                        i = *(long*)&y;
                        i = 0x5f3759df - (i >> 1);
                        y = *(float*)&i;
 
                        y *= 1.5f - (x2 * y * y);
 
                        y = 1.0f / y;
 
                        return (y < 0.0f ? -y : y);
#else
            return (float)Math.Sqrt(n);
#endif
        }
    }
}
