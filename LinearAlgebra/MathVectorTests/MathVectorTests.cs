using System.Collections;
using LinearAlgebra;
namespace MathVectorTests
{
    [TestClass]
    public class MathVectorTests
    {
        [TestMethod]
        public void TestMathVectorDimensionsValid()
        {
            const int dimensions = 3;
            IMathVector obj = new MathVector(dimensions);
        }

        [TestMethod]
        public void TestMathVectorDimensionsInvalid()
        {
            ArgumentException? expectedException = null;
            const int dimensions = -3;
            try
            {
                IMathVector obj = new MathVector(dimensions);}
            catch (ArgumentException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestMathVectorFromListValid()
        {
            double[] list = { 3, 4, 5, 10 };
            
            // Вариант 1: Если конструктор принимает double[]
            IMathVector vectorInitial = new MathVector(list); 
            
            for (int i = 0; i < vectorInitial.Dimensions; ++i)
            {
                Assert.AreEqual(list[i], vectorInitial[i]);
            }
        }

        [TestMethod]
        public void TestGetDimensionsValid()
        {
            const int expectedDimensionsValue = 3;
            IMathVector obj = new MathVector(expectedDimensionsValue);
            int actualDimensionsValue = obj.Dimensions;
            Assert.AreEqual(expectedDimensionsValue, actualDimensionsValue);
        }

        [TestMethod]
        public void TestSetValueByIndexValid()
        {
            int dimensions = 2;
            double val0 = 1.0;
            IMathVector obj = new MathVector(dimensions);
            obj[0] = val0;
            Assert.AreEqual(val0, obj[0]);
        }

        [TestMethod]
        public void TestSetValueByIndexInvalidNegativeIndex()
        {
            int dimensions = 2;
            IndexOutOfRangeException? expectedException = null;
            IMathVector obj = new MathVector(dimensions);
            try
            {
                obj[-1] = 1.5;}
            catch (IndexOutOfRangeException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestSetValueByIndexInvalidIndexHigherOverRange()
        {
            int dimensions = 2;
            IndexOutOfRangeException? expectedException = null;
            IMathVector obj = new MathVector(dimensions);
            try
            {
                obj[4] = 5.3;}
            catch (IndexOutOfRangeException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }


        [TestMethod]
        public void TestGetValueByIndexValid()
        {
            int dimensions = 2;
            double val0 = 1.0;
            IMathVector obj = new MathVector(dimensions);
            obj[0] = val0;
            double actualValue = obj[0];
            Assert.AreEqual(val0, actualValue);
        }

        [TestMethod]
        public void TestGetValueByIndexInvalidNegativeArg()
        {
            int dimensions = 2;
            double val0 = 1.0, val1 = 3.0;
            IndexOutOfRangeException? expectedException = null;
            IMathVector obj = new MathVector(dimensions);
            obj[0] = val0;
            obj[1] = val1;
            try
            {
                double actualValue = obj[-1];}
            catch (IndexOutOfRangeException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestGetValueByIndexInvalidArgOverBound()
        {
            int dimensions = 2;
            double val0 = 1.0, val1 = 3.0;
            IndexOutOfRangeException? expectedException = null;
            IMathVector obj = new MathVector(dimensions);
            obj[0] = val0;
            obj[1] = val1;
            try
            {
                double actualValue = obj[5];}
            catch (IndexOutOfRangeException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestLengthValid()
        {
            int dimensions = 3;
            double val0 = 3.0;
            double val1 = 4.0;
            double val2 = 5.0;
            double expectedLengthValue = Math.Sqrt(Math.Pow(val0, 2) + Math.Pow(val1, 2) + Math.Pow(val2, 2));
            IMathVector obj = new MathVector(dimensions);
            obj[0] = val0;
            obj[1] = val1;
            obj[2] = val2;
            double actualLengthValue = obj.Length;
            Assert.AreEqual(expectedLengthValue, actualLengthValue);
        }

        [TestMethod]
        public void TestSumNumberValid()
        {
            int dimensions = 2;
            double val0 = 5.0;
            double sumNumber = 11.5;
            IMathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 + sumNumber;
            vectorExpected[1] = val0 + sumNumber;
            IMathVector vectorActual = vectorInitial.SumNumber(sumNumber);
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestSubtractNumberValid()
        {
            int dimensions = 2;
            double val0 = 5.0;
            double sumNumber = 11.5;
            IMathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 - sumNumber;
            vectorExpected[1] = val0 - sumNumber;
            IMathVector vectorActual = vectorInitial.SubtractNumber(sumNumber);
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestMultiplyNumberValid()
        {
            int dimensions = 2;
            double val0 = 3.0;
            double multiplyNumber = 10.0;
            IMathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 * multiplyNumber;
            vectorExpected[1] = val0 * multiplyNumber;
            IMathVector vectorActual = vectorInitial.MultiplyNumber(multiplyNumber);
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestDivideNumberValid()
        {
            int dimensions = 2;
            double val0 = 3.0;
            double divisionNumber = 10.0;
            IMathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 / divisionNumber;
            vectorExpected[1] = val0 / divisionNumber;
            IMathVector vectorActual = vectorInitial.DivideNumber(divisionNumber);
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestDivideNumberInvalidDivByZero()
        {
            int dimensions = 2;
            double val0 = 3.0;
            double divisionNumber = 0;
            IMathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0;
            DivideByZeroException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial.DivideNumber(divisionNumber);}
            catch (DivideByZeroException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestSumVectorValid()
        {
            int dimensions = 2;
            double val0 = 3.0;
            double val1 = 2.25;
            IMathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 + val1;
            vectorExpected[1] = val0 + val1;
            IMathVector vectorActual = vectorInitial0.Sum(vectorInitial1);
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestSumVectorInvalid()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 3.0;
            double val1 = 2.25;
            IMathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0.Sum(vectorInitial1);}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestSubtractVectorValid()
        {
            int dimensions = 2;
            double val0 = 3.0;
            double val1 = 2.25;
            IMathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 - val1;
            vectorExpected[1] = val0 - val1;
            IMathVector vectorActual = vectorInitial0.Subtract(vectorInitial1);
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestSubtractVectorInvalid()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 3.0;
            double val1 = 2.25;
            IMathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0.Subtract(vectorInitial1);}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestMultiplyVectorValid()
        {
            int dimensions = 2;
            double val0 = 3.0;
            double val1 = 2.25;
            IMathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 * val1;
            vectorExpected[1] = val0 * val1;
            IMathVector vectorActual = vectorInitial0.Multiply(vectorInitial1);
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestMultiplyVectorInvalid()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 3.0;
            double val1 = 2.5;
            IMathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0.Multiply(vectorInitial1);}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestDivisionVectorValid()
        {
            int dimensions = 2;
            double val0 = 16.0;
            double val1 = 32.0;
            MathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 / val1;
            vectorExpected[1] = val0 / val1;
            IMathVector vectorActual = vectorInitial0 / vectorInitial1;
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestDivisionVectorInvalidDivByZero()
        {
            int dimensions = 1;
            double val0 = 14.0;
            double val1 = 0;
            MathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            DivideByZeroException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0 / vectorInitial1;}
            catch (DivideByZeroException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestDivisionVectorInvalidArithmeticErr()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 14.0;
            double val1 = 12.5;
            MathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0 / vectorInitial1;}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestScalarMultiplyVectorValid()
        {
            int dimensions = 2;
            double val0 = 3.0;
            double val1 = 2.25;
            IMathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            double valueExpected = val0 * val1 + val0 * val1;
            double valueActual = vectorInitial0.ScalarMultiply(vectorInitial1);
            Assert.AreEqual(valueExpected, valueActual);
        }

        [TestMethod]
        public void TestScalarMultiplyVectorInvalid()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 3.22;
            double val1 = 2.01;
            IMathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                double valueActual = vectorInitial0.ScalarMultiply(vectorInitial1);}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestCalcDistanceVectorValid()
        {
            int dimensions = 2;
            double val0 = 3.0;
            double val1 = 2.25;
            IMathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            double diff = val1 - val0;
            double valueExpected = Math.Pow(diff, 2) + Math.Pow(diff, 2);
            double valueActual = vectorInitial0.CalcDistance(vectorInitial1);
            Assert.AreEqual(valueExpected, valueActual);
        }

        [TestMethod]
        public void TestCalcDistanceVectorInvalid()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 3.22;
            double val1 = 2.01;
            IMathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            IMathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                double valueActual = vectorInitial0.CalcDistance(vectorInitial1);}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestOperatorSumNumberValid()
        {
            int dimensions = 2;
            double val0 = 5.0;
            double sumNumber = 11.5;
            MathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 + sumNumber;
            vectorExpected[1] = val0 + sumNumber;
            IMathVector vectorActual = vectorInitial + sumNumber;
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestOperatorSumVectorValid()
        {
            int dimensions = 3;
            double val0 = 5.0;
            double sumNumber = 11.5;
            MathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 + sumNumber;
            vectorExpected[1] = val0 + sumNumber;
            IMathVector vectorActual = vectorInitial + sumNumber;
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestOperatorSumVectorInvalid()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 5.0;
            double val1 = 5.0;
            MathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0 + vectorInitial1;}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestOperatorSubtractNumberValid()
        {
            int dimensions = 2;
            double val0 = 77;
            double subtractNumber = 22;
            MathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 - subtractNumber;
            vectorExpected[1] = val0 - subtractNumber;
            IMathVector vectorActual = vectorInitial - subtractNumber;
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestOperatorSubtractVectorValid()
        {
            int dimensions = 2;
            double val0 = 14.0;
            double val1 = 28.0;
            MathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 - val1;
            vectorExpected[1] = val0 - val1;
            IMathVector vectorActual = vectorInitial0 - vectorInitial1;
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestOperatorSubtractVectorInvalid()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 14.0;
            double val1 = 12.5;
            MathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0 - vectorInitial1;}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestOperatorMultiplicationNumberValid()
        {
            int dimensions = 2;
            double val0 = 70;
            double multiplyNumber = 15;
            MathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0 * val0;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 * multiplyNumber;
            vectorExpected[1] = val0 * val0 * multiplyNumber;
            IMathVector vectorActual = vectorInitial * multiplyNumber;
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestOperatorMultiplicationVectorValid()
        {
            int dimensions = 2;
            double val0 = 16.0;
            double val1 = 32.0;
            MathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 * val1;
            vectorExpected[1] = val0 * val1;
            IMathVector vectorActual = vectorInitial0 * vectorInitial1;
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestOperatorMultiplicationVectorInvalid()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 14.0;
            double val1 = 12.5;
            MathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0 * vectorInitial1;}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestOperatorDivisionNumberValid()
        {
            int dimensions = 3;
            double val0 = 225;
            double divisionNumber = 5;
            MathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val0 * val0;
            vectorInitial[1] = val0 * val0 * val0;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 / divisionNumber;
            vectorExpected[1] = val0 * val0 / divisionNumber;
            vectorExpected[1] = val0 * val0 * val0 / divisionNumber;
            IMathVector vectorActual = vectorInitial / divisionNumber;
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
            Assert.AreEqual(vectorExpected[2], vectorActual[2]);
        }

        [TestMethod]
        public void TestOperatorDivisionNumberInvalidDivByZero()
        {
            int dimensions = 1;
            double val0 = 225;
            double divisionNumber = 0;
            MathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            DivideByZeroException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial / divisionNumber;}
            catch (DivideByZeroException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestOperatorDivisionVectorValid()
        {
            int dimensions = 2;
            double val0 = 16.0;
            double val1 = 32.0;
            MathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            IMathVector vectorExpected = new MathVector(dimensions);
            vectorExpected[0] = val0 / val1;
            vectorExpected[1] = val0 / val1;
            IMathVector vectorActual = vectorInitial0 / vectorInitial1;
            Assert.AreEqual(vectorExpected[0], vectorActual[0]);
            Assert.AreEqual(vectorExpected[1], vectorActual[1]);
        }

        [TestMethod]
        public void TestOperatorDivisionVectorInvalidDivByZero()
        {
            int dimensions = 1;
            double val0 = 14.0;
            double val1 = 0;
            MathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            DivideByZeroException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0 / vectorInitial1;}
            catch (DivideByZeroException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestOperatorDivisionVectorInvalidArithmeticErr()
        {
            int dimensions0 = 1;
            int dimensions1 = 2;
            double val0 = 14.0;
            double val1 = 12.5;
            MathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            ArithmeticException? expectedException = null;
            try
            {
                IMathVector vectorActual = vectorInitial0 / vectorInitial1;}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestOperatorModulusValid()
        {
            int dimensions = 2;
            double val0 = 16.0;
            double val1 = 32.0;
            MathVector vectorInitial0 = new MathVector(dimensions);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            double valueExpected = val0 * val1 + val0 * val1;
            double valueActual = vectorInitial0 % vectorInitial1;
            Assert.AreEqual(valueExpected, valueActual);
        }

        [TestMethod]
        public void TestOperatorModulusInvalid()
        {
            int dimensions0 = 2;
            int dimensions1 = 3;
            double val0 = 16.0;
            double val1 = 32.0;
            MathVector vectorInitial0 = new MathVector(dimensions0);
            vectorInitial0[0] = val0;
            vectorInitial0[1] = val0;
            MathVector vectorInitial1 = new MathVector(dimensions1);
            vectorInitial1[0] = val1;
            vectorInitial1[1] = val1;
            double valueExpected = val0 * val1 + val0 * val1;
            ArithmeticException expectedException = null;
            try
            {
                double valueActual = vectorInitial0 % vectorInitial1;}
            catch (ArithmeticException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void TestGetEnumeratorValid()
        {
            int dimensions = 3;
            double val0 = 14.0;
            double val1 = 12.5;
            double val2 = -4.0;
            MathVector vectorInitial = new MathVector(dimensions);
            vectorInitial[0] = val0;
            vectorInitial[1] = val1;
            vectorInitial[2] = val2;
            IEnumerator vectorEnumerable = vectorInitial.GetEnumerator();
            vectorEnumerable.MoveNext();
            Assert.AreEqual(val0, vectorEnumerable.Current);
        }

        [TestMethod]
        public void TestToStringValid()
        {
            double[] list = { 3, 5, 7, 9 };
            string expectedValue = "3 5 7 9";
            MathVector vectorInitial = new MathVector(list);
            Console.WriteLine(vectorInitial);
            Assert.AreEqual(expectedValue, vectorInitial.ToString());
        }
    }
}