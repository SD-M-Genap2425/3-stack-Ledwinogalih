using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Palindrome
{
    public static class PalindromeChecker
    {
        public static bool CekPalindrom(string input)
        {
            string normalized = new string(input.ToLower().Where(c => Char.IsLetter(c)).ToArray());
            if(string.IsNullOrEmpty(normalized)){
                return true;
            }

            Stack<char> charStack = new Stack<char>();

            foreach(char c in normalized)
            {
                charStack.Push(c);
            }
            foreach(char c in normalized)
            {
                if(c != charStack.Pop())
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Program
    {
        public static void Main()
        {
            TestPalindrom("Kasur ini rusak");         // true
            TestPalindrom("Ibu Ratna antar ubi");     // true
            TestPalindrom("Hello World");             // false
            TestPalindrom("A man, a plan, a canal: Panama");  // true
            TestPalindrom("");                        // true
        }

        private static void TestPalindrom(string input)
        {
            Console.WriteLine($"\"{input}\" => {PalindromeChecker.CekPalindrom(input)}");
        }
    }
}
