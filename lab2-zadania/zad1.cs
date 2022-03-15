using System;

namespace zad1
{
    class zad1
    {
        static void Main()
        {
            int[] oceny = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine(suma(oceny));

            int suma(int[] tablica)
            {
                int l = tablica.Length;
                int suma = 0;

                for (int i = 0; i < l; i++)
                {
                    suma += tablica[i];
                }
                return suma;

            }
        }
    }
}


