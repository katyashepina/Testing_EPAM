using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests_ForTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }

        public class UnitTestForУxistenceЕriangle
        {
            public void IsTreangle_Isosceles_Return_True()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(20,20,20),true);
            }

            public void IsTreangle_Equilateral_Return_True()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(5,5,5),true);
            }

            public void IsTreangle_WithDoubleSide_Return_True()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(12.4,18.9,20.1),true);
            }

            public void IsTrangle_NotExist_Return_False()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(2,3,12),false);
            }

            public void IsTreangle_WithOneNullSide_Return_False()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(0,6,6), false) ;
            }

            public void IsTreang_leWithTwoNullSide_Return_False()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(0,0,5),false);
            }

            public void IsTreangle_WIthThreeNullSide_Return_False()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(0,0,0),false);
            }

            public void IsTreangle_WithOneNegativeSide_Return_False()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(-10, 20, 12), false);
            }

            public void IsTreangle_WithTwoNegativeSide_Return_False()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(-10, -20, 12), false);
            }

            public void IsTreangle_WithThreeNegativeSide_Return_False()
            {
                Assert.AreEqual(Triangle.CheckingForTheExistenceOfTriangle_Return_true(-10, -20, -12), false);
            }
        }        

    }
}
