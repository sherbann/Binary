using System.Text;

namespace CP
{
    // Requirements:
    //  You must work with 16 bits, hint: Use an int array of 16 as a field
    //  Binary operators: ~, <<, >>
    //  Binary, Arithmatic, and Logical operators: +, -, *, /, ==, !=, <, >, <=, >= algorithms
    //      must perform in binary. 

    class Binary
    {
        #region(Fields)
        public int[] bits = new int[16];
        public int[] largeBits = new int[32];
        private double re, im;
        #endregion
        #region(Properties)
        public int[] Bits
        {
            get { return bits; }
            set { bits = value; }
        }
        public int[] LargeBits
        {
            get { return bits; }
            set { bits = value; }
        }
        public int[] Equal
        {
            get;
            set;
        }

        #endregion
        #region(Constructor)
        public Binary() { }
        #endregion
        #region(Index operator)       
        public int this[int index]
        {
            get
            {
                //if (index < 0 || index >= bits.Length)
                //    throw new IndexOutOfRangeException("Index out of range");

                return bits[index];
            }

            set
            {
                //if (index < 0 || index >= bits.Length)
                //    throw new IndexOutOfRangeException("Index out of range");

                bits[index] = value;
            }
        }
        #endregion
        #region(Implicit Convertors: int to Binary, Binary to int)
        public static implicit operator Binary(int x)
        {
            Binary binary = new();
            if (x >= 0)
            {
                string toBinaryPositive = Convert.ToString(x, 2).PadLeft(16, '0');
                for (int i = 0; i < toBinaryPositive.Length; i++)
                {
                    binary.Bits[i] = Convert.ToInt16(toBinaryPositive[i].ToString());
                }
                return binary;
            }
            else
            {
                string toBinaryNegative = Convert.ToString(-x, 2).PadLeft(16, '0');
                Binary one = new();
                one.Bits[toBinaryNegative.Length - 1] = 1;
                for (int i = 0; i < toBinaryNegative.Length; i++)
                {
                    binary.Bits[i] = Convert.ToInt16(toBinaryNegative[i].ToString());
                }
                binary = ~binary;
                binary = binary + one;
                return binary;
            }

        }

