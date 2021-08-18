using EstruturaPilha.Entidades;
using System;

namespace EstruturaPilha
{
    class Program
    {
        static void Main(string[] args)
        {
            PilhaDinamica p = new PilhaDinamica();

            bool flVazia = p.EstaVazia();
            p.Empilha(1);
            p.Empilha(2);
            p.Empilha(3);
            var numeros = p.RetornaTodosElementos();
            foreach (int num in numeros)
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();
            p.Desempilha();
            Console.WriteLine("E agora");
            numeros = p.RetornaTodosElementos();
            foreach (int num in numeros)
            {
                Console.WriteLine(num);
            }


            Console.ReadKey();
        }
    }
}
