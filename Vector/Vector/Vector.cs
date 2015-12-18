using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class Vector : Polynomial
    {
        private int[] p;
        private int i1;
        private readonly int num;
        private static int count = 0;

        public Vector() : this(0, 0)
        {
        }

        public Vector(Vector v)
        {
            i1 = v.First;
            this.num = v.Length;

            p = new int[i1 + num];

            for (int i = i1; i <= v.Last; i++)
            {
                this.p[i] = v[i];
            }

            count++;
        }

        public Vector(int firstIndex, int num)
        {
            this.num = num >= 0 ? num : 0;
            this.i1 = (firstIndex >= 0 && firstIndex < num) ? firstIndex : 0;

            p = new int[i1 + num];

            count++;
        }


        #region PROPERTIES
        public int First
        {
            get
            {
                return this.i1;
            }
        }

        public int Last
        {
            get
            {
                return i1 + num + 1;
            }
        }

        public static int Count
        {
            get
            {
                return count;
            }
        }

        public int Length
        {
            get
            {
                return this.num;
            }
        }
        #endregion

        public int this[int index]
        {
            get
            {
                if (index >= First && index <= Last)
                {
                    return p[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException(index.ToString(), "Index out of range.");
                }
            }
            set
            {
                if (index >= First && index <= Last)
                {
                    p[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(index.ToString(), "Index out of range.");
                }
            }


        }

        public static Vector operator +(Vector rhs, Vector lhs)
        {
            Vector result;

            if (rhs.Length > lhs.Length)
            {
                int rhsIndex = rhs.First;
                int lhsIndex = lhs.First;
                int counter = lhs.Length;

                while (counter > 0)
                {
                    rhs[rhsIndex++] += lhs[lhsIndex++];
                }

                result = new Vector(rhs);
            }
            else
            {
                int rhsIndex = rhs.First;
                int lhsIndex = lhs.First;
                int counter = lhs.Length;

                while (counter > 0)
                {
                    lhs[lhsIndex++] += rhs[rhsIndex++];
                }

                result = new Vector(lhs);
            }

            return result;
        }

        public static int operator *(Vector rhs, Vector lhs)
        {
            return rhs.Length * lhs.Length;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (int number in p)
            {
                sb.AppendFormat("{0} ", number);
            }

            return sb.ToString().Trim();
        }

        double Polynomial.Evaluate(double x)
        {
            double sum = 0;

            for (int i = i1; i < Last; i++)
            {
                sum += p[i] * Math.Pow(x, i);
            }

            return sum;
        }

        Polynomial Polynomial.Differentiate()
        {
            for (int i = i1; i < Last; i++)
            {
                //may create problems later on
                p[i] *= i;
            }

            return (Polynomial)this;
        }
    }
}
