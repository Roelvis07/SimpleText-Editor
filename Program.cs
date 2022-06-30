using System;
using System.Text;
using System.Collections.Generic;

namespace SimpleText_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> undo = new Stack<string>();
            var numberOfQueries = int.Parse(Console.ReadLine());
            string s = "";

            while (numberOfQueries-- > 0)
            {
                var dataConsole = Console.ReadLine();
                var inputSplits = dataConsole.Split(' ');
                var queryType = int.Parse(inputSplits[0]);

                switch (queryType)
                {
                    case 1:
                        //append
                        append(inputSplits[1], false);
                        break;
                    case 2:
                        //delete
                        delete(Convert.ToInt32(inputSplits[1]), false);
                        break;
                    case 3:
                        //print
                        Console.WriteLine(s[Convert.ToInt32(inputSplits[1]) - 1]);
                        break;
                    case 4:
                        //undo
                        var stackUndo = undo.Pop().Split(" ");
                        if (Convert.ToInt32(stackUndo[0]) == 2)
                            append(stackUndo[1], true);
                        else
                            delete(stackUndo[1].Length, true);
                        break;
                }
            }

            void append(string words, bool flagUndo)
            {
                s += words;
                if (!flagUndo)
                    undo.Push("1 " + words);
            }
            void delete(int pos, bool flagUndo)
            {
                if (!flagUndo)
                    undo.Push("2 " + s.Substring(s.Length - pos));

                s = s.Remove(s.Length - pos);
            }
        }
        static void Main1(string[] args)
        {
            Stack<string> undo = new Stack<string>();
            var numberOfQueries = int.Parse(Console.ReadLine());
            string s = "";

            while (numberOfQueries-- > 0)
            {
                var dataConsole = Console.ReadLine();
                var inputSplits = dataConsole.Split(' ');
                var queryType = int.Parse(inputSplits[0]);

                switch (queryType)
                {
                    case 1:
                        s = (undo.Count > 0) ? undo.Peek() + inputSplits[1] : inputSplits[1];
                        undo.Push(s);
                        break;
                    case 2:
                        s = s.Remove(s.Length - Convert.ToInt32(inputSplits[1]));
                        undo.Push(s);
                        break;
                    case 3:
                        s = undo.Peek();
                        Console.WriteLine(s[Convert.ToInt32(inputSplits[1]) - 1]);
                        break;
                    case 4:
                        undo.Pop();
                        break;
                }
            }
        }
        static void Main2(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int q = Convert.ToInt32(Console.ReadLine());
            Stack s = new Stack();

            while (q-- > 0)
            {
                string[] query = Console.ReadLine().Split();

                switch (Convert.ToInt32(query[0]))
                {
                    case 1:
                        s.Append(query[1]);
                        break;
                    case 2:
                        s.Remove(Convert.ToInt32(query[1]));
                        break;
                    case 3:
                        Console.WriteLine(stringBuilder.Append(s.PrintChar(Convert.ToInt32(query[1])) + "\n"));
                        break;
                    case 4:
                        s.Undo();
                        break;
                }
            }
        }
        class Node
        {
            public string value;
            public Node next;
            public Node(string value)
            {
                this.value = value;
            }

        }
        class Stack
        {
            public Node top;
            public string s;
            public void Append(string stringToAppend)
            {
                Node node = new Node(s);
                if (top == null)
                {
                    top = node;
                }
                node.next = top;
                top = node;

                s += stringToAppend;
            }
            public void Remove(int length)
            {
                s = s.Substring(0, s.Length - length);
            }
            public char PrintChar(int position)
            {
                return s[position - 1];
            }
            public void Undo()
            {
                s = top.value;
                top = top.next;
            }
        }
    }
}
