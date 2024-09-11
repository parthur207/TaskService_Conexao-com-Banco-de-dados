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
    public class UpdateData_s : InsertData_s, ITask_Storage
    {
        public void Storage_UpdateData(ITask_Execution aux_up)
        {
            int op_up;
            bool aux = true, validacao_newDate = true;
            string formato = "dd/MM/yyyy";
            while (aux)
            {
                Console.WriteLine("\nSelecione uma opção:\n");
                Console.WriteLine("1 - Alterar o nome de uma tarefa.");
                Console.WriteLine("2 - Alterar a descrição de uma tarefa.\n");
                Console.WriteLine("3 - Alterar a data de vencimento de uma tarefa.");
                Console.WriteLine("4 - Alterar a prioridade da tarefa.");
                Console.WriteLine("5 - Alterar o status de uma tarefa.");
                Console.WriteLine("6 - Voltar ao menu principal.");

                while (!int.TryParse(Console.ReadLine(), out op_up) || op_up < 1 || op_up > 6)
                {
                    Console.WriteLine("\nDigite uma opção válida. Sendo de 1 a 6.");
                }

                switch (op_up)
                {
                    case 1:

                        Console.WriteLine("\nDigite o nome da tarefa que deseja realizar a alteração do nome:");
                        string nome_task_nome = Console.ReadLine();
                        aux_up.UpdateData_name(nome_task_nome);
                        break;

                    case 2:

                        Console.WriteLine("\nDigite o nome da tarefa que deseja realizar a alteração da descrição:");
                        string nome_task_des = Console.ReadLine();

                        Console.WriteLine($"\nDigite a nova descrição de {nome_task_des}:");
                        string descricao_task_des = Console.ReadLine();

                        aux_up.UpdateData_des(nome_task_des, descricao_task_des);
                        break;

                    case 3:

                        DateOnly new_data_task = Data_Atual;
                        Console.WriteLine("\nDigite o nome da tarefa que deseja realizar a alteração da data de expiração:");
                        string nome_task_data = Console.ReadLine();

                        while (validacao_newDate)
                        {
                            Console.WriteLine($"\nInforme a nova data de vencimento da tarefa:");
                            string Data_Task_string = Console.ReadLine();

                            if (!DateOnly.TryParseExact(Data_Task_string, formato, null, System.Globalization.DateTimeStyles.None, out new_data_task))
                            {
                                Console.WriteLine("\nDigite uma data no formato válido (DD/MM/YYYY):");
                            }
                            else
                            {
                                if (new_data_task < Data_Atual)
                                {
                                    Console.WriteLine($"Digite uma data igual, ou superior a atual ({Data_Atual}).\n");
                                }
                                else
                                {
                                    validacao_newDate = false;
                                    break;
                                }
                            }
                        }
                        aux_up.UpdateData_date(nome_task_data, new_data_task);
                        break;

                    case 4:

                        Console.WriteLine("\nDigite o nome da task que deseja realizar a alteração da prioridade:");
                        string nome_task_pri = Console.ReadLine();

                        bool validacao_pri = true;
                        Priority new_prioridade_task = Priority.MEDIA;//não pode ser nulo

                        while (validacao_pri)
                        {
                            Console.WriteLine("\nDigite a prioridade da tarefa (ALTA, MEDIA, BAIXA):");
                            string aux_priority = Console.ReadLine().ToUpper().Trim();

                            if (aux_priority == "ALTA" || aux_priority == "MEDIA" || aux_priority == "BAIXA")
                            {
                                new_prioridade_task = (Priority)Enum.Parse(typeof(Priority), aux_priority);
                                validacao_pri = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nDado inválido. Insira uma das três prioridades a seguir: (ALTA | MEDIA | BAIXA)");
                            }
                        }
                        aux_up.UpdateData_pri(nome_task_pri, new_prioridade_task);

                        break;

                    case 5:

                        Console.WriteLine("\nDigite o nome da tarefa que deseja realizar a alteração do status:");
                        string nome_task_stts = Console.ReadLine();

                        bool validacao_stts = true;
                        Status_Type new_status_task = Status_Type.Pendente;
                        while (validacao_stts)
                        {
                            Console.WriteLine("\nInforme o novo status da tarefa: (Pendente | Cancelada |Finalizada)");
                            string aux_status_task = Console.ReadLine().ToUpper().Trim();

                            if (aux_status_task == "Pendente" || aux_status_task == "Cancelada" || aux_status_task == "Finalizada")
                            {
                                new_status_task = (Status_Type)Enum.Parse(typeof(Status_Type), aux_status_task);
                                validacao_stts = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nDado inválido. Insira um dos três status a seguir: (Pendente | Finalizada)");
                            }
                        }
                        aux_up.UpdateData_stts(nome_task_stts, new_status_task);
                        break;

                    case 6:
                        aux = false;
                        return;
                        break;

                }

            }
        }
    }
}
