using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using MySql.Data.MySqlClient;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Armanezamento_dos_dados
{
    public class InsertData_s : Task_Attributes, ITask_Storage
    {
        public void Storage_InsertData(ITask_Execution aux_ins)
        {
            string nome_task, descricao_task;
            bool validacao1 = true;
            bool validacao2 = true;
            string opcao = "sim";

            Status_Type status_task = Status_Type.Pendente;//Uma nova Tarefa sempre será introduzida como "Pendente" e seu status poderá ser modificado mediante a ação do usuário

            DateOnly data_task = DateOnly.FromDateTime(DateTime.Now);// Introduzido com um valor por não poder ser nulo.

            Priority prioridade_task = Priority.MEDIA;//Introduzido com um valor enum por não poder ser nulo.

            do
            {

                string formato = "dd/MM/yyyy";

                Console.WriteLine("\nDigite o nome da tarefa:");
                nome_task = Console.ReadLine();

                Console.WriteLine("\nDigite a descricao da tarefa:");
                descricao_task = Console.ReadLine();


                while (validacao1)
                {

                    Console.WriteLine("\nInforme a data de vencimento da tarefa:");
                    string Data_Task_string = Console.ReadLine();

                    if (!DateOnly.TryParseExact(Data_Task_string, formato, null, System.Globalization.DateTimeStyles.None, out data_task))
                    {
                        Console.WriteLine("\nDigite uma data no formato válido (DD/MM/YYYY):");
                    }
                    else
                    {
                        if (data_task < Data_Atual)
                        {
                            Console.WriteLine($"\nDigite uma data igual, ou superior a atual ({Data_Atual}).\n");
                        }
                        else
                        {
                            validacao1 = false;
                            break;
                        }
                    }
                }//Validação da data da tarefa

                while (validacao2)
                {
                    Console.WriteLine("\nDigite a prioridade da tarefa (ALTA, MEDIA, BAIXA):");
                    string aux_priority = Console.ReadLine().ToUpper().Trim();

                    if (aux_priority == "ALTA" || aux_priority == "MEDIA" || aux_priority == "BAIXA")
                    {
                        prioridade_task = (Priority)Enum.Parse(typeof(Priority), aux_priority);
                        validacao2 = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nDado inválido. Insira uma das três prioridades a seguir: (ALTA | MEDIA | BAIXA)");
                    }
                }//Validação da prioridade da tarefa
                bool inserir_novamente = true;
                while (inserir_novamente)
                {
                    Console.WriteLine("\nDeseja efetuar a inserção de uma nova tarefa? (Sim || Não):");
                    opcao = Console.ReadLine().ToLower();
                    if (opcao == "sim")
                    {
                        validacao1 = true;
                        validacao2 = true;
                        inserir_novamente = false;
                        break;
                    }
                    else if (opcao!="sim" && opcao!="não" && opcao != "nao") 
                    {
                        Console.WriteLine("\nDigite uma opção válida.");
                        inserir_novamente=true;
                    }
                    else if(opcao=="nao" || opcao=="não"){
                        inserir_novamente = false;
                        break;
                    }
                }
                aux_ins.InsertData(nome_task, descricao_task, data_task, prioridade_task, status_task);
            }
            while (opcao == "sim" && opcao!="nao" && opcao!="não");
        }
    }
}
