using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using MySql.Data.MySqlClient;
using TaskService___Conexão_com_Banco_de_dados.Main;
using System.Diagnostics.Eventing.Reader;
using TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB;
using MySqlX.XDevAPI.Common;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Armanezamento_dos_dados
{
    public class UpdateData_s : InsertData_s, ITask_Storage
    {
        public void Storage_UpdateData(ITask_Execution aux_up)
        {
            int op_up;
             
            string formato = "dd/MM/yyyy";

            while (UpdateData_exe.aux_up_exe)
            {
                #region Variaveis bool de validação 
                UpdateData_exe.validation1 = true; UpdateData_exe.validation2 = true; UpdateData_exe.validation3 = true; UpdateData_exe.validation4 = true; UpdateData_exe.validation5 = true; UpdateData_exe. validation6 = true; UpdateData_exe.validation7 = true; UpdateData_exe.validation8 = true;
                #endregion   
                
                Console.WriteLine("\nSelecione uma opção:\n");
                Console.WriteLine("1 - Alterar o nome de uma tarefa.");
                Console.WriteLine("2 - Alterar a descrição de uma tarefa.");
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
                        string nome_task_nome="";
                        while (UpdateData_exe.validation1)
                        {
                            Console.WriteLine("\nDigite o NOME da tarefa que deseja realizar a alteração do nome:");
                           nome_task_nome = Console.ReadLine();
                            if (string.IsNullOrEmpty(nome_task_nome))
                            {
                                Console.WriteLine("\nO valor informado não pode ser nulo.");
                            }
                            else
                            {
                                UpdateData_exe.validation1 = false;
                            }
                        }
                        while (UpdateData_exe.validation2)
                        {
                            Console.WriteLine($"\nDigite o novo NOME a substituir ({nome_task_nome}):");
                            string new_nome_task = Console.ReadLine();

                            if (string.IsNullOrEmpty(new_nome_task))
                            {
                                Console.WriteLine("\nO novo nome não pode ser nulo.");
                            }
                            else
                            {
                                UpdateData_exe.validation2 = false;
                                aux_up.UpdateData_name(nome_task_nome, new_nome_task);
                            }
                        }
                        break;

                    case 2:
                        string nome_task_des = "";
                        while (UpdateData_exe.validation3)
                        {
                            Console.WriteLine("\nDigite o NOME da tarefa que deseja realizar a alteração da descrição:");
                           nome_task_des = Console.ReadLine();
                            if (string.IsNullOrEmpty(nome_task_des))
                            {
                                Console.WriteLine("\nO valor informado não pode ser nulo.");
                            }
                            else
                            {
                                UpdateData_exe.validation3 = false;
                            }
                        }
                            while (UpdateData_exe.validation4)
                            {
                                Console.WriteLine($"\nDigite a nova descrição de ({nome_task_des}):");
                                string descricao_task_des = Console.ReadLine();

                                if (string.IsNullOrEmpty(descricao_task_des))
                                {
                                    Console.WriteLine("\nA nova descrição não pode ser nula.");
                                }
                                else
                                {
                                    UpdateData_exe.validation4 = false;
                                    aux_up.UpdateData_des(nome_task_des, descricao_task_des);
                                }
                            }
                        
                        break;

                    case 3:
                        string nomeTarefa="";
                        while (UpdateData_exe.validation5)
                        {
                            Console.WriteLine("\nDigite o NOME da tarefa que deseja alterar a data de expiração:");
                            nomeTarefa = Console.ReadLine();

                            if (string.IsNullOrEmpty(nomeTarefa))
                            {
                                Console.WriteLine("\nO valor informado não pode ser nulo.");
                            }
                            else
                            {
                                UpdateData_exe.validation5 = false;
                            }
                        }

                        while (UpdateData_exe.validation6)
                        {
                            Console.WriteLine($"\nInforme a nova data de vencimento da tarefa (DD/MM/YYYY):");
                            string novaDataString = Console.ReadLine();

                            if (!DateOnly.TryParseExact(novaDataString, formato, null, System.Globalization.DateTimeStyles.None, out DateOnly novaData))
                            {
                                Console.WriteLine("\nDigite uma data no formato válido (DD/MM/YYYY):");
                            }
                            else if (novaData < Data_Atual)
                            {
                                Console.WriteLine($"A data informada deve ser igual ou posterior à data atual ({Data_Atual}).\n");
                            }
                            else
                            {
                                UpdateData_exe.validation6 = false;
                                aux_up.UpdateData_date(nomeTarefa, novaData);
                            }
                        }
                        break;

                    case 4:

                        string nome_task_pri = "";
                        while (UpdateData_exe.validation7)
                        {
                            Console.WriteLine("\nDigite o NOME da task que deseja realizar a alteração da prioridade:");
                            nome_task_pri = Console.ReadLine();

                            if(string.IsNullOrEmpty(nome_task_pri)){
                                Console.WriteLine("\nO valor informado não pode ser nulo.");
                            }
                            else
                            {
                                UpdateData_exe.validation7 = false;
                            }
                        }

                
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
                                Console.WriteLine("\nDado inválido.");
                            }
                        }
                        aux_up.UpdateData_pri(nome_task_pri, new_prioridade_task);

                        break;

                    case 5:
                        string nome_task_stts = "";
                        while (UpdateData_exe.validation8) {
                            Console.WriteLine("\nDigite o NOME da tarefa que deseja realizar a alteração do status:");
                            nome_task_stts = Console.ReadLine();
                            if (string.IsNullOrEmpty(nome_task_stts))
                            {
                                Console.WriteLine("\nO valor informado não pode ser nulo.");
                            }
                            else
                            {
                                UpdateData_exe.validation8 = false;
                            }
                        }
                        bool validacao_stts = true;
                        Status_Type new_status_task = Status_Type.Pendente;
                        while (validacao_stts)
                        {
                            Console.WriteLine("\nInforme o novo status da tarefa: (Pendente | Cancelada | Finalizada)");
                            string aux_status_task = Console.ReadLine().Trim();

                            if (aux_status_task == "Pendente" || aux_status_task == "Cancelada" || aux_status_task == "Finalizada")
                            {
                                new_status_task = (Status_Type)Enum.Parse(typeof(Status_Type), aux_status_task);
                                validacao_stts = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nDado inválido.");
                            }
                        }
                        aux_up.UpdateData_stts(nome_task_stts, new_status_task);
                        break;

                    case 6:
                        UpdateData_exe.aux_up_exe = false;
                        Console_Main.Main(args);
                        break;
                }

            }
        }
    }
}