        public static implicit operator int(Binary x)
        {
            int output = 0;
            int base1 = 1;

            if (x.Bits[0] == 1)
            {
                Binary firstCompl = new();
                Binary secondCompl = new();
                Binary one = new Binary();
                one.Bits[x.Bits.Length - 1] = 1;
                firstCompl = ~x;
                secondCompl = firstCompl + one;
                for (int i = secondCompl.Bits.Length - 1; i > 0; i--)
                {
                    output = output + (secondCompl.Bits[i] * base1);
                    base1 *= 2;
                }
                return -output;
            }
            else
            {
                for (int i = x.Bits.Length - 1; i > 0; i--)
                {
                    output = output + (x.Bits[i] * base1);
                    base1 *= 2;
                }
                return output;
            }
        }
        #endregion
        #region(Methods: ToDecimal, ToString)
        public override string ToString()
        {
            int count = 0;
            StringBuilder output = new();
            for (int i = 0; i < Bits.Length; i++)
            {
                output.Append(Bits[i]);
                count++;
                if (count % 4 == 0)
                {
                    output.Append(' ');
                }
            }
            return output.ToString();
        }
        public int ToDecimal()
        {
            int output = 0;
            int base1 = 1; // i.e 2^0
            if (this[0] == 0)
            {
                for (int i = this.Bits.Length - 1; i > 0; i--)
                {
                    output = output + (this.Bits[i] * base1);
                    base1 *= 2;
                }

                return output;
            }
            else
            {
                Binary firstCompl = new();
                Binary secondCompl = new();
                Binary one = new Binary();
                one.Bits[Bits.Length - 1] = 1;
                firstCompl = ~this;
                secondCompl = firstCompl + one;
                for (int i = secondCompl.Bits.Length - 1; i > 0; i--)
                {
                    output = output + (secondCompl.Bits[i] * base1);
                    base1 *= 2;
                }
                return -output;
            }

            //return output;
        }
        #endregion
        #region(Shift Opertors: Shift to left by n (<<), Shift to right by n (>>))
        public static Binary operator <<(Binary binary, int shiftNumber)
        {
            Binary result = new();
            for (int i = binary.Bits.Length - 1; i >= 0; i--)
            {
                if (i > (binary.Bits.Length - 1 - shiftNumber))
                {
                    result.Bits[i] = 0;
                }
                else
                    result.Bits[i] = binary.Bits[i + shiftNumber];
            }
            return result;
        }
        public static Binary operator >>(Binary binary, int shiftNumber)
        {
            Binary result = new();
            for (int i = 0; i < binary.Bits.Length; i++)
            {
                if (i + shiftNumber < binary.Bits.Length)
                {
                    result.Bits[i + shiftNumber] = binary.Bits[i];
                }
                else
                    result.Bits[binary.Bits.Length - i] = 0;
            }
            return result;
        }
        #endregion
        #region(Binary Operators: Ones' complement, Negation)
        public static Binary operator ~(Binary x)
        {
            Binary result = new();
            //x.bits = result.bits;
            for (int i = 0; i < x.Bits.Length; i++)
            {

                if (x.Bits[i] > 0)
                {
                    result.Bits[i] = 0;
                }
                else
                {
                    result.Bits[i] = 1;
                }

            }
            //Console.WriteLine(result);
            return result;

        }
        public static Binary operator -(Binary x)
        {
            Binary result = new();
            Binary one = new Binary();
            one.Bits[x.Bits.Length - 1] = 1;
            x = ~x;
            result = x + one;
            return result;
        }
        #endregion
        #region(Binary Arithmatic Opertors: +, -, * )
        public static Binary operator +(Binary binary1, Binary binary2)
        {
            Binary result = new Binary();
            int carriedDigit = 0;
            for (int i = binary1.Bits.Length - 1; i >= 0; i--)
            {
                if (binary2.Bits[i] == 1 && binary1.Bits[i] == 1 && carriedDigit == 0)
                {
                    result.Bits[i] = 0;
                    carriedDigit = 1;
                    continue;
                }
                if (binary2.Bits[i] == 1 && binary1.Bits[i] == 1 && carriedDigit == 1)
                {
                    result.Bits[i] = 1;
                    carriedDigit = 1;
                    continue;
                }
                if (binary2.Bits[i] == 0 && binary1.Bits[i] == 0 && carriedDigit == 0)
                {
                    result.Bits[i] = 0;
                    carriedDigit = 0;
                    continue;
                }
                if (binary2.Bits[i] == 0 && binary1.Bits[i] == 0 && carriedDigit == 1)
                {
                    result.Bits[i] = 1;
                    carriedDigit = 0;
                    continue;
                }
                if (binary2.Bits[i] != binary1.Bits[i] && carriedDigit == 0)
                {
                    result.Bits[i] = 1;
                    carriedDigit = 0;
                    continue;
                }
                if (binary2.Bits[i] != binary1.Bits[i] && carriedDigit == 1)
                {
                    result.Bits[i] = 0;
                    carriedDigit = 1;
                    continue;
                }
            }

            return result;
        }
        public static Binary operator -(Binary binary1, Binary binary2)
        {
            Binary result = new Binary();
            Binary one = new Binary();
            one.Bits[result.Bits.Length - 1] = 1;
            int carriedDigit = 0;
            binary2 = ~binary2;
            for (int i = binary1.Bits.Length - 1; i >= 0; i--)
            {
                //int carriedDigit = 0;
                if (binary2.Bits[i] == 1 && binary1.Bits[i] == 1 && carriedDigit == 0)
                {
                    result.Bits[i] = 0;
                    carriedDigit = 1;
                    continue;
                }
                if (binary2.Bits[i] == 1 && binary1.Bits[i] == 1 && carriedDigit == 1)
                {
                    result.Bits[i] = 1;
                    carriedDigit = 1;
                    continue;
                }
                if (binary2.Bits[i] == 0 && binary1.Bits[i] == 0 && carriedDigit == 0)
                {
                    result.Bits[i] = 0;
                    carriedDigit = 0;
                    continue;
                }
                if (binary2.Bits[i] == 0 && binary1.Bits[i] == 0 && carriedDigit == 1)
                {
                    result.Bits[i] = 1;
                    carriedDigit = 0;
                    continue;
                }
                if (binary2.Bits[i] != binary1.Bits[i] && carriedDigit == 0)
                {
                    result.Bits[i] = 1;
                    carriedDigit = 0;
                    continue;
                }
                if (binary2.Bits[i] != binary1.Bits[i] && carriedDigit == 1)
                {
                    result.Bits[i] = 0;
                    carriedDigit = 1;
                    continue;
                }
            }
            return result + one;
        }
        public static Binary operator *(Binary binary1, Binary binary2)
        {
            Binary tempResult = new();
            Binary finalResult = new();
            for (int i = 0; i < binary1.Bits.Length; i++)
            {
                for (int j = 0; j < binary1.Bits.Length; j++)
                {
                    tempResult[j] = binary1[j] * binary2[i];
                }
                if (i == 0) { finalResult = tempResult; }
                finalResult += finalResult + tempResult;
            }
            return finalResult;
        }

        #endregion
        #region(Logical Operators: ==, !=, <, >, <=, >=)
        public static bool operator ==(Binary x, Binary y)
        {
            int count = 0;
            if (x.bits.Length != y.bits.Length)
            {
                return false;
            }
            for (int i = 0; i < x.bits.Length; i++)
            {
                if (x[i] == y[i])
                {
                    count++;
                }
            }
            if (count == x.bits.Length)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Binary x, Binary y)
        {
            int count = 0;
            if (x.bits.Length != y.bits.Length)
            {
                return true;
            }
            for (int i = 0; i < x.bits.Length; i++)
            {
                if (x[i] != y[i])
                {
                    count++;
                }
            }
            if (count != x.bits.Length)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Binary binary1, Binary binary2)
        {

            if (binary1.Bits[0] > binary2.Bits[0])
            {
                return true;
            }
            if (binary1.Bits[0] < binary2.Bits[0])
            {
                return false;
            }
            for (int i = 1; i < binary1.Bits.Length - 1; i++)
                if (binary1.Bits[i] < binary2.Bits[i])
                {
                    return true;
                }
            return false;
        }
        public static bool operator >(Binary binary1, Binary binary2)
        {

            if (binary1.Bits[0] < binary2.Bits[0])
            {
                return true;
            }
            if (binary1.Bits[0] > binary2.Bits[0])
            {
                return false;
            }
            for (int i = 0; i < binary1.Bits.Length - 1; i++)
                if (binary1.Bits[i] > binary2.Bits[i])
                {
                    return true;
                }

            return false;
        }
        public static bool operator <=(Binary binary1, Binary binary2)
        {
            if (binary1 < binary2)
            {
                return true;
            }
            if (binary1 == binary2)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(Binary binary1, Binary binary2)
        {
            if (binary1 > binary2)
            {
                return true;
            }
            if (binary1 == binary2)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
