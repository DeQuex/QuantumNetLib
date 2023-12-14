namespace QuantumNetLib
{
    public class Vector<T>
    {
        public Vector()
        {
            Data = new T[4]; // Initial capacity
            Size = 0;
        }

        public T[] Data { get; set; }
        public int Size { get; private set; }

        // Indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Data.Length) new Exception("Index out of range", 1);
                return Data[index];
            }
            set
            {
                if (index < 0 || index >= Data.Length) new Exception("Index out of range", 1);
                Data[index] = value;
            }
        }

        // Resize array
        private void Resize()
        {
            var newCapacity = Data.Length == 0 ? 4 : Data.Length * 2;
            var temp = new T[newCapacity];
            Data.CopyTo(temp, 0);
            Data = temp;
        }

        // Add element at the end
        public void push_back(T item)
        {
            if (Size == Data.Length) Resize();
            Data[Size] = item;
            Size++;
        }

        // Remove element at the end
        public void pop_back()
        {
            if (Size == 0) new Exception("Vector is empty", 2);
            Size--;
        }

        // Get element at index
        public void erase(int index)
        {
            if (index < 0 || index >= Size) new Exception("Index out of range", 1);

            for (var i = index; i < Size - 1; i++) Data[i] = Data[i + 1];
            Size--;
        }


        // Insert element at index
        public void insert(int index, T item)
        {
            if (index < 0 || index >= Size) new Exception("Index out of range", 1);

            if (Size == Data.Length) Resize();

            for (var i = Size; i > index; i--) Data[i] = Data[i - 1];
            Data[index] = item;
            Size++;
        }

        // Get size
        public int size()
        {
            return Size;
        }


        public Vector<T> Clone() // Deep copy
        {
            var newVector = new Vector<T>();
            newVector.Data = new T[Data.Length];
            Data.CopyTo(newVector.Data, 0);
            // If you have other fields, copy them here as well
            return newVector;
        }

        // Get string
        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < Size; i++) result += Data[i] + " ";
            return result;
        }

        // Get string with new line
        public string ToStringLine()
        {
            var result = "";
            for (var i = 0; i < Size; i++) result += Data[i] + "\n";
            return result;
        }

        public T[] ToArray()
        {
            var result = new T[Size];
            for (var i = 0; i < Size; i++) result[i] = Data[i];
            return result;
        }
    }
}