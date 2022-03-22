using System;

namespace Lab_4
{
    class ZadaniaSortowania
    {

        //ZADANIE 2
        void Insertionsort(int[] arr)
        {
            int dlugosc = arr.Length;
            for (int i = 1; i < dlugosc; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        // ZADANIE 4
        void Selectionsort(int[] arr)
        {
            int dlugosc = arr.Length;

            for (int i = 0; i < dlugosc - 1; i++)
            {
                // Znajduje minimalny element
                int minElement = i;
                for (int j = i + 1; j < dlugosc; j++)
                    if (arr[j] > arr[minElement])
                        minElement = j;

                // Zamiana elementów
                int t = arr[minElement];
                arr[minElement] = arr[i];
                arr[i] = t;
            }
        }

        static void printArray(int[] arr)
        {
            int dlugosc = arr.Length;
            for (int i = 0; i < dlugosc; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        public static void Main()
        {
            int[] arr = { 12, 11, 13, 5, 6, 100, 1};
            ZadaniaSortowania ob = new ZadaniaSortowania();

            //WYPISYWANIE TABLICY
            ob.Insertionsort(arr);
            Console.WriteLine("Tablica InsertionSort: ");
            printArray(arr);

            ob.Selectionsort(arr);
            Console.WriteLine("\nTablica SelectionSort: ");
            printArray(arr);
            
            
            


            //LEKCJA
            string str = "abcd";
            //Console.WriteLine(str.CompareTo("abce"));
            string[] tablica = { "hbcd", "anc", "eiru", "oiewo" };
            Array.Sort(tablica);
            Console.WriteLine("\nTablica wyznaczona alfabetycznie: \n"+string.Join(", ", tablica));

        }
    }
}
