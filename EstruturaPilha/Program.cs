using EstruturaPilha.Entidades;
using System;

namespace EstruturaPilha
{
    class Program
    {
        static void Main(string[] args)
        {


            PilhaEstatica p = new PilhaEstatica();
            try
            {

            p.Empilha(2);
            p.Empilha(2);
            p.EmpilhaUnico(2);

            Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
