using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    public class cod
    {
        public char key_stop = '.';
        public char[] mas = new char[10];
        public int maxmas = 0;
        public char mas_ch;
        public void find_char(char letter)
        {
            char ch, lt = '\0';
            using (StreamReader sr = new StreamReader("C:/Users/lozbenfe/source/repos/ConsoleApp1/lib.txt"))
            {
                bool doo = true;
                while ((lt != letter) && (doo == true))
                {
                    ch = '\0';
                    while (ch != '[')
                    {
                        ch = (char)(sr.Read());
                        if (ch == '.')
                        {
                            ch = '[';
                            doo = false;
                        }
                    }
                    if (doo == true)
                    {
                        lt = (char)(sr.Read());
                        ch = (char)(sr.Read());
                    }
                }
                maxmas = 0;
                if (doo == true)
                {
                    ch = '\0';
                    while (ch != '[')
                    {
                        ch = (char)(sr.Read());
                        if (ch == key_stop)
                        {
                            ch = '[';
                        }
                        else
                        {
                            if (ch == '-') { mas[maxmas] = '-'; maxmas++; }
                            if (ch == '*') { mas[maxmas] = '*'; maxmas++; }
                        }
                    }
                }
            }
        }
        public void find_coded()
        {
            char ch, lt = '\0';
            using (StreamReader sr = new StreamReader("C:/Users/lozbenfe/source/repos/ConsoleApp1/lib.txt"))
            {
                int[] mas_ = new int[10];
                int maxmas_;
                int g = 0;
                bool doo = true;
                while (doo == true)
                {
                    maxmas_ = 0;
                    ch = '\0';
                    while (ch != '[')
                    {
                        ch = (char)(sr.Read());
                        if (ch == key_stop)
                        {
                            ch = '[';
                            doo = false;
                        }
                        else
                        {
                            if ((ch == '*') || (ch == '-')) { mas_[maxmas_] = ch; maxmas_++; }
                        }
                    }
                    if (maxmas_ == maxmas)
                    {
                        g = 0;
                        while (g < maxmas)
                        {
                            if (mas_[g] != mas[g]) { g = maxmas + 1; }
                            g++;
                        }
                        if (g == maxmas) { doo = false; }
                    }
                    if (doo == true)
                    {
                        lt = (char)(sr.Read());
                        ch = (char)(sr.Read());
                    }
                }
                if (g == maxmas)
                {
                    mas_ch = lt;
                }
                else
                {
                    mas_ch = '\0';
                }
            }
        }
        public void code()
        {
            using (StreamReader sr = new StreamReader("C:/Users/lozbenfe/source/repos/ConsoleApp1/text.txt"))
            {
                using (StreamWriter sw = new StreamWriter("C:/Users/lozbenfe/source/repos/ConsoleApp1/cr.txt"))
                {
                    char ch = '\0';
                    int go;
                    while (sr.Peek()>0)
                    {
                        ch = (char)(sr.Read());
                        find_char(ch);
                        if (ch == key_stop) { maxmas = 0; }
                        go = 0;
                        while (go < maxmas)
                        {
                            sw.Write(mas[go]); Console.Write("[" + mas[go] + "]");
                            go++;
                        }
                        if (maxmas != 0) { sw.Write(" "); Console.Write(" "); }
                    }
                    sw.Write(" ");
                    sw.Write(key_stop);
                    Console.Write(" ");
                    Console.Write(key_stop);
                }
            }
        }
        public void decode()
        {
            using (StreamReader sr = new StreamReader("C:/Users/lozbenfe/source/repos/ConsoleApp1/cr.txt"))
            {
                using (StreamWriter sw = new StreamWriter("C:/Users/lozbenfe/source/repos/ConsoleApp1/text.txt"))
                {
                    char ch = '\0';
                    while (sr.Peek() > 0)
                    {
                        ch = '\0';
                        maxmas = 0;
                        while ((ch != ' ')&& (sr.Peek() > 0))
                        {
                            ch = (char)(sr.Read());
                            if ((ch == '*') || (ch == '-')) { mas[maxmas] = ch; maxmas++; }
                        }
                        if (maxmas == 0)
                        {
                            ch = key_stop;
                        }
                        else
                        {
                            find_coded();
                            if (mas_ch != '\0')
                            {
                                sw.Write(mas_ch);
                                Console.Write(">"+mas_ch);
                            }
                        }
                    }
                    //sw.Write(key_stop);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            cod cc = new cod();
            cc.code();
            int a;
            a = Console.Read();
            cc.decode();
            //finished this stuff
        }
    }
}
