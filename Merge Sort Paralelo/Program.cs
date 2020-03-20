using System;
using System.Diagnostics;

namespace Merge_Sort_Paralelo
{
    class Program
    {
        static void Main(string[] args)
        {
            //tamaño de la matriz mult de 4
            int N = 8000000;
            MergeSort prueba = new MergeSort(N);

            //Iniciamos el contador del tiempo
            Stopwatch sw = new Stopwatch();
            
            //Versión Secuencial
            Console.WriteLine("Ordenamiento Secuencial");
            sw.Start();
            prueba.merge_sort(0, N - 1);
            sw.Stop();
            if (sw.ElapsedMilliseconds <= 0)
                Console.WriteLine("Operation completed in less than 0 (ms)");
            else
                Console.WriteLine("Operation completed in: " + sw.ElapsedMilliseconds + " (ms)");
            sw.Reset();

            //Versión Multihilos
            Console.WriteLine("Ordenamiento Paralelo");
            sw.Start();
            prueba.ordena(); 
            sw.Stop();

            Console.WriteLine();
            if (sw.ElapsedMilliseconds <= 0)
                Console.WriteLine("Operation completed in less than 0 (ms)");
            else
                Console.WriteLine("Operation completed in: " + sw.ElapsedMilliseconds + " (ms)");

            Console.ReadKey();
        }
    }
}
