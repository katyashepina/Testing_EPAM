using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingForTheExistenceOfTriangle
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static class Triangle
        {
            static public bool CheckingForTheExistenceOfTriangle_Return_true(double a,double b,double c)
            {
                return a <= b + c || b <= a + c || c <= b + a;
            }
        }

    }
}
