namespace QuantumNetLib
{
    public class Vec3
    {
        protected bool Equals(Vec3 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vec3)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        // Default constructor
        public Vec3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        // Constructor with parameters
        public Vec3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Operator overloading
        public static Vec3 operator +(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vec3 operator -(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vec3 operator *(Vec3 a, float b)
        {
            return new Vec3(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vec3 operator *(float a, Vec3 b)
        {
            return new Vec3(a * b.X, a * b.Y, a * b.Z);
        }

        public static Vec3 operator /(Vec3 a, float b)
        {
            return new Vec3(a.X / b, a.Y / b, a.Z / b);
        }

        public static Vec3 operator /(float a, Vec3 b)
        {
            return new Vec3(a / b.X, a / b.Y, a / b.Z);
        }

        public static bool operator ==(Vec3 a, Vec3 b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Vec3 a, Vec3 b)
        {
            return a.X != b.X || a.Y != b.Y || a.Z != b.Z;
        }

        // Override ToString() method
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}