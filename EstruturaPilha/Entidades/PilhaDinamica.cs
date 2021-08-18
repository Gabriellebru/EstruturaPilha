using EstruturaPilha.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstruturaPilha.Entidades
{
    public class PilhaDinamica : IPilha<int>
    {
        public int TamanhoAtual { get; private set; }
        private ItemPilhaDinamica TopoItemPilhaDinamica { get; set; }
        public PilhaDinamica()
        {
            TamanhoAtual = 0;
            TopoItemPilhaDinamica = null;
        }

        public void Empilha(int obj)
        {
            ItemPilhaDinamica NovoItemPilhaDinamica;
            if (TamanhoAtual == 0)
            {
                NovoItemPilhaDinamica = new ItemPilhaDinamica(obj, null);
            }
            else
            {
                NovoItemPilhaDinamica = new ItemPilhaDinamica(obj, TopoItemPilhaDinamica);
            }
            TopoItemPilhaDinamica = NovoItemPilhaDinamica;
            TamanhoAtual++;
        }

        public int Desempilha()
        {
            if (EstaVazia())
                throw new InvalidOperationException("Exceção: Pilha Vazia");

            int ValorTopo = TopoItemPilhaDinamica.Valor;
            TopoItemPilhaDinamica = TopoItemPilhaDinamica.PonteiroAnterior;
            TamanhoAtual--;
            return ValorTopo;
        }

        public int Topo()
        {
            return TopoItemPilhaDinamica.Valor;
        }

        public int Tamanho()
        {
            return TamanhoAtual;
        }

        public IEnumerable<int> RetornaTodosElementos()
        {
            ItemPilhaDinamica aux = new ItemPilhaDinamica(TopoItemPilhaDinamica.Valor, TopoItemPilhaDinamica.PonteiroAnterior);
            while (aux != null)
            {
                yield return aux.Valor;
                aux = aux.PonteiroAnterior;
            }
        }

        public bool EstaVazia()
        {
            return TamanhoAtual == 0;
        }
    }
}
