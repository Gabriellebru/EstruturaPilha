using EstruturaPilha.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstruturaPilha.Entidades
{
    public class PilhaEstatica : IPilha<int>
    {
        private int[] VetorElementos;
        private int TamanhoMaximo;
        private int Indice;

        public PilhaEstatica()
        {
            TamanhoMaximo = 30;
            VetorElementos = new int[TamanhoMaximo];
            Indice = 0;
        }

        public PilhaEstatica(int tamanhoMaximo)
        {
            if (tamanhoMaximo < 0)
            {
                throw new ArgumentException("tamanhoMaximo", "Tamanho não pode ser menor ou igual a zero");
            }

            TamanhoMaximo = tamanhoMaximo;
            VetorElementos = new int[TamanhoMaximo];
            Indice = 0;
        }

        public int Desempilha()
        {
            if (EstaVazia())
            {
                throw new InvalidOperationException("Pilha Vazia, operação não pode ser realizada");
            }
            VetorElementos[Indice - 1] = 0; 
            return VetorElementos[--Indice];
        }

        public void Empilha(int obj)
        {
            if (Indice == TamanhoMaximo)
            {
                throw new InvalidOperationException("Pilha Cheia, operação não pode ser realizada");
            }
            VetorElementos[Indice] = obj;
            Indice++;
        }

        public IEnumerable<int> RetornaTodosElementos()
        {
            for (int i = Indice - 1; i >= 0; i--)
            {
                yield return VetorElementos[i];
            }
        }

        public int Tamanho()
        {
            return Indice;
        }

        public int Topo()
        {
            if (EstaVazia())
            {
                throw new InvalidOperationException("Exceção: Pilha Vazia");
            }
            return VetorElementos[Indice - 1];
        }

        public bool EstaVazia()
        {
            return Indice == 0;
        }

        public int MaiorValor()
        {
            int valorAtual = int.MinValue;
            
            for(int i = 0; i < Tamanho(); i++)
            {
                if(valorAtual < VetorElementos[Indice - 1])
                {
                    valorAtual = VetorElementos[Indice - 1];
                }
            }
            return valorAtual;
        }

        public int MenorValor()
        {
            int valorAtual = int.MaxValue;
            for (int i = 0; i < Tamanho(); i++)
            {
               if(VetorElementos[i] < valorAtual)
                {
                    valorAtual = VetorElementos[Indice - 1];
                }
            }
            return valorAtual;
        }

        public double MediaAritmetica()
        {
            double resultado = 0;

            for (int i = 0; i < Tamanho(); i++)
            {
                resultado = resultado + VetorElementos[i];
            }

            resultado = resultado / Tamanho();

            return resultado;
        }

        public void DesempilhaTodos()
        {
            int tamanho = Tamanho();

            for(int i = 0; i < tamanho; i++)
            {
                Desempilha();
            }
        }

        public void EmpilhaUnico(int k)
        {
            int tamanho = Tamanho();
            bool existeValor = false;

            for(int i = 0; i < tamanho; i++)
            {
                if(VetorElementos[i] == k)
                {
                    existeValor = true;
                }
            }

            if (existeValor)
            {
                throw new ArgumentException("Valor já existe, valor não inserido");
            }
            else
            {
                Empilha(k);
            }
        }
        
    }
}
