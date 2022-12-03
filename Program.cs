using System;
using System.Linq;
using System.IO;

namespace strng
{
    class Program
    {

        static void Main(string[] args)
        {
            //var for main loop
            bool chek = true;
            //var that splits the string check into two steps
            //first: from file
            //second: user's
            bool test = true;
            int step = 0;
            while (chek == true)
            {
                string a="";
                string b="";

                if (test==true)
                {
                    //var to count lines from file
                    int linecount = 1;
                    //!!! change directory to yours !!!
                    StreamReader f = new StreamReader("C:/Users/paart/source/repos/strng/input.txt");
                    while (!f.EndOfStream)
                    {
                        //first line
                        if (linecount == 1)
                        {
                            a = f.ReadLine();
                        }
                        //second line
                        else { b = f.ReadLine(); }

                        linecount++;
                    }
                    f.Close();

                    //set the switch [steps] off
                    test = false;
                    Console.WriteLine($"example of working with lines {a} and {b}");
                }
                else 
                {
                    //getting lines on second step
                    Console.WriteLine("enter a >");
                    a = Console.ReadLine();
                    Console.WriteLine("\nenter b >");
                    b = Console.ReadLine();
                }


                    
                /***
                quick checks block
                ***/

                //if lines have different length
                if (a.Length != b.Length)
                {
                    Console.WriteLine("\nmake up the second line is impossible");
                    Console.ReadLine();

                    //important part of quiting programm   [QUIT]
                    step++;
                    if (step == 2)
                    { break; }

                    continue;
                }

                //if lines are the same
                if (String.Compare(a, b) == 0)
                {
                    Console.WriteLine("\nmake up the second line is possible");
                    Console.ReadLine();

                    //[QUIT]
                    step++;
                    if (step == 2)
                    { break; }

                    continue;
                }

                int len = a.Length;
                //final switch for answer
                bool trig = true;
                int ind;

                /***************
                loop below checks all the letters
                if letter from the line a IS NOT in line b
                trig for negative answer and break [we don't have to proseed]

                if letter from the line a IS in line b
                letter removed from line b
                 ***************/

                for (int i = 0; i < len; i++)
                {
                    if (b.Contains(a[i]) == false)
                    {
                        trig = false;
                        break;
                    }
                    ind = b.IndexOf(a[i]);
                    b = b.Remove(ind, 1);
                }

                /**** ANSWER BLOCK ****/

                if (trig == true)
                {
                    Console.WriteLine("\nmake up the second line is possible");
                    Console.ReadLine();

                    //[QUIT]
                    step++;
                    if (step == 2)
                    { break; }

                    continue;
                }
                else
                {
                    Console.WriteLine("\nmake up the second line is impossible");
                    Console.ReadLine();

                    //[QUIT]
                    step++;
                    if (step == 2)
                    { break; }

                    continue;
                }
            }

        }
    }
}
