using System.Collections;
using System.Text;

namespace LinearAlgebra
{
    public class MathVector : IMathVector
    {
        private double[] _components;

        public MathVector(int dimensions)
        {
            if (dimensions <= 0)
                throw new ArgumentException("Incorrect dimension of the vector is entered\n");
            _components = new double[dimensions];
        }

        public MathVector(double[]  list)
        {
            _components = list.ToArray(); // Конвертирует список в массив
        }

        public int Dimensions
        {
            get { return _components.Length; }
        }

        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= Dimensions)
                {
                    throw new IndexOutOfRangeException("The index is out of the bounds of the vector\n");
                }

                return _components[i];
            }
            set
            {
                if (i < 0 || i >= Dimensions)
                {
                    throw new IndexOutOfRangeException("The index is out of the bounds of the vector\n");
                }

                _components[i] = value;
            }
        }

        public double Length
        {
            get
            {
                double squareSum = 0;
                foreach (var vectorPart in _components)
                {
                    squareSum += vectorPart * vectorPart;
                }

                return Math.Sqrt(squareSum);
            }
        }

        public IMathVector SumNumber(double number)
        {
            IMathVector returnValue = new MathVector(Dimensions);
            for (int i = 0; i < Dimensions; ++i)
            {
                returnValue[i] = this[i] + number;
            }

            return returnValue;
        }

        public IMathVector SubtractNumber(double number)
        {
            IMathVector returnValue = new MathVector(Dimensions);
            for (int i = 0; i < Dimensions; ++i)
            {
                returnValue[i] = this[i] - number;
            }

            return returnValue;
        }

        public IMathVector MultiplyNumber(double number)
        {
            IMathVector returnValue = new MathVector(Dimensions);
            for (int i = 0; i < Dimensions; ++i)
            {
                returnValue[i] = this[i] * number;
            }

            return returnValue;
        }

        public IMathVector DivideNumber(double number)
        {
            if (number == 0)
            {
                throw new DivideByZeroException("It is impossible to divide by zero");
            }

            IMathVector returnValue = new MathVector(Dimensions);
            for (int i = 0; i < Dimensions; ++i)
            {
                returnValue[i] = this[i] / number;
            }

            return returnValue;
        }

        public IMathVector Sum(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException(
                    "It is impossible to calculate the sum of vectors with different dimensions");
            IMathVector returnValue = new MathVector(Dimensions);
            for (int i = 0; i < Dimensions; ++i)
            {
                returnValue[i] = this[i] + vector[i];
            }

            return returnValue;
        }

        public IMathVector Subtract(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException(
                    "It is impossible to calculate the sum of vectors with different dimensions");
            IMathVector returnValue = new MathVector(Dimensions);
            for (int i = 0; i < Dimensions; ++i)
            {
                returnValue[i] = this[i] - vector[i];
            }

            return returnValue;
        }

        public IMathVector Multiply(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException(
                    "It is impossible to calculate the product of vectors with different dimensions");
            IMathVector returnValue = new MathVector(Dimensions);
            for (int i = 0; i < Dimensions; ++i)
            {
                returnValue[i] = this[i] * vector[i];
            }

            return returnValue;
        }

        public IMathVector Divide(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException(
                    "It is impossible to calculate the sum of vectors with different dimensions");
            IMathVector returnValue = new MathVector(Dimensions);
            for (int i = 0; i < Dimensions; ++i)
            {
                if (vector[i] == 0)
                {
                    throw new DivideByZeroException("It is impossible to divide by zero");
                }

                returnValue[i] = this[i] / vector[i];
            }

            return returnValue;
        }

        public double ScalarMultiply(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException(
                    "It is impossible to calculate the scalar multiply of vectors with different dimensions");
            double returnValue = 0;
            for (int i = 0; i < Dimensions; ++i)
            {
                returnValue += this[i] * vector[i];
            }

            return returnValue;
        }

        public double CalcDistance(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException(
                    "It is impossible to calculate the scalar multiply of vectors with different dimensions");
            double returnValue = 0;
            for (int i = 0; i < Dimensions; ++i)
            {
                double diff = this[i] - vector[i];
                returnValue += Math.Pow(diff, 2);
            }

            return returnValue;
        }

        public static IMathVector operator +(MathVector vector, double number)
        {
            return vector.SumNumber(number);
        }

        public static IMathVector operator +(MathVector vector1, MathVector vector2)
        {
            return vector1.Sum(vector2);
        }

        public static IMathVector operator -(MathVector vector, double number)
        {
            return vector.SubtractNumber(number);
        }

        public static IMathVector operator -(MathVector vector1, MathVector vector2)
        {
            return vector1.Subtract(vector2);
        }

        public static IMathVector operator *(MathVector vector, double number)
        {
            return vector.MultiplyNumber(number);
        }

        public static IMathVector operator *(MathVector vector1, MathVector vector2)
        {
            return vector1.Multiply(vector2);
        }

        public static IMathVector operator /(MathVector vector, double number)
        {
            return vector.DivideNumber(number);
        }

        public static IMathVector operator /(MathVector vector1, MathVector vector2)
        {
            return vector1.Divide(vector2);
        }

        public static double operator %(MathVector vector1, MathVector vector2)
        {
            return vector1.ScalarMultiply(vector2);
        }

        public IEnumerator GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        public override string ToString()
        {
            if (_components == null || _components.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var element in _components)
            {
                sb.Append(element);
                sb.Append(" ");
            }
            if (sb.Length > 0)
            {
                sb.Length--;
            }
            return sb.ToString();
        }
    }
}