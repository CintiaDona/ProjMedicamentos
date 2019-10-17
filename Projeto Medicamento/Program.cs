using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Medicamento
{
    class Program
    {
        static Medicamento medicamento = new Medicamento();
        static Medicamentos medicamentos = new Medicamentos();
        static Lote lote = new Lote();
        static List<Medicamento> listaMedicamentos = new List<Medicamento>();
        static void Main(string[] args)
        {
            int opcao, idPesq;

            do
            {
                Console.WriteLine("\n\n  Digite a opção desejada **\n\n  0 - Finalizar\n  1 - Cadastrar medicamento\n  2 - Consultar medicamento (Dados apenas)\n  3 - Consultar medicamento (Dados + lote)\n  4 - Comprar medicamento\n  5 - Vender medicamento\n  6 - Listar medicamentos\n");
                opcao = int.Parse(Console.ReadLine());

                switch(opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Digite o ID do medicamento: ");
                        int idCad = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nDigite o nome do medicamento: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("\nDigite o laboratório do medicamento: ");
                        string lab = Console.ReadLine();
                        medicamentos.adicionar(new Medicamento(idCad, nome, lab));
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Digite o ID do medicamento a ser pesquisado:");
                        idPesq = int.Parse(Console.ReadLine());
                        Console.WriteLine(medicamentos.pesquisar(new Medicamento(idPesq, "", "")).toString());
                        break;
                    case 3:
                        Console.WriteLine("Digite o ID do medicamento a ser pesquisado:");
                        idPesq = int.Parse(Console.ReadLine());
                        Console.WriteLine(medicamentos.pesquisarComDetalhes(new Medicamento(idPesq, "", "")).toString());
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Digite o ID do remédio:");
                        int idrem = int.Parse(Console.ReadLine());
                        Medicamento med = medicamentos.pesquisar(new Medicamento(idrem,"",""));
                        Console.WriteLine("\n" +med.toString());
                        Console.WriteLine("\nDigite o ID do lote:");
                        int idLote = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nDigite a quantidade do lote:");
                        int qtd = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nDigite a validade do lote:");
                        Console.WriteLine("Exemplo data: " + DateTime.Now.ToString("dd/MM/yyyy"));
                        DateTime data;
                        data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        //Verificar se a data é maior que a atual
                        while (data< DateTime.Now)
                        {
                            Console.WriteLine(">>A data de válidade precisa ser maior que a atual.");
                            Console.WriteLine("Digite a validade do lote:");
                            Console.WriteLine("Exemplo data: " + DateTime.Now.ToString("dd/MM/yyyy"));
                            data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }

                        lote = new Lote(idLote, qtd, data);

                        med.comprar(lote);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Digite o ID do remédio:");
                        int idrememedio = int.Parse(Console.ReadLine());
                        Medicamento rem = medicamentos.pesquisar(new Medicamento(idrememedio, "", ""));
                        Console.WriteLine("\n"+rem.toString());
                        Console.WriteLine("\nDigite a quantidade do medicamento:");
                        int qtdVenda = int.Parse(Console.ReadLine());
                        rem.vender(qtdVenda);
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Medicamentos:");
                        foreach (Medicamento m in medicamentos.getLista())
                        {
                            Console.WriteLine(m.toString());
                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                } 
            } while (opcao > 0);
        }
    }
}
