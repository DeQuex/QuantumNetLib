namespace QuantumNetLib
{
    public static class Math
    {
        public const float PI = 3.14159265359f;
        public const float E = 2.71828182846f;

        public static bool IsEqual(float a, float b, float epsilon = 0.0001f)
        {
            return Abs(a - b) < epsilon;
        }
        public static bool IsZero(float value, float epsilon = 0.0001f)
        {
            return Abs(value) < epsilon;
        }

        public static float Abs(float value)
        {
            return value < 0 ? -value : value;
        }

        public static float Sqrt(float value)
        {
            if (value < 0)
                throw new ArgumentException("Value must be non-negative.");

            float guess = value / 2;
            float result = 0;

            while (Abs(guess - result) > 0.0001f)
            {
                result = guess;
                guess = (guess + value / guess) / 2;
            }

            return result;
        }

        public static float Pow(float baseValue, int exponent)
        {
            if (exponent < 0)
                throw new ArgumentException("Exponent must be non-negative.");

            float result = 1;
            while (exponent != 0)
            {
                if ((exponent & 1) == 1)
                    result *= baseValue;
                baseValue *= baseValue;
                exponent >>= 1;
            }
            return result;
        }

        public static float Sin(float radians)
        {
            const int terms = 10;
            float result = 0;

            for (int i = 0; i < terms; i++)
            {
                float term = Pow(-1, i) * Pow(radians, 2 * i + 1) / Factorial(2 * i + 1);
                result += term;
            }

            return result;
        }

        public static float Cos(float radians)
        {
            const int terms = 10;
            float result = 0;

            for (int i = 0; i < terms; i++)
            {
                float term = Pow(-1, i) * Pow(radians, 2 * i) / Factorial(2 * i);
                result += term;
            }

            return result;
        }

        public static float Tan(float radians)
        {
            float cos = Cos(radians);
            if (cos == 0)
                throw new ArgumentException("Tangent is undefined for this angle.");

            return Sin(radians) / cos;
        }

        public static int Factorial(int value)
        {
            if (value < 0)
                throw new ArgumentException("Value must be non-negative.");

            int result = 1;
            for (int i = 2; i <= value; i++)
                result *= i;
            return result;
        }

        public static float Log(float value)
        {
            if (value <= 0)
                throw new ArgumentException("Value must be positive.");

            const int terms = 100;
            float result = 0;

            for (int i = 1; i < terms; i++)
            {
                float term = Pow(-1, i + 1) * Pow(value - 1, i) / i;
                result += term;
            }

            return result;
        }

        public static float Log(float value, float baseValue)
        {
            if (value <= 0 || baseValue <= 0 || baseValue == 1)
                throw new ArgumentException("Invalid input values.");

            return Log(value) / Log(baseValue);
        }

        public static float Log10(float value)
        {
            if (value <= 0)
                throw new ArgumentException("Value must be positive.");

            return Log(value) / Log(10);
        }

        public static float Log2(float value)
        {
            if (value <= 0)
                throw new ArgumentException("Value must be positive.");

            return Log(value) / Log(2);
        }

        public static float Min(float a, float b)
        {
            return a < b ? a : b;
        }

        public static float Max(float a, float b)
        {
            return a > b ? a : b;
        }

        public static float Clamp(float value, float min, float max)
        {
            return value < min ? min : value > max ? max : value;
        }

        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * Clamp(t, 0, 1);
        }

        public static float Map(float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            if (fromMin == fromMax)
                throw new ArgumentException("From range is invalid.");

            float t = (value - fromMin) / (fromMax - fromMin);
            return Lerp(toMin, toMax, t);
        }

        public static float RandomRange(float min, float max)
        {
            Random random = new Random();
            return (float)(random.NextDouble() * (max - min) + min);
        }
    }
}