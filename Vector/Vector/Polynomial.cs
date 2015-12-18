using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public interface Polynomial
    {
        double Evaluate(double x);
        Polynomial Differentiate();
    }
}
