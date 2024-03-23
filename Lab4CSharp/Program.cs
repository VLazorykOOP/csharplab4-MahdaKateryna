using System;

namespace Lab4CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\t\t\tLab 3 ");
            Console.WriteLine("\t\t\tTask 1 ");
            Console.WriteLine();

            DRomb[] rombs = new DRomb[5];
            rombs[0] = new DRomb(5, 8, 1);
            rombs[1] = new DRomb(7, 7, 2);
            rombs[2] = new DRomb(4, 4, 3);
            rombs[3] = new DRomb(6, 6, 3);
            rombs[4] = new DRomb(8, 3, 4);

            int squareCount = 0;

            foreach (var romb in rombs)
            {
                Console.WriteLine("Ромб з діагоналями {0} і {1}, має колір {2}.", romb.D1, romb.D2, romb.GetColor());
                Console.WriteLine("Периметр ромба: {0}", romb.CalculatePerimeter());
                Console.WriteLine("Площа ромба: {0}", romb.CalculateArea());
                if (romb.IsSquare())
                {
                    squareCount++;
                    Console.WriteLine("Ромб є квадратом.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Ромб не є квадратом.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Загальна кількість квадратів: {0}", squareCount);
            Console.WriteLine();
            Console.WriteLine();
           
        }
        
    }

    public class DRomb
    {
        private int d1;
        private int d2;
        private int color;

        public DRomb(int d1, int d2, int color)
        {
            this.d1 = d1;
            this.d2 = d2;
            this.color = color;
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return d1;
                    case 1: return d2;
                    case 2: return color;
                    default: throw new IndexOutOfRangeException("Неправильний індекс");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: d1 = value; break;
                    case 1: d2 = value; break;
                    case 2: color = value; break;
                    default: throw new IndexOutOfRangeException("Неправильний індекс");
                }
            }
        }

        public int D1
        {
            get { return d1; }
            set { d1 = value; }
        }

        public int D2
        {
            get { return d2; }
            set { d2 = value; }
        }

        public int GetColor()
        {
            return color;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Math.Sqrt(Math.Pow(d1 / 2.0, 2) + Math.Pow(d2 / 2.0, 2)));
        }

        public double CalculateArea()
        {
            return (d1 * d2) / 2.0;
        }

        public bool IsSquare()
        {
            return d1 == d2;
        }

        public static DRomb operator ++(DRomb romb)
        {
            romb.d1++;
            romb.d2++;
            return romb;
        }

        public static DRomb operator --(DRomb romb)
        {
            romb.d1--;
            romb.d2--;
            return romb;
        }

        public static bool operator true(DRomb romb)
        {
            return romb.IsSquare();
        }

        public static bool operator false(DRomb romb)
        {
            return !romb.IsSquare();
        }

        public static DRomb operator +(DRomb romb, int scalar)
        {
            romb.d1 += scalar;
            romb.d2 += scalar;
            return romb;
        }

        public static explicit operator string(DRomb romb)
        {
            return $"DRomb with diagonals {romb.d1} and {romb.d2}, color: {romb.color}";
        }

        public static explicit operator DRomb(string s)
        {
            string[] parts = s.Split(new[] { " with diagonals ", " and ", ", color: " }, StringSplitOptions.None);
            if (parts.Length != 4) throw new ArgumentException("Invalid string format");
            return new DRomb(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
        }
    }

    
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    

    public class VectorULong
    {
        protected ulong[] IntArray; // масив
        protected uint size; // розмір вектора
        protected int codeError; // код помилки
        protected static uint num_vec = 0; // кількість векторів

        // Конструктори
        public VectorULong()
        {
            size = 1;
            IntArray = new ulong[size];
            IntArray[0] = 0;
            num_vec++;
        }

        public VectorULong(uint size)
        {
            this.size = size;
            IntArray = new ulong[size];
            for (int i = 0; i < size; i++)
            {
                IntArray[i] = 0;
            }
            num_vec++;
        }

        public VectorULong(uint size, ulong initValue)
        {
            this.size = size;
            IntArray = new ulong[size];
            for (int i = 0; i < size; i++)
            {
                IntArray[i] = initValue;
            }
            num_vec++;
        }

        // Деструктор
        ~VectorULong()
        {
            Console.WriteLine("Destructor called for VectorULong object.");
        }

        // Методи
        public void Input()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter element at index {i}: ");
                IntArray[i] = ulong.Parse(Console.ReadLine());
            }
        }

        public void Display()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Element at index {i}: {IntArray[i]}");
            }
        }

        public void Assign(ulong value)
        {
            for (int i = 0; i < size; i++)
            {
                IntArray[i] = value;
            }
        }

        public static uint CountVectors()
        {
            return num_vec;
        }

        // Властивості
        public uint Size
        {
            get { return size; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        // Індексатор
        public ulong this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    codeError = -1;
                    return 0;
                }
                else
                {
                    return IntArray[index];
                }
            }
            set
            {
                if (index >= 0 && index < size)
                {
                    IntArray[index] = value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }

        // Перевантаження операторів
        public static VectorULong operator ++(VectorULong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector.IntArray[i]++;
            }
            return vector;
        }

        public static VectorULong operator --(VectorULong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector.IntArray[i]--;
            }
            return vector;
        }

        public static bool operator true(VectorULong vector)
        {
            if (vector.size == 0) return false;
            for (int i = 0; i < vector.size; i++)
            {
                if (vector.IntArray[i] == 0) return false;
            }
            return true;
        }

        public static bool operator false(VectorULong vector)
        {
            return !true;
        }

        public static VectorULong operator !(VectorULong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                if (vector.IntArray[i] == 0) vector.IntArray[i] = 1;
                else vector.IntArray[i] = 0;
            }
            return vector;
        }

        public static VectorULong operator ~(VectorULong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector.IntArray[i] = ~vector.IntArray[i];
            }
            return vector;
        }


        // Приклад перевантаження операції +
        public static VectorULong operator +(VectorULong vector1, VectorULong vector2)
        {
            uint maxSize = Math.Max(vector1.size, vector2.size);
            VectorULong result = new VectorULong(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result[i] = (i < vector1.size ? vector1[i] : 0) + (i < vector2.size ? vector2[i] : 0);
            }
            return result;
        }

        public static VectorULong operator +(VectorULong vector, ulong scalar)
        {
            VectorULong result = new VectorULong(vector.size);
            for (int i = 0; i < vector.size; i++)
            {
                result[i] = vector[i] + scalar;
            }
            return result;
        }


        // Перевантаження операції -
        public static VectorULong operator -(VectorULong vector1, VectorULong vector2)
        {
            uint maxSize = Math.Max(vector1.size, vector2.size);
            VectorULong result = new VectorULong(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result[i] = (i < vector1.size ? vector1[i] : 0) - (i < vector2.size ? vector2[i] : 0);
            }
            return result;
        }

        public static VectorULong operator -(VectorULong vector, ulong scalar)
        {
            VectorULong result = new VectorULong(vector.size);
            for (int i = 0; i < vector.size; i++)
            {
                result[i] = vector[i] - scalar;
            }
            return result;
        }



        // Перевантаження операції *
        public static VectorULong operator *(VectorULong vector1, VectorULong vector2)
        {
            uint maxSize = Math.Max(vector1.size, vector2.size);
            VectorULong result = new VectorULong(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result[i] = (i < vector1.size ? vector1[i] : 0) * (i < vector2.size ? vector2[i] : 0);
            }
            return result;
        }

        public static VectorULong operator *(VectorULong vector, ulong scalar)
        {
            VectorULong result = new VectorULong(vector.size);
            for (int i = 0; i < vector.size; i++)
            {
                result[i] = vector[i] * scalar;
            }
            return result;
        }

        // Приклад перевантаження операції /
        public static VectorULong operator /(VectorULong vector1, VectorULong vector2)
        {
            uint maxSize = Math.Max(vector1.size, vector2.size);
            VectorULong result = new VectorULong(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result[i] = (i < vector1.size ? vector1[i] : 0) / (i < vector2.size ? vector2[i] : 1);
            }
            return result;
        }

        public static VectorULong operator /(VectorULong vector, ulong scalar)
        {
            VectorULong result = new VectorULong(vector.size);
            for (int i = 0; i < vector.size; i++)
            {
                result[i] = vector[i] / scalar;
            }
            return result;
        }

        // Приклад перевантаження операції %
        public static VectorULong operator %(VectorULong vector1, VectorULong vector2)
        {
            uint maxSize = Math.Max(vector1.size, vector2.size);
            VectorULong result = new VectorULong(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result[i] = (i < vector1.size ? vector1[i] : 0) % (i < vector2.size ? vector2[i] : 1);
            }
            return result;
        }

        public static VectorULong operator %(VectorULong vector, ulong scalar)
        {
            VectorULong result = new VectorULong(vector.size);
            for (int i = 0; i < vector.size; i++)
            {
                result[i] = vector[i] % scalar;
            }
            return result;
        }

        // Приклад перевантаження операції |
        public static VectorULong operator |(VectorULong vector1, VectorULong vector2)
        {
            uint maxSize = Math.Max(vector1.size, vector2.size);
            VectorULong result = new VectorULong(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result[i] = (i < vector1.size ? vector1[i] : 0) | (i < vector2.size ? vector2[i] : 0);
            }
            return result;
        }

        public static VectorULong operator |(VectorULong vector, ulong scalar)
        {
            VectorULong result = new VectorULong(vector.size);
            for (int i = 0; i < vector.size; i++)
            {
                result[i] = vector[i] | scalar;
            }
            return result;
        }

        // Приклад перевантаження операції ^
        public static VectorULong operator ^(VectorULong vector1, VectorULong vector2)
        {
            uint maxSize = Math.Max(vector1.size, vector2.size);
            VectorULong result = new VectorULong(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result[i] = (i < vector1.size ? vector1[i] : 0) ^ (i < vector2.size ? vector2[i] : 0);
            }
            return result;
        }

        public static VectorULong operator ^(VectorULong vector, ulong scalar)
        {
            VectorULong result = new VectorULong(vector.size);
            for (int i = 0; i < vector.size; i++)
            {
                result[i] = vector[i] ^ scalar;
            }
            return result;
        }

        //// Приклад перевантаження операції >>
        //public static VectorULong operator >>(VectorULong vector, uint shift)
        //{
        //    VectorULong result = new VectorULong(vector.size);
        //    for (int i = 0; i < vector.size; i++)
        //    {
        //        result[i] = vector[i] >> (int)shift;
        //    }
        //    return result;
        //}

        //// Приклад перевантаження операції <<
        //public static VectorULong operator <<(VectorULong vector, uint shift)
        //{
        //    VectorULong result = new VectorULong(vector.size);
        //    for (int i = 0; i < vector.size; i++)
        //    {
        //        result[i] = vector[i] << (int)shift;
        //    }
        //    return result;
        //}

        // Перевантаження операцій рівності і нерівності
        public static bool operator ==(VectorULong vector1, VectorULong vector2)
        {
            if (vector1.size != vector2.size) return false;

            for (int i = 0; i < vector1.size; i++)
            {
                if (vector1[i] != vector2[i]) return false;
            }
            return true;
        }

        public static bool operator !=(VectorULong vector1, VectorULong vector2)
        {
            return !(vector1 == vector2);
        }

        // Перевантаження операцій порівняння
        public static bool operator >(VectorULong vector1, VectorULong vector2)
        {
            if (vector1.size != vector2.size) throw new ArgumentException("Vectors must have the same size");

            for (int i = 0; i < vector1.size; i++)
            {
                if (vector1[i] <= vector2[i]) return false;
            }
            return true;
        }

        public static bool operator <(VectorULong vector1, VectorULong vector2)
        {
            if (vector1.size != vector2.size) throw new ArgumentException("Vectors must have the same size");

            for (int i = 0; i < vector1.size; i++)
            {
                if (vector1[i] >= vector2[i]) return false;
            }
            return true;
        }

        public static bool operator >=(VectorULong vector1, VectorULong vector2)
        {
            return vector1 > vector2 || vector1 == vector2;
        }

        public static bool operator <=(VectorULong vector1, VectorULong vector2)
        {
            return vector1 < vector2 || vector1 == vector2;
        }

        
    }




    //////////////////////////////////////////////////////////////////////////////////////////////////////


    public class MatrixUlong
    {
        private ulong[,] ULArray;
        private uint n, m;
        private int codeError;
        private static int num_m;

        public MatrixUlong()
        {
            n = m = 1;
            ULArray = new ulong[n, m];
            num_m++;
        }

        public MatrixUlong(uint n, uint m)
        {
            this.n = n;
            this.m = m;
            ULArray = new ulong[n, m];
            num_m++;
        }

        public MatrixUlong(uint n, uint m, ulong initValue)
        {
            this.n = n;
            this.m = m;
            ULArray = new ulong[n, m];
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    ULArray[i, j] = initValue;
                }
            }
            num_m++;
        }

        ~MatrixUlong()
        {
            Console.WriteLine("Деструктор викликаний");
        }

        public void Input()
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.WriteLine($"Введіть елемент з індексом ({i}, {j}): ");
                    ULArray[i, j] = Convert.ToUInt64(Console.ReadLine());
                }
            }
        }

        public void Display()
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write($"{ULArray[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void SetValue(ulong value)
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    ULArray[i, j] = value;
                }
            }
        }

        public static int GetNumMatrix()
        {
            return num_m;
        }

        public ulong this[uint i, uint j]
        {
            get
            {
                if (i >= n || j >= m)
                {
                    codeError = -1;
                    return 0;
                }
                else
                {
                    return ULArray[i, j];
                }
            }
            set
            {
                if (i >= n || j >= m)
                {
                    codeError = -1;
                }
                else
                {
                    ULArray[i, j] = value;
                }
            }
        }


       

        // Унарні операції ++ та --
        public static MatrixUlong operator ++(MatrixUlong matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix[i, j]++;
                }
            }
            return matrix;
        }

        public static MatrixUlong operator --(MatrixUlong matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix[i, j]--;
                }
            }
            return matrix;
        }

        // Сталі true та false
        public static bool operator true(MatrixUlong matrix)
        {
            if (matrix.n != 0 && matrix.m != 0)
            {
                for (uint i = 0; i < matrix.n; i++)
                {
                    for (uint j = 0; j < matrix.m; j++)
                    {
                        if (matrix[i, j] == 0)
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool operator false(MatrixUlong matrix)
        {
            if (matrix.n == 0 || matrix.m == 0)
                return true;

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    if (matrix[i, j] == 0)
                        return true;
                }
            }
            return false;
        }

        // Унарна логічна операція !
        public static bool operator !(MatrixUlong matrix)
        {
            return (matrix.n == 0 || matrix.m == 0 || !matrix);
        }

        // Унарна побітова операція ~
        public static MatrixUlong operator ~(MatrixUlong matrix)
        {
            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = ~matrix[i, j];
                }
            }
            return result;
        }

        // Арифметичні бінарні операції
        // a. + додавання
        public static MatrixUlong operator +(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Розміри матриць не співпадають!");
                return null;
            }

            MatrixUlong result = new MatrixUlong(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        public static MatrixUlong operator +(MatrixUlong matrix, ulong scalar)
        {
            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] + scalar;
                }
            }
            return result;
        }

        public static MatrixUlong operator +(ulong scalar, MatrixUlong matrix)
        {
            return matrix + scalar;
        }

        // b. - віднімання
        public static MatrixUlong operator -(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Розміри матриць не співпадають!");
                return null;
            }

            MatrixUlong result = new MatrixUlong(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return result;
        }

        public static MatrixUlong operator -(MatrixUlong matrix, ulong scalar)
        {
            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] - scalar;
                }
            }
            return result;
        }

        public static MatrixUlong operator -(ulong scalar, MatrixUlong matrix)
        {
            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = scalar - matrix[i, j];
                }
            }
            return result;
        }

        // c. * множення
        // i. для двох матриць
        public static MatrixUlong operator *(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.m != matrix2.n)
            {
                Console.WriteLine("Неможливо виконати множення матриць: кількість стовпців першої матриці не співпадає з кількістю рядків другої матриці!");
                return null;
            }

            MatrixUlong result = new MatrixUlong(matrix1.n, matrix2.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix2.m; j++)
                {
                    for (uint k = 0; k < matrix1.m; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }

        //// ii. для матриці та вектора VectorULong
        //public static VectorULong operator *(MatrixUlong matrix, VectorULong vector)
        //{
        //    if (matrix.m != vector.Size)
        //    {
        //        Console.WriteLine("Неможливо виконати множення: кількість стовпців матриці не співпадає з розміром вектора!");
        //        return null;
        //    }

        //    VectorULong result = new VectorULong(matrix.n);
        //    for (uint i = 0; i < matrix.n; i++)
        //    {
        //        for (uint j = 0; j < matrix.m; j++)
        //        {
        //            result[i] += matrix[i, j] * vector[j];
        //        }
        //    }
        //    return result;
        //}

        // iii. для матриці та скаляра типу ulong
        public static MatrixUlong operator *(MatrixUlong matrix, ulong scalar)
        {
            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }
            return result;
        }

        public static MatrixUlong operator *(ulong scalar, MatrixUlong matrix)
        {
            return matrix * scalar;
        }

        // d. / (ділення)
        // i. для двох матриць
        public static MatrixUlong operator /(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Розміри матриць не співпадають!");
                return null;
            }

            MatrixUlong result = new MatrixUlong(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix2[i, j] != 0)
                    {
                        result[i, j] = matrix1[i, j] / matrix2[i, j];
                    }
                    else
                    {
                        Console.WriteLine($"Ділення на нуль у позиції ({i}, {j})!");
                        return null;
                    }
                }
            }
            return result;
        }

        // ii. для матриці та скаляра типу ulong;
        public static MatrixUlong operator /(MatrixUlong matrix, ulong scalar)
        {
            if (scalar == 0)
            {
                Console.WriteLine("Ділення на нуль!");
                return null;
            }

            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] / scalar;
                }
            }
            return result;
        }

        public static MatrixUlong operator /(ulong scalar, MatrixUlong matrix)
        {
            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        result[i, j] = scalar / matrix[i, j];
                    }
                    else
                    {
                        Console.WriteLine($"Ділення на нуль у позиції ({i}, {j})!");
                        return null;
                    }
                }
            }
            return result;
        }


        // e. % (остача від ділення)
        // i. для двох матриць
        public static MatrixUlong operator %(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Розміри матриць не співпадають!");
                return null;
            }

            MatrixUlong result = new MatrixUlong(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix2[i, j] != 0)
                    {
                        result[i, j] = matrix1[i, j] % matrix2[i, j];
                    }
                    else
                    {
                        Console.WriteLine($"Ділення на нуль у позиції ({i}, {j})!");
                        return null;
                    }
                }
            }
            return result;
        }

        // ii. для матриці та скаляра типу ulong;
        public static MatrixUlong operator %(MatrixUlong matrix, ulong scalar)
        {
            if (scalar == 0)
            {
                Console.WriteLine("Ділення на нуль!");
                return null;
            }

            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] % scalar;
                }
            }
            return result;
        }

        public static MatrixUlong operator %(ulong scalar, MatrixUlong matrix)
        {
            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        result[i, j] = scalar % matrix[i, j];
                    }
                    else
                    {
                        Console.WriteLine($"Ділення на нуль у позиції ({i}, {j})!");
                        return null;
                    }
                }
            }
            return result;
        }


        // побітові бінарні операції
        // a. | (побітове додавання)
        // i. для двох матриць
        public static MatrixUlong operator |(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Розміри матриць не співпадають!");
                return null;
            }

            MatrixUlong result = new MatrixUlong(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] | matrix2[i, j];
                }
            }
            return result;
        }

        // ii. для матриці та скаляра типу ulong;
        public static MatrixUlong operator |(MatrixUlong matrix, ulong scalar)
        {
            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] | scalar;
                }
            }
            return result;
        }

        public static MatrixUlong operator |(ulong scalar, MatrixUlong matrix)
        {
            return matrix | scalar;
        }

        // b. ^ (побітове додавання за модулем 2)
        // i. для двох матриць
        public static MatrixUlong operator ^(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Розміри матриць не співпадають!");
                return null;
            }

            MatrixUlong result = new MatrixUlong(matrix1.n, matrix1.m);
            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] ^ matrix2[i, j];
                }
            }
            return result;
        }

        // ii. для матриці та скаляра типу ulong;
        public static MatrixUlong operator ^(MatrixUlong matrix, ulong scalar)
        {
            MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] ^ scalar;
                }
            }
            return result;
        }

        public static MatrixUlong operator ^(ulong scalar, MatrixUlong matrix)
        {
            return matrix ^ scalar;
        }

        //// c. | (побітове множення)
        //// i. двох векторів
        //public static MatrixUlong operator |(MatrixUlong matrix1, MatrixUlong matrix2)
        //{
        //    if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        //    {
        //        Console.WriteLine("Розміри матриць не співпадають!");
        //        return null;
        //    }

        //    MatrixUlong result = new MatrixUlong(matrix1.n, matrix1.m);
        //    for (uint i = 0; i < matrix1.n; i++)
        //    {
        //        for (uint j = 0; j < matrix1.m; j++)
        //        {
        //            result[i, j] = matrix1[i, j] | matrix2[i, j];
        //        }
        //    }
        //    return result;
        //}

        //// ii. вектора і скаляра типу ulong;
        //public static MatrixUlong operator |(MatrixUlong matrix, ulong scalar)
        //{
        //    MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
        //    for (uint i = 0; i < matrix.n; i++)
        //    {
        //        for (uint j = 0; j < matrix.m; j++)
        //        {
        //            result[i, j] = matrix[i, j] | scalar;
        //        }
        //    }
        //    return result;
        //}

        //public static MatrixUlong operator |(ulong scalar, MatrixUlong matrix)
        //{
        //    MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
        //    for (uint i = 0; i < matrix.n; i++)
        //    {
        //        for (uint j = 0; j < matrix.m; j++)
        //        {
        //            result[i, j] = scalar | matrix[i, j];
        //        }
        //    }
        //    return result;
        //}
        // d. >> (побітовий зсув право)
        // i. для двох матриць
        //public static MatrixUlong operator >>(MatrixUlong matrix1, MatrixUlong matrix2)
        //{
        //    if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        //    {
        //        Console.WriteLine("Розміри матриць не співпадають!");
        //        return null;
        //    }

        //    MatrixUlong result = new MatrixUlong(matrix1.n, matrix1.m);
        //    for (uint i = 0; i < matrix1.n; i++)
        //    {
        //        for (uint j = 0; j < matrix1.m; j++)
        //        {
        //            result[i, j] = matrix1[i, j] >> (int)matrix2[i, j];
        //        }
        //    }
        //    return result;
        //}

        //// ii. для матриці та скаляра типу ulong;
        //public static MatrixUlong operator >>(MatrixUlong matrix, ushort shift)
        //{
        //    MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
        //    for (uint i = 0; i < matrix.n; i++)
        //    {
        //        for (uint j = 0; j < matrix.m; j++)
        //        {
        //            result[i, j] = matrix[i, j] >> shift;
        //        }
        //    }
        //    return result;
        //}

        //// e. << (побітовий зсув ліво)
        //// i. для двох матриць
        //public static MatrixUlong operator <<(MatrixUlong matrix1, MatrixUlong matrix2)
        //{
        //    if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        //    {
        //        Console.WriteLine("Розміри матриць не співпадають!");
        //        return null;
        //    }

        //    MatrixUlong result = new MatrixUlong(matrix1.n, matrix1.m);
        //    for (uint i = 0; i < matrix1.n; i++)
        //    {
        //        for (uint j = 0; j < matrix1.m; j++)
        //        {
        //            result[i, j] = matrix1[i, j] << (int)matrix2[i, j];
        //        }
        //    }
        //    return result;
        //}

        //// ii. для матриці та скаляра типу ulong;
        //public static MatrixUlong operator <<(MatrixUlong matrix, ushort shift)
        //{
        //    MatrixUlong result = new MatrixUlong(matrix.n, matrix.m);
        //    for (uint i = 0; i < matrix.n; i++)
        //    {
        //        for (uint j = 0; j < matrix.m; j++)
        //        {
        //            result[i, j] = matrix[i, j] << shift;
        //        }
        //    }
        //    return result;
        //}

        // операцій ==(рівності) та != (нерівності)
        public static bool operator ==(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                return false;

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                        return false;
                }
            }
            return true;
        }

        public static bool operator !=(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            return !(matrix1 == matrix2);
        }

        // порівняння
        public static bool operator >(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                throw new ArgumentException("Матриці мають різний розмір");

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] <= matrix2[i, j])
                        return false;
                }
            }
            return true;
        }

        public static bool operator <(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                throw new ArgumentException("Матриці мають різний розмір");

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] >= matrix2[i, j])
                        return false;
                }
            }
            return true;
        }

        public static bool operator >=(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                throw new ArgumentException("Матриці мають різний розмір");

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] < matrix2[i, j])
                        return false;
                }
            }
            return true;
        }

        public static bool operator <=(MatrixUlong matrix1, MatrixUlong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
                throw new ArgumentException("Матриці мають різний розмір");

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] > matrix2[i, j])
                        return false;
                }
            }
            return true;
        }

    }
}

