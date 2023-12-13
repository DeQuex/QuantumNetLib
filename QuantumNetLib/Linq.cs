namespace QuantumNetLib
{
    public delegate TResult Func<T, TResult>(T item);
    public delegate TResult Func<T1, T2, TResult>(T1 item1, T2 item2);
    public class Linq
    {
        public static T[] Where<T>(T[] array, Func<T, bool> predicate)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array)
            {
                if (predicate(item))
                {
                    result.push_back(item);
                }
            }
            return result.ToArray();
        }

        public static T[] Select<T>(T[] array, Func<T, T> selector)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array)
            {
                result.push_back(selector(item));
            }
            return result.ToArray();
        }

        public static T[] Select<T>(T[] array, Func<T, int, T> selector)
        {
            Vector<T> result = new Vector<T>();
            for (int i = 0; i < array.Length; i++)
            {
                result.push_back(selector(array[i], i));
            }
            return result.ToArray();
        }

        public static T[] SelectMany<T>(T[] array, Func<T, T[]> selector)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array)
            {
                foreach (T subItem in selector(item))
                {
                    result.push_back(subItem);
                }
            }
            return result.ToArray();
        }

        public static T[] SelectMany<T>(T[] array, Func<T, int, T[]> selector)
        {
            Vector<T> result = new Vector<T>();
            for (int i = 0; i < array.Length; i++)
            {
                foreach (T subItem in selector(array[i], i))
                {
                    result.push_back(subItem);
                }
            }
            return result.ToArray();
        }

        public static T[] SelectMany<T>(T[] array, Func<T, T[]> selector, Func<T, T, T> resultSelector)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array)
            {
                foreach (T subItem in selector(item))
                {
                    result.push_back(resultSelector(item, subItem));
                }
            }
            return result.ToArray();
        }

        public static T[] SelectMany<T>(T[] array, Func<T, int, T[]> selector, Func<T, T, T> resultSelector)
        {
            Vector<T> result = new Vector<T>();
            for (int i = 0; i < array.Length; i++)
            {
                foreach (T subItem in selector(array[i], i))
                {
                    result.push_back(resultSelector(array[i], subItem));
                }
            }
            return result.ToArray();
        }

        public static T First<T>(T[] array, Func<T, bool> predicate)
        {
            foreach (T item in array)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }

        public static T FirstOrDefault<T>(T[] array, Func<T, bool> predicate)
        {
            foreach (T item in array)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }

        public static T First<T>(T[] array)
        {
            return array[0];
        }

        public static T FirstOrDefault<T>(T[] array)
        {
            if (array.Length > 0)
            {
                return array[0];
            }
            return default(T);
        }

        public static T Last<T>(T[] array, Func<T, bool> predicate)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public static T LastOrDefault<T>(T[] array, Func<T, bool> predicate)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public static T Last<T>(T[] array)
        {
            return array[array.Length - 1];
        }

        public static T LastOrDefault<T>(T[] array)
        {
            if (array.Length > 0)
            {
                return array[array.Length - 1];
            }
            return default(T);
        }

        public static T Single<T>(T[] array, Func<T, bool> predicate)
        {
            T result = default(T);
            bool found = false;
            foreach (T item in array)
            {
                if (predicate(item))
                {
                    if (found)
                    { 
                        new Exception("Sequence contains more than one element", 1);
                    }
                    result = item;
                    found = true;
                }
            }

            if (!found)
            {
                new Exception("Sequence contains no elements", 2);
            }
            return result;
        }

        public static T SingleOrDefault<T>(T[] array, Func<T, bool> predicate)
        {
            T result = default(T);
            bool found = false;
            foreach (T item in array)
            {
                if (predicate(item))
                {
                    if (found)
                    {
                        new Exception("Sequence contains more than one element", 1);
                    }
                    result = item;
                    found = true;
                }
            }
            return result;
        }

        public static T Single<T>(T[] array)
        {
            if (array.Length > 1)
            {
                new Exception("Sequence contains more than one element", 1);
            }
            return array[0];
        }

        public static T SingleOrDefault<T>(T[] array)
        {
            if (array.Length > 1)
            {
                new Exception("Sequence contains more than one element", 1);
            }

            if (array.Length > 0)
            {
                return array[0];
            }
            return default(T);
        }

        public static T ElementAt<T>(T[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                new Exception("Index out of range", 1);
            }
            return array[index];
        }

        public static T ElementAtOrDefault<T>(T[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                return default(T);
            }
            return array[index];
        }

        public static T[] Concat<T>(T[] array1, T[] array2)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array1)
            {
                result.push_back(item);
            }

            foreach (T item in array2)
            {
                result.push_back(item);
            }
            return result.ToArray();
        }

        public static T[] Concat<T>(T[] array1, T[] array2, T[] array3)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array1)
            {
                result.push_back(item);
            }

            foreach (T item in array2)
            {
                result.push_back(item);
            }

            foreach (T item in array3)
            {
                result.push_back(item);
            }
            return result.ToArray();
        }

        public static T[] Concat<T>(T[] array1, T[] array2, T[] array3, T[] array4)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array1)
            {
                result.push_back(item);
            }

            foreach (T item in array2)
            {
                result.push_back(item);
            }

            foreach (T item in array3)
            {
                result.push_back(item);
            }

            foreach (T item in array4)
            {
                result.push_back(item);
            }
            return result.ToArray();
        }

        public static T[] Concat<T>(T[] array1, T[] array2, T[] array3, T[] array4, T[] array5)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array1)
            {
                result.push_back(item);
            }

            foreach (T item in array2)
            {
                result.push_back(item);
            }

            foreach (T item in array3)
            {
                result.push_back(item);
            }

            foreach (T item in array4)
            {
                result.push_back(item);
            }

            foreach (T item in array5)
            {
                result.push_back(item);
            }
            return result.ToArray();
        }

        public static T[] Concat<T>(T[] array1, T[] array2, T[] array3, T[] array4, T[] array5, T[] array6)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array1)
            {
                result.push_back(item);
            }

            foreach (T item in array2)
            {
                result.push_back(item);
            }

            foreach (T item in array3)
            {
                result.push_back(item);
            }

            foreach (T item in array4)
            {
                result.push_back(item);
            }

            foreach (T item in array5)
            {
                result.push_back(item);
            }

            foreach (T item in array6)
            {
                result.push_back(item);
            }
            return result.ToArray();
        }

        public static T[] Concat<T>(T[] array1, T[] array2, T[] array3, T[] array4, T[] array5, T[] array6, T[] array7)
        {
            Vector<T> result = new Vector<T>();
            foreach (T item in array1)
            {
                result.push_back(item);
            }

            foreach (T item in array2)
            {
                result.push_back(item);
            }

            foreach (T item in array3)
            {
                result.push_back(item);
            }

            foreach (T item in array4)
            {
                result.push_back(item);
            }

            foreach (T item in array5)
            {
                result.push_back(item);
            }

            foreach (T item in array6)
            {
                result.push_back(item);
            }

            foreach (T item in array7)
            {
                result.push_back(item);
            }
            return result.ToArray();
        }
    }
}