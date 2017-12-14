using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_3._1_Three_Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeaderMsg(3, 1, "Implement 3 stacks with 1 array");

            ImplementFixed();
            

            Console.ReadLine();
        }

        private static void ImplementFixed()
        {
            Console.WriteLine("Static array divided into 3 sections:");

            ThreeStacks_FixedDivision fixed_div = new ThreeStacks_FixedDivision();

            Random rnd = new Random((int)DateTime.Now.Ticks);

            // add items to stacks
            Console.WriteLine();
            Console.Write("Pushing onto stack 0: ");
            for (int i = 0; i < 10; ++i)
            {
                int x = rnd.Next(0, 9);
                Console.Write(x + ", ");
                fixed_div.Push(0, x);
            }
            Console.WriteLine();
            Console.Write("Pushing onto stack 1: ");
            for (int i = 0; i < 10; ++i)
            {
                int x = rnd.Next(0, 9);
                Console.Write(x + ", ");
                fixed_div.Push(1, x);
            }
            Console.WriteLine();
            Console.Write("Pushing onto stack 1: ");
            for (int i = 0; i < 10; ++i)
            {
                int x = rnd.Next(0, 9);
                Console.Write(x + ", ");
                fixed_div.Push(2, x);
            }
            Console.WriteLine();

            // print stacks
            fixed_div.PrintStacks();

            // peek
            Console.WriteLine("Peeking stack 0: " + fixed_div.Peek(0));
            Console.WriteLine("Peeking stack 1: " + fixed_div.Peek(1));
            Console.WriteLine("Peeking stack 2: " + fixed_div.Peek(2));

            // print stacks
            fixed_div.PrintStacks();

            // pop stacks            
            Console.Write("Popping Stack 0: ");
            Console.Write(fixed_div.Pop(0));
            
            Console.WriteLine();
            Console.Write("Popping Stack 1: ");
            Console.Write(fixed_div.Pop(1));

            Console.WriteLine();
            Console.Write("Popping Stack 2: ");
            Console.Write(fixed_div.Pop(2));
            Console.WriteLine();

            // print stacks
            fixed_div.PrintStacks();
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }

    class ThreeStacks_FixedDivision
    {
        int totalElements;
        int[] intArray;
        int cursor_0;
        int cursor_1;
        int cursor_2;

        public ThreeStacks_FixedDivision()
        {
            totalElements = 300;
            intArray = new int[totalElements];
            cursor_0 = (0) - 1;
            cursor_1 = (totalElements / 3) - 1;
            cursor_2 = ((totalElements / 3) * 2) - 1;
        }
        

        public void Push(int stackNum, int value)
        {
            switch (stackNum)
            {
                case 0:
                    if (cursor_0 == (totalElements / 3) - 1)
                        throw new StackOverflowException();
                    intArray[++cursor_0] = value;
                    break;
                case 1:
                    if (cursor_1 == ((totalElements / 3) * 2) - 1)
                        throw new StackOverflowException();
                    intArray[++cursor_1] = value;
                    break;
                case 2:
                    if (cursor_2 == (totalElements - 1))
                        throw new StackOverflowException();
                    intArray[++cursor_2] = value;
                    break;
            }
        }

        public int Pop(int stackNum)
        {
            switch (stackNum)
            {
                case 0:
                    if (cursor_0 < 0)
                        throw new InvalidOperationException("Stack Empty");
                    return intArray[cursor_0--];
                case 1:
                    if (cursor_1 < totalElements / 3)
                        throw new InvalidOperationException("Stack Empty");
                    return intArray[cursor_1--];
                case 2:
                    if (cursor_2 < (totalElements / 3) * 2)
                        throw new InvalidOperationException("Stack Empty");
                    return intArray[cursor_2--];
            }

            throw new ArgumentOutOfRangeException();
        }

        public int Peek(int stackNum)
        {
            switch (stackNum)
            {
                case 0:
                    if (cursor_0 == 0)
                        throw new InvalidOperationException("Stack Empty");
                    return intArray[cursor_0];
                case 1:
                    if (cursor_1 == totalElements / 3)
                        throw new InvalidOperationException("Stack Empty");
                    return intArray[cursor_1];
                case 2:
                    if (cursor_2 == (totalElements / 3) * 2)
                        throw new InvalidOperationException("Stack Empty");
                    return intArray[cursor_2];
            }

            throw new ArgumentOutOfRangeException();
        }

        public bool IsEmpty(int stackNum)
        {
            switch (stackNum)
            {
                case 0:
                    return (cursor_0 < 0);                    
                case 1:
                    return (cursor_1 < totalElements / 3);
                case 2:
                    return (cursor_2 < (totalElements / 3) * 2);
            }

            throw new ArgumentOutOfRangeException();
        }

        public void PrintStacks()
        {
            Console.WriteLine();
            Console.Write("Stack 0: ");
            for (int i = 0; i <= cursor_0; ++i)
                Console.Write(intArray[i] + ", ");

            Console.WriteLine();
            Console.Write("Stack 1: ");
            for (int i = totalElements / 3; i <= cursor_1; ++i)
                Console.Write(intArray[i] + ", ");

            Console.WriteLine();
            Console.Write("Stack 2: ");
            for (int i = (totalElements / 3) * 2; i <= cursor_2; ++i)
                Console.Write(intArray[i] + ", ");

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
