using static QuantumNetLib.LINQ;

namespace QuantumNetLib
{
    public class Random
    {
        private const long A = 48271; // Multiplier
        private const long C = 0; // Increment
        private const long M = 2147483647; // Modulus (2^31 - 1, a prime number)
        private long _seed;

        public Random(long seed)
        {
            _seed = seed;
        }

        public Random() : this(GenerateSeed())
        {
        }

        private static long GenerateSeed()
        {
            // Create a random seed based on a combination of factors
            long seed = 0;
            unchecked
            {
                seed = (long)(System.DateTime.Now.Ticks & 0xFFFFFFFF);
                seed = (seed * 397) ^ 0x7FFFFFFF;
            }
            return seed;
        }

        public int Next()
        {
            // Cast to ulong to avoid negative numbers on overflow
            _seed = (A * _seed + C) % M;
            return (int)(_seed & 0x7FFFFFFF); // Mask all but the first bit to ensure a non-negative result
        }

        public int Next(int min, int max)
        {
            if (max <= min)
                throw new ArgumentException("Maximum value must be greater than minimum value.", nameof(max));

            return Next() % (max - min + 1) + min;
        }

        public float NextFloat()
        {
            return (float)Next() / M;
        }

        public float NextFloat(float min, float max)
        {
            return NextFloat() * (max - min) + min;
        }

        public double NextDouble()
        {
            // Use Next to get the next random integer and scale it to [0, 1)
            return (double)Next() / (M - 1);
        }

        public double NextDouble(double min, double max)
        {
            return NextDouble() * (max - min) + min;
        }

        public bool NextBool()
        {
            return Next() % 2 == 0;
        }

        public bool NextBool(float probability)
        {
            return NextFloat() < probability;
        }

        public bool NextBool(double probability)
        {
            return NextDouble() < probability;
        }

        public void Shuffle<T>(T[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Next(0, i);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public void Shuffle<T>(Vector<T> list)
        {
            for (int i = list.Size - 1; i > 0; i--)
            {
                int j = Next(0, i);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        public T Choose<T>(T[] array)
        {
            return array[Next(0, array.Length - 1)];
        }

        public T Choose<T>(Vector<T> list)
        {
            return list[Next(0, list.Size - 1)];
        }

        public T Choose<T>(T[] array, float[] probabilities)
        {
            float sum = Sum(probabilities);
            float randomValue = NextFloat(0, sum);

            float cumulativeSum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                cumulativeSum += probabilities[i];
                if (randomValue < cumulativeSum)
                    return array[i];
            }

            return array[array.Length - 1];
        }

        public T Choose<T>(Vector<T> list, Vector<float> probabilities)
        {
            float sum = Sum(probabilities);
            float randomValue = NextFloat(0, sum);

            float cumulativeSum = 0;
            for (int i = 0; i < probabilities.Size; i++)
            {
                cumulativeSum += probabilities[i];
                if (randomValue < cumulativeSum)
                    return list[i];
            }

            return list[list.Size - 1];
        }

        public T Choose<T>(T[] array, double[] probabilities)
        {
            double sum = Sum(probabilities);
            double randomValue = NextDouble(0, sum);

            double cumulativeSum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                cumulativeSum += probabilities[i];
                if (randomValue < cumulativeSum)
                    return array[i];
            }

            return array[array.Length - 1];
        }

        public T Choose<T>(Vector<T> list, Vector<double> probabilities)
        {
            double sum = Sum(probabilities);
            double randomValue = NextDouble(0, sum);

            double cumulativeSum = 0;
            for (int i = 0; i < probabilities.Size; i++)
            {
                cumulativeSum += probabilities[i];
                if (randomValue < cumulativeSum)
                    return list[i];
            }

            return list[list.Size - 1];
        }

        public T Choose<T>(T[] array, int[] weights)
        {
            int sum = Sum(weights);
            int randomValue = Next(0, sum);

            int cumulativeSum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                cumulativeSum += weights[i];
                if (randomValue < cumulativeSum)
                    return array[i];
            }

            return array[array.Length - 1];
        }

        public T Choose<T>(Vector<T> list, Vector<int> weights)
        {
            int sum = Sum(weights);
            int randomValue = Next(0, sum);

            int cumulativeSum = 0;
            for (int i = 0; i < weights.Size; i++)
            {
                cumulativeSum += weights[i];
                if (randomValue < cumulativeSum)
                    return list[i];
            }

            return list[list.Size - 1];
        }

        public string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[Next(0, chars.Length - 1)];
            }
            return new string(result);
        }
    }
}