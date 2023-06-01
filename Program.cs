using System;
using System.Linq;
using System.IO;

namespace strng
{
    class Program
    {

        static bool Check(string a, string b)
        {
            /***
                quick checks block
                ***/

            //if lines have different length
            if (a.Length != b.Length)
            { return false;}

            //if lines are the same
            if (String.Compare(a, b) == 0)
            { return true; }

            int len = a.Length;
            //final switch for answer
            bool trig = true;
            int ind;

            /***************
            loop below checks all the letters
            if letter from the line a IS NOT in line b
            trig changes to negative answer and break [we don't have to proseed]

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
            { return true; }
            else
            { return false;}
        }


        static void Output(bool answer)
        {
            if (answer == true)
            { Console.Write("Make second line is possible\n"); }
            else
            { Console.Write("Make second line is impossible\n"); }
        }

        static string GetDirect()
        {
            string dir1 = Directory.GetCurrentDirectory();
            string directory = "";

            int index = dir1.IndexOf("strng") + 5;

            for (int i = 0; i <= index; i++)
                directory += dir1[i];
            directory += "input.txt";

            return directory;
        }

        static void Main(string[] args)
        {
            //var for main loop
            string chek = "1";

            while (chek != "0")
            {
                string a="";
                string b="";

                Console.Write("enter 1 for example, 2 for user check, 0 to exit >");
                chek = Console.ReadLine();

                switch (chek)
                {
                    case ("1"):

                        int linecount = 1;
                        
                        StreamReader f = new StreamReader(GetDirect());
                        while (!f.EndOfStream)
                        {
                            //first line
                            if (linecount == 1)
                            { a += f.ReadLine(); }
                            //second line
                            else { b += f.ReadLine(); }

                            linecount++;
                        }


                        f.Close();
                        Console.WriteLine($"example of working with lines: \n{a} \nand \n{b}");

                        bool r = Check(a, b);
                        Output(r);

                        continue;

                    case ("2"):
                        Console.Write("enter a >");
                        a = Console.ReadLine();
                        Console.Write("\nenter b >");
                        b = Console.ReadLine();

                        Output(Check(a, b));

                        continue;

                    case ("0"):
                        break;

                    default:
                        Console.Write("Unknown input\n");
                        continue;
                }
            }

        }
    }
}
