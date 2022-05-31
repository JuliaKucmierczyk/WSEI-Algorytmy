using System;
using System.Collections.Generic;
using System.Linq;

namespace ćwiczenia
{
    class Program
    {
        static void Main(string[] args)
        {
            // tworzymy testy
            int points = 0;
            if (IsPalindrome("a") && IsPalindrome("aaa") && IsPalindrome("") && IsPalindrome("zakaz"))
            {
                Console.WriteLine("Zadanie 1: Dobrze");
                points++;
            }
            if(IsAnagrams("abcd","dcba") && IsAnagrams("aa","aa") && !IsAnagrams("AA","aa") && IsAnagrams("","") && !IsAnagrams("abc","abca"))
            {
                Console.WriteLine("Zadanie 2: Dobrze");
                points++;
            }
            if (LongestIndenticalString("aaaa").Equals("aaaa") && LongestIndenticalString("abcddddaaddd").Equals("dddd") && LongestIndenticalString("abcd").Equals("a") && LongestIndenticalString("abbcdd").Equals("bb"))
            {
                Console.WriteLine("Zadanie 3: Dobrze");
                points++;
            }



        }

        // czy input jest palindromem
        public static bool IsPalindrome(string input)
        {
            return input.SequenceEqual(input.Reverse());
        }

        // czy łańcuchy są anagramami
        public static bool IsAnagrams(string a, string b)
        {
            return String.Concat(a.OrderBy(c => c)).Equals(String.Concat(b.OrderBy(c => c)));
        }

        // zwróć najdłuższy fragment złożony z unikalnych znaków wejścia
        public static string LongestIndenticalString(string input)
        {
            var list = new List<string>();
            var counter = 0;
            var rep = "";

            for (int i = 0; i < input.Length; i++)
            {
                rep = "";
                for (int k = i; k < input.Length; k++)
                {
                    counter = 0;
                    rep += input[k];
                    var startIndex = 0;
                    var indexOf = int.MinValue;
                    while ((indexOf = input.IndexOf(rep, startIndex)) >= 0)
                    {
                        counter++;
                        startIndex = indexOf + 1;
                        if (counter > 1) break;
                    }

                    if (counter > 1)
                    {
                        list.Add(rep);
                    }
                }
            }

            return list.OrderByDescending(x => x.Length).FirstOrDefault();

            // jeszcze nie działa
        }
    }
}
