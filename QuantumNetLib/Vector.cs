namespace QuantumNetLib
{
    public class Vector<T>
    {
        public T[] Data { get; set; }
        private int _size;
        public int Size => _size;

        public Vector()
        {
            Data = new T[4]; // Initial capacity
            _size = 0;
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Data.Length)
                {
                    new Exception("Index out of range", 1);
                }
                return Data[index];
            }
            set
            {
                if (index < 0 || index >= Data.Length)
                {
                    new Exception("Index out of range", 1);
                }
                Data[index] = value;
            }
        }

        // Resize array
        private void Resize()
        {
            int newCapacity = Data.Length == 0 ? 4 : Data.Length * 2;
            T[] temp = new T[newCapacity];
            Data.CopyTo(temp, 0);
            Data = temp;
        }

        // Add element at the end
        public void push_back(T item)
        {
            if (_size == Data.Length)
            {
                Resize();
            }
            Data[_size] = item;
            _size++;
        }

        // Remove element at the end
        public void pop_back()
        {
            if (_size == 0)
            {
                new Exception("Vector is empty", 2);
            }
            _size--;
        }

        // Get element at index
        public void erase(int index)
        {
            if (index < 0 || index >= _size)
            { 
                new Exception("Index out of range", 1);
            }

            for (int i = index; i < _size - 1; i++)
            {
                Data[i] = Data[i + 1];
            }
            _size--;
        }


        // Insert element at index
        public void insert(int index, T item)
        {
            if (index < 0 || index >= _size)
            {
                new Exception("Index out of range", 1);
            }

            if (_size == Data.Length)
            {
                Resize();
            }

            for (int i = _size; i > index; i--)
            {
                Data[i] = Data[i - 1];
            }
            Data[index] = item;
            _size++;
        }

        // Get size
        public int size()
        {
            return _size;
        }


        public Vector<T> Clone() // Deep copy
        {
            Vector<T> newVector = new Vector<T>();
            newVector.Data = new T[Data.Length];
            Data.CopyTo(newVector.Data, 0);
            // If you have other fields, copy them here as well
            return newVector;
        }

        // Get string
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _size; i++)
            {
                result += Data[i] + " ";
            }
            return result;
        }

        // Get string with new line
        public string ToStringLine()
        {
            string result = "";
            for (int i = 0; i < _size; i++)
            {
                result += Data[i] + "\n";
            }
            return result;
        }

        public T[] ToArray()
        {
            T[] result = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                result[i] = Data[i];
            }
            return result;
        }
        
    }
}
