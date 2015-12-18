using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public static class MyExtension
    {
        public static double Norm(this Vector v, VectorNorms.ComputeNorm f)
        {
            return f(v);
        }
    }
}
