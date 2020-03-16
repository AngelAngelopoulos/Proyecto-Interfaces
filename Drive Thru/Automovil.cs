using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
//using System.Drawing;
namespace Drive_Thru
{
   
    class Automovil
    {
        Thread t;
        int tiempo;
        public bool estado;
        Stopwatch time;
        public bool move;
        public bool termina;
        public int vel;

        public Automovil()
        {
            //Instanciamos el cronometro
            time = new Stopwatch();
            //Instanciamos hilo con su funcion
            t = new Thread(mueveAuto);
            //Iniciamos conometro
            time.Start();
            //Creamos unn numero aleatorio con una semilla diferente con un rango de 1 a 10 segundos
            tiempo = new Random((int)time.ElapsedTicks).Next(1000, 20000); 
            //Resteamos el cronometro
            time.Reset();
            //Console.WriteLine(tiempo);

            //seteamos su velocidad de manera aleatoria
            vel = new Random().Next(1, 20);

            //Inicializamos el estado a falso (variable auxiliar)
            estado = false;
            //Inicializamos el termino del hilo a falso
            termina = false;
            //El auto comienza moviendose
            move = true;

        }

        public void initHilo()
        {
            //Iniciamos el hilo
            t.Start();
            
        }
        public void mueveAuto()
        {
            //mientras que no termine el hilo
            while (!termina)
            {
                //si el auto esta moviendose
                if (move)
                {
                    //variable estado a verdadero
                    estado = true;
                }
                else {
                    //iniciamos el cronometro
                    time.Start();
                    //mientras que el numero de segundos transcurridos sea menor al tiempo
                    while (time.ElapsedMilliseconds < tiempo)
                    {
                        //variable estado a falso
                        estado = false;
                    }
                    //cuando termine de esperar, el auto volvera a moverse
                    move = true;
                }
            }
        }
    }
}
