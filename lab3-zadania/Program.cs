using System;

namespace lab3_zadania
{
    
    public class CashRegister
    {
        static readonly int ONE = 0;
        static readonly int TWO = 1;
        static readonly int FIVE = 2;
        private readonly int[] coins = new int[3];

        public CashRegister(int[] coins)
        {
            this.coins = coins;
        }
        int[] Payment(int[] income, int amount)
        {
            if (amount > getAmount(income))
            {
                return new int[] { };
            }
            //POZOSTAŁE WARUNKI uniemożliwiające obliczenie reszty jak ujemne amount, ujemna liczba monet itd;
            if (amount < 0)
            {
                throw new ArgumentException("amount mniejsze od 0");
            }
            throw new NotImplementedException();
        }

        private int getAmount(int[] coins)
        {
            return coins[ONE] + coins[TWO] * 2 + coins[FIVE] * 4;
        }

        
    }

    /// <summary>
    /// NIEŹLE
    /// </summary>
    static class SinTable
    {
        static private double[] sinTable;
        static readonly int MAX = 360;
        static SinTable()
        {
            sinTable = new double[MAX];
            for(int i = 0; i < MAX; i++)
            {
                sinTable[i] = Math.Sin(i * Math.PI / 180); 
            }
        }
        public static double Sin(int degree)
        {
            if (degree > 0)
            {
                return sinTable[degree % MAX];
            }else
            {
                return -sinTable[-degree % MAX];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fibonacci(42));
            //SinTable test
            Console.WriteLine(SinTable.Sin(0) == 0);
            Console.WriteLine(SinTable.Sin(90) == 1);
            Console.WriteLine(SinTable.Sin(180) == 0);
            Console.WriteLine(SinTable.Sin(-90) == -1);
            Console.WriteLine(SinTable.Sin(-180) == 0);
            Console.WriteLine(SinTable.Sin(270) == -1);
            Console.WriteLine(SinTable.Sin(-270) == 1);
            Console.WriteLine(SinTable.Sin(-360) == 0);
        }

        public static long fibonacci(int n)
        {
            long[] mem = new long[n];
            Array.Fill<long>(mem, -1);
            return fib(n, mem);
        }

        static long fib(int n, long[] mem)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;   
            }
            long fib1; //odpowiednik fib(n-1)
            long fib2; //odpowiednik fib(n-2)

            if (mem[n-1] == -1)
            {
                mem[n - 1] = fib(n - 1, mem);
            }
            if (mem[n - 2] == -1)
            {
                mem[n - 2] = fib(n - 2, mem);
            }
            return mem[n - 1] + mem[n - 2];
        }
    }
}
