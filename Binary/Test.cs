//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace CP
{
    internal static class Test
    {

        public static void ShiftOperatorTest()
        {
            Console.WriteLine("------------------Shift Operator Test------------------");

            Console.WriteLine("assigning 1010 to x");
            Binary x = 0b1010;   // Notation for literals:  0x-Hex   0b-Binary

            Console.WriteLine("printing x (0000 0000 0000 1010): {0}", x);

            Console.WriteLine("shifting x by 4 places to the left"); x <<= 4;
            Console.WriteLine("printing x (0000 0000 1010 0000): {0}", x);

            Console.WriteLine("shifting x 4 places to the right"); x >>= 4;
            Console.WriteLine("printing x (0000 0000 0000 1010): {0}", x);

            Console.WriteLine("shifting x 12 places to the left"); x <<= 12;
            Console.WriteLine("printing x (1010 0000 0000 0000): {0}", x);

            Console.WriteLine("shifting x 4 places to the left"); x <<= 4;
            Console.WriteLine("printing x (0000 0000 0000 0000): {0}", x);

            Console.WriteLine();
        }

        public static void UnayOperatorTest()
        {
            Console.WriteLine("------------------Unary Operator Test------------------");

            Console.WriteLine("assigning 1010 to x");
            Binary x = 0b1010;

            Console.WriteLine("printing x (0000 0000 0000 1010): {0}", x);
            Console.WriteLine("printing x in decimal (10): {0}", x.ToDecimal());

            Console.WriteLine("1's complement: printing ~x (1111 1111 1111 0101): {0}", ~x);
            Console.WriteLine("printing ~x in decimal (-11): {0}", (~x).ToDecimal());

            Console.WriteLine("2's complement: printing -x (1111 1111 1111 0110): {0}", -x);
            Console.WriteLine("printing -x in decimal (-10): {0}", (-x).ToDecimal());

            Console.WriteLine();
        }


        public static void ArithmeticOperatorTest()
        {
            Console.WriteLine("----------------Arithmetic Operator Test----------------");

            Console.WriteLine("assigning 10 to x");
            Binary x = 10;
            Console.WriteLine("assigning -12 to y");
            Binary y = -12;

            Console.WriteLine("printing x (0000 0000 0000 1010): {0}", x);
            Console.WriteLine("printing x in decimal (10): {0}", x.ToDecimal());
            Console.WriteLine("printing y (1111 1111 1111 0100): {0}", y);
            Console.WriteLine("printing y in decimal (-12): {0}", y.ToDecimal());

            Console.WriteLine("printing x + y (1111 1111 1111 1110): {0}", x + y);
            Console.WriteLine("printing x + y in decimal (-2): {0}", (x + y).ToDecimal());

            Console.WriteLine("printing x - y (0000 0000 0001 0110): {0}", x - y);
            Console.WriteLine("printing x - y in decimal (22): {0}", (x - y).ToDecimal());

            Console.WriteLine("printing x * y (1111 1111 1000 1000): {0}", x * y);
            Console.WriteLine("printing x * y in decimal (-120): {0}", (x * y).ToDecimal());

            Console.WriteLine("printing -x * y (0000 0000 0111 1000): {0}", -x * y);
            Console.WriteLine("printing -x * y in decimal (120): {0}", (-x * y).ToDecimal());


        }


        public static void RelationalOperatorTest()
        {
            Console.WriteLine("----------------Relational Operator Test----------------");

            Console.WriteLine("assigning 10 to x");
            Binary x = 10;
            Console.WriteLine("assigning -12 to y");
            Binary y = -12;
            Console.WriteLine("assigning 2 to z");
            Binary z = 2;

            Console.WriteLine("printing x (0000 0000 0000 1010): {0}", x);
            Console.WriteLine("printing x in decimal (10): {0}", x.ToDecimal());
            Console.WriteLine("printing y (1111 1111 1111 0100): {0}", y);
            Console.WriteLine("printing y in decimal (-12): {0}", y.ToDecimal());
            Console.WriteLine("printing z (0000 0000 0000 0010): {0}", z);
            Console.WriteLine("printing z in decimal (2): {0}", z.ToDecimal());

            Console.WriteLine("printing x == y (False): {0}", x == y);
            Console.WriteLine("printing x != y (True): {0}", x != y);
            Console.WriteLine("printing -x - z == y (True): {0}", -x - z == y);

            Console.WriteLine("printing x < y (False): {0}", x < y);
            Console.WriteLine("printing y < x (True): {0}", y < x);
            Console.WriteLine("printing x < z (False): {0}", x < z);
            Console.WriteLine("printing z < x (True): {0}", z < x);
            Console.WriteLine("printing -x < x + y (True): {0}", -x < x + y);

            Console.WriteLine("printing x > y (True): {0}", x > y);
            Console.WriteLine("printing y > x (False): {0}", y > x);
            Console.WriteLine("printing x > z (True): {0}", x > z);
            Console.WriteLine("printing z > x (False): {0}", z > x);
            Console.WriteLine("printing -z > x + y (False): {0}", -z > x + y);

            Console.WriteLine("printing x <= y (False): {0}", x <= y);
            Console.WriteLine("printing x >= y (True): {0}", x >= y);
            Console.WriteLine("printing -z <= x + y (True): {0}", -z <= x + y);
            Console.WriteLine("printing -z >= x + y (True): {0}", -z >= x + y);

            Console.WriteLine();
        }
    }
}
