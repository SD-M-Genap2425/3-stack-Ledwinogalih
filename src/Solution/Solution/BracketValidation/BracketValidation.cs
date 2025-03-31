using System;
using System.Collections.Generic;

namespace Solution.BracketValidation
{
    public class BracketValidator
    {
        private Node? top;
        
        private class Node
        {
            public char Value;
            public Node? Next;
            
            public Node(char value)
            {
                Value = value;
                Next = null;
            }
        }

        public bool ValidasiEkspresi(string ekspresi)
        {
            top = null;
            var bracketPairs = new Dictionary<char, char>{ 
                { ')', '(' }, 
                { '}', '{' }, 
                { ']', '[' } 
            };

            foreach(char c in ekspresi)
            {
                if(c == '(' || c == '{' || c == '[')
                {
                    Push(c);
                }
                else if(bracketPairs.ContainsKey(c))
                {
                    if(IsEmpty()){ 
                        return false;
                    }
                    if(Pop() != bracketPairs[c]){ return false;
                    }
                }
            }
            return IsEmpty();
        }

        private void Push(char value)
        {
            Node newNode = new Node(value);
            newNode.Next = top;
            top = newNode;
        }

        private char Pop()
        {
            if (IsEmpty())
            {
                return '\0';
            }

            if (top != null)
            {
                char value = top.Value;
                top = top.Next;
                return value;
            }
            else{
                return '\0';
            }
        }


        private bool IsEmpty()
        {
            return top == null;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var validator = new BracketValidator();
            
            Test(validator, "[{}](){}");          // Valid
            Test(validator, "([]{[]})[]{{}()}");  // Valid
            Test(validator, "(]");                // Invalid
            Test(validator, "([)]");              // Invalid
            Test(validator, "{[}");               // Invalid
            Test(validator, "");                  // Valid
        }

        private static void Test(BracketValidator validator, string ekspresi)
        {
            Console.WriteLine($"Ekspresi '{ekspresi}' valid? {validator.ValidasiEkspresi(ekspresi)}");
        }
    }
}
