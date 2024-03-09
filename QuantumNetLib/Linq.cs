namespace QuantumNetLib
{
    public delegate TResult Func<in T, out TResult>(T item);
    public delegate TResult Func<in T1, in T2, out TResult>(T1 item1, T2 item2);

    public static class LINQ
    {
        public static T[] Where<T>(T[] array, Func<T, bool> predicate)
        {
            var result = new Vector<T>();
            foreach (var item in array)
                if (predicate(item))
                    result.PushBack(item);
            return result.ToArray();
        }

        public static TResult[] Select<T, TResult>(T[] array, Func<T, TResult> selector)
        {
            var result = new Vector<TResult>();
            foreach (var item in array)
                result.PushBack(selector(item));
            return result.ToArray();
        }

        public static TResult[] Select<T, TResult>(T[] array, Func<T, int, TResult> selector)
        {
            var result = new Vector<TResult>();
            for (var i = 0; i < array.Length; i++)
                result.PushBack(selector(array[i], i));
            return result.ToArray();
        }

        public static TResult[] SelectMany<T, TResult>(T[] array, Func<T, TResult[]> selector)
        {
            var result = new Vector<TResult>();
            foreach (var item in array)
                foreach (var subItem in selector(item))
                    result.PushBack(subItem);
            return result.ToArray();
        }

        public static TResult[] SelectMany<T, TResult>(T[] array, Func<T, int, TResult[]> selector)
        {
            var result = new Vector<TResult>();
            for (var i = 0; i < array.Length; i++)
                foreach (var subItem in selector(array[i], i))
                    result.PushBack(subItem);
            return result.ToArray();
        }

        public static TResult[] SelectMany<T, TCollection, TResult>(T[] array, Func<T, TCollection[]> collectionSelector, Func<T, TCollection, TResult> resultSelector)
        {
            var result = new Vector<TResult>();
            foreach (var item in array)
                foreach (var subItem in collectionSelector(item))
                    result.PushBack(resultSelector(item, subItem));
            return result.ToArray();
        }

        public static TResult[] SelectMany<T, TCollection, TResult>(T[] array, Func<T, int, TCollection[]> collectionSelector, Func<T, TCollection, TResult> resultSelector)
        {
            var result = new Vector<TResult>();
            for (var i = 0; i < array.Length; i++)
                foreach (var subItem in collectionSelector(array[i], i))
                    result.PushBack(resultSelector(array[i], subItem));
            return result.ToArray();
        }

        public static T First<T>(T[] array, Func<T, bool> predicate)
        {
            foreach (var item in array)
                if (predicate(item))
                    return item;
            throw new Exception("Sequence contains no matching element", 2);
        }

        public static T FirstOrDefault<T>(T[] array, Func<T, bool> predicate)
        {
            foreach (var item in array)
                if (predicate(item))
                    return item;
            return default;
        }

        public static T First<T>(T[] array)
        {
            if (array.Length == 0)
                throw new Exception("Sequence contains no elements", 2);
            return array[0];
        }

        public static T FirstOrDefault<T>(T[] array)
        {
            return array.Length > 0 ? array[0] : default;
        }

        public static T Last<T>(T[] array, Func<T, bool> predicate)
        {
            for (var i = array.Length - 1; i >= 0; i--)
                if (predicate(array[i]))
                    return array[i];
            throw new Exception("Sequence contains no matching element", 2);
        }

        public static T LastOrDefault<T>(T[] array, Func<T, bool> predicate)
        {
            for (var i = array.Length - 1; i >= 0; i--)
                if (predicate(array[i]))
                    return array[i];
            return default;
        }

        public static T Last<T>(T[] array)
        {
            if (array.Length == 0)
                throw new Exception("Sequence contains no elements", 2);
            return array[array.Length - 1];
        }

        public static T LastOrDefault<T>(T[] array)
        {
            return array.Length > 0 ? array[array.Length - 1] : default;
        }

        public static T Single<T>(T[] array, Func<T, bool> predicate)
        {
            var result = default(T);
            var found = false;
            foreach (var item in array)
            {
                if (predicate(item))
                {
                    if (found)
                        throw new Exception("Sequence contains more than one matching element", 1);
                    result = item;
                    found = true;
                }
            }

            if (!found)
                throw new Exception("Sequence contains no matching element", 2);
            return result;
        }

        public static T SingleOrDefault<T>(T[] array, Func<T, bool> predicate)
        {
            var result = default(T);
            var found = false;
            foreach (var item in array)
            {
                if (predicate(item))
                {
                    if (found)
                        throw new Exception("Sequence contains more than one matching element", 1);
                    result = item;
                    found = true;
                }
            }
            return result;
        }

        public static T Single<T>(T[] array)
        {
            if (array.Length == 0)
                throw new Exception("Sequence contains no elements", 2);
            if (array.Length > 1)
                throw new Exception("Sequence contains more than one element", 1);
            return array[0];
        }

        public static T SingleOrDefault<T>(T[] array)
        {
            if (array.Length > 1)
                throw new Exception("Sequence contains more than one element", 1);
            return array.Length > 0 ? array[0] : default;
        }

        public static T ElementAt<T>(T[] array, int index)
        {
            if (index < 0 || index >= array.Length)
                throw new Exception("Index out of range", 1);
            return array[index];
        }

        public static T ElementAtOrDefault<T>(T[] array, int index)
        {
            if (index < 0 || index >= array.Length)
                return default;
            return array[index];
        }

        public static T[] Concat<T>(params T[][] arrays)
        {
            var result = new Vector<T>();
            foreach (var array in arrays)
                foreach (var item in array)
                    result.PushBack(item);
            return result.ToArray();
        }

        public static T Sum<T>(T[] array)
        {
            var result = default(T);
            foreach (var item in array)
                result += (dynamic)item;
            return result;
        }

        // New Sum methods for Vector<T>
        public static int Sum(Vector<int> vector)
        {
            int result = 0;
            for (int i = 0; i < vector.Size; i++)
                result += vector[i];
            return result;
        }

        public static float Sum(Vector<float> vector)
        {
            float result = 0;
            for (int i = 0; i < vector.Size; i++)
                result += vector[i];
            return result;
        }

        public static double Sum(Vector<double> vector)
        {
            double result = 0;
            for (int i = 0; i < vector.Size; i++)
                result += vector[i];
            return result;
        }
    }
}