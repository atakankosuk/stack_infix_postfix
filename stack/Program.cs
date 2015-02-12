using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stack
{
    class Program
    {
        static bool convert(ref string infix, out string postfix)
        {

            int prio = 0;
            postfix = "";
            Stack<Char> s1 = new Stack<char>();//stack tanımı
            for (int i = 0; i < infix.Length; i++)
            {
                char ch = infix[i];
                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')//arama
                {
                    if (s1.Count <= 0)
                        s1.Push(ch);
                    else
                    {
                        if (s1.Peek() == '*' || s1.Peek() == '/')
                            prio = 1;
                        else
                            prio = 0;
                        if (prio == 1)
                        {
                            if (ch == '+' || ch == '-')
                            {
                                postfix += s1.Pop();//ekleme
                                i--;
                            }
                            else
                            {
                                postfix += s1.Pop();//ekleme
                                i--;
                            }
                        }
                        else
                        {
                            if (ch == '+' || ch == '-')
                            {
                                postfix += s1.Pop();//ekleme
                                s1.Push(ch);

                            }
                            else
                                s1.Push(ch);
                        }
                    }
                }
                else
                {
                    postfix += ch;
                }
            }
            int len = s1.Count;//s1 değerini atıyoruz
            for (int j = 0; j < len; j++)
                postfix += s1.Pop();
            return true;
        }
        static void Main(string[] args)
        {
            string infix = "";
            string postfix = "";
            if (args.Length == 1)
            {
                infix = args[0];
                convert(ref infix, out postfix);//convert fonksiyonuna ederek dizi yolluyor
                System.Console.WriteLine("InFix  yöntemi:\t" + infix);
                System.Console.WriteLine("PostFix yöntemi:\t" + postfix);
            }
            else
            {
                infix = "a+b*c-d";
                convert(ref infix, out postfix);
                System.Console.WriteLine("InFix yöntemi   :\t" + infix);
                System.Console.WriteLine("PostFix yöntemi :\t" + postfix);
                System.Console.WriteLine();
                infix = "a+b*c-d/e*f";
                convert(ref infix, out postfix);
                System.Console.WriteLine("InFix yöntemi   :\t" + infix);
                System.Console.WriteLine("PostFix yöntemi :\t" + postfix);
                System.Console.WriteLine();
                infix = "a-b/c*d-e--f/h*i++j-/k";
                convert(ref infix, out postfix);
                System.Console.WriteLine("InFix  yöntemi :\t" + infix);
                System.Console.WriteLine("PostFix yöntemi :\t" + postfix);
                System.Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
