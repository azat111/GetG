using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bars
{
    public class Delegate
    {
        public event EventHandler<char>? OnKeyPressed;

        public void Run()
        {
            char c = Console.ReadKey().KeyChar;
            while (c != 'c' && c != 'с')
            {
                OnKeyPressed?.Invoke(this, c);
                c = Console.ReadKey().KeyChar;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var read = new Delegate();
            read.OnKeyPressed += Sym;
            read.Run();
        }
        public static void Sym(object? sender, char c)
        {
            Console.WriteLine(c);
        }

    }
    
}
