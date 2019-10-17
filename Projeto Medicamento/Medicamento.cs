using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    class Medicamento
    {
       private  int id;
       private string nome, laboratorio;
        private Queue<Lote> lotes;
        private Lote lote = new Lote();
        List<Medicamento> listaMedicamentos = new List<Medicamento>();

        public Medicamento()
        {
            Id = 0;
            nome = "";
            laboratorio = "";
            lotes = new Queue<Lote>();
        }

        public Queue<Lote> FilaMedicamento
        {
            get { return FilaMedicamento; }
            set { FilaMedicamento = value; }
        }

        public int Id
        {
            get { return id; }

            set { id = value; }
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.Id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            lotes = new Queue<Lote>();
        }

        public int qtdDisponivel()
        {
            int qtd = 0;
            foreach (Lote lote in lotes)
            {
                qtd += lote.quantidade();
            }
            
            return qtd;
        }

        public void comprar (Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool vender (int qtd)
        {
            Boolean precisaDeletar = false;
            if (qtd <= qtdDisponivel())
            {
                int qtdFalta = qtd;

                //Enquanto a quantidade solicitada > 0 
                while (qtdFalta > 0)
                {
                    //Procuro a quantidade nos  lotes
                    foreach (Lote lote in lotes)
                    {
                        if (lote.quantidade() > qtdFalta) //Se a quantidade em estoque for maior que a quantidade solicitada, significa que podemos vender
                        {
                            lote.qtd -= qtdFalta;
                            qtdFalta = 0;
                        }
                        else if (lote.quantidade() == qtdFalta) //Se a quantidade em estoque for igual a quantidade solicitada decrementa e elimina o lote
                        {
                            lote.qtd = 0;
                            qtdFalta = 0;
                            precisaDeletar = true;
                            break;
                        }
                        else 
                        {
                            qtdFalta = qtdFalta - lote.qtd;
                            lote.qtd = 0;
                            precisaDeletar = true;
                            break;
                        }

                    }

                    if (precisaDeletar)
                    {
                        precisaDeletar = false;
                        lotes.Dequeue();
                    }
                }
                Console.WriteLine("\nMedicamento vendido com sucesso");
                return true;
            }
            return false;
        }

        public string toString()
        {
            return ("\n" + Id + " - " + nome + " - " + laboratorio + " - " + qtdDisponivel());
        }

        public bool Equals(object obj)
        {
            return ((Medicamento)obj).id.Equals(this.id);
        }

        public void listarLotes()
        {
            Console.WriteLine("\nLotes:");
            foreach (Lote lote in lotes)
            {
                Console.WriteLine(lote.toString());
            }
        }
    }
}
