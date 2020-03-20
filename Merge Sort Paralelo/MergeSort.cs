using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Merge_Sort_Paralelo
{
    class MergeSort
    {
        private int size;
        private int[] datos;
        private Thread[] hilos = new Thread[4];

        public MergeSort(int siz)
        {
            size = siz;
            datos = new int[size];
            llenar();
        }

        public void llenar()
        {
            Random sRan = new Random();
            int random;
            for (int i = 0; i < size; i++)
            {
                random = sRan.Next(100);
                datos[i] = random;
            }
        }

        public void imprime()
        {
            for (int i = 0; i < size; i++)
                Console.Write(datos[i] + " ");
            Console.WriteLine(" ");
        }

        // Método del hilo principal
        public void ordena()
        {
            // Se crean los hilos
            for (int i = 0; i < 4; i++)
            {
                // Se definen los limites del arreglo con los que se trabajara
                int l = i * (size / 4);
                int h = (i + 1) * (size / 4) - 1;
                // Se crea el nuevo hilo
                hilos[i] = new Thread(() => merge_sort(l, h));
                hilos[i].Start();
            }

            // Se reciben los hilos
            for (int i = 0; i < 4; i++)
            {
                while (hilos[i].ThreadState != ThreadState.Stopped) { }
            }

            // Se ordenan los datos que se acaban de recibir
            merge(0, (size / 2 - 1) / 2, size / 2 - 1);
            merge(size / 2, size / 2 + (size - 1 - size / 2) / 2, size - 1);
            merge(0, (size - 1) / 2, size - 1);
        }

        public void merge(int l, int m, int h)
        {
            
            int[] izquierdo = new int[m - l + 1];
            int[] derecho = new int[h - m];

            int n1 = m - l + 1;
            int n2 = h - m, i, j;

            for (i = 0; i < n1; i++)
                izquierdo[i] = datos[i + l];

            for (i = 0; i < n2; i++)
                derecho[i] = datos[i + m + 1];

            int k = l;
            i = j = 0;

            while (i < n1 && j < n2)
            {
                if (izquierdo[i] <= derecho[j])
                    datos[k++] = izquierdo[i++];
                else
                    datos[k++] = derecho[j++];
            }

            while (i < n1)
            {
                datos[k++] = izquierdo[i++];
            }

            while (j < n2)
            {
                datos[k++] = derecho[j++];
            }
        }

        public void merge_sort(int l, int h)
        {
            int m = l + (h - l) / 2;
            if (l < h)
            {
                merge_sort(l, m);
                merge_sort(m + 1, h);
                merge(l, m, h);
            }
        }
    }
}
