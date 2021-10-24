using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ConsoleApp26
{
    class Zadanie21
    {
        private static int[,] pole;
        private static int k;
        private static int r;

        static void Main()
        {
            Console.WriteLine("Введите ширину поля");
            r = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длину поля");
            k = Convert.ToInt32(Console.ReadLine());

            pole = new int[r, k];

            Thread sadov1 = new Thread(Sado1);
            Thread sadov2 = new Thread(Sado2);

            sadov1.Start();
            sadov2.Start();

            sadov1.Join();
            sadov2.Join();

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write(pole[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void Sado1()
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (pole[i, j] == 0)
                        pole[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void Sado2()
        {
            for (int i = k - 1; i > 0; i--)
            {
                for (int j = r - 1; j > 0; j--)
                {
                    if (pole[j, i] == 0)
                        pole[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}



