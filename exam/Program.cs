using exam.WorkWithDictionary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dict my;
            
            Console.WriteLine("Привет друг! попробуй мой словарь!");
            Console.WriteLine("для продолжения нажмите любую клавишу....для выхода из программы нажмите ESC");
            string answ = Console.ReadLine();
            while (answ != "Esc")
            {
                
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1) создать словарь");
                Console.WriteLine("2) открыть словарь");

                Int32.TryParse(Console.ReadLine(), out int number);
                //Dict m1 = null;
                switch (number)
                {
                    case 1:
                        NewDictionary.Create(/*m1,*/ number);
                        break;
                    case 2:
                        Console.WriteLine("1) открыть Англо-Русский словарь");
                        Console.WriteLine("2) открыть Русско-Английский словарь");
                        bool a = Int32.TryParse(Console.ReadLine(), out int result);
                        if (a)
                        {
                            OpenDictionary.Open(result);
                        }
                        break;
                }               
            }
        }
    }
}
