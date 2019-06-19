using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            kinopoisk kinopoisk = new kinopoisk();
            kinopoisk.Top();
            Telegram telegram = new Telegram();
            telegram.Bot();
            for(; ; ) { }
        }
    }
}
