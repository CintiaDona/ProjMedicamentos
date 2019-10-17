using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    class Medicamentos
    {
        private List<Medicamento> listaMedicamentos = new List<Medicamento>();
        Lote lote = new Lote();

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public void adicionar (Medicamento med)
        {
            listaMedicamentos.Add(med);
        }

        public bool deletar (Medicamento med)
        {
            foreach (Medicamento m in listaMedicamentos)
            {
                if (lote.quantidade() == 0)
                {
                    listaMedicamentos.Remove(med);
                    return true;
                }
            }
            return false;
        }

        public Medicamento pesquisar(Medicamento med)
        {
            foreach (Medicamento m in listaMedicamentos)
            {
                if (m.Id.Equals(med.Id))
                {
                    Console.WriteLine("\nMedicamento encontrado: ");
                    return m;
                }
            }
            Console.Write("\nMedicamento não encontrado\n Medicamento: ");
            return med;
        }

        public Medicamento pesquisarComDetalhes(Medicamento med)
        {
            foreach (Medicamento m in listaMedicamentos)
            {
                if (m.Id.Equals(med.Id)) {
                    Console.WriteLine("\nMedicamento encontrado: ");
                    m.listarLotes();
                    return m;
                }

            }
            Console.Write("\nMedicamento não encontrado\n Medicamento: ");
            return med;
        }
        
        public List<Medicamento> getLista()
        {
            return listaMedicamentos;
        }
    }
}
