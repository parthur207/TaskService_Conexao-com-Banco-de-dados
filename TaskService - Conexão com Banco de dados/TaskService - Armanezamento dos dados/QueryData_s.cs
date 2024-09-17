using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using MySql.Data.MySqlClient;
using TaskService___Conexão_com_Banco_de_dados.Main;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Armanezamento_dos_dados
{
    public class QueryData_s : DeleteAll_s, ITask_Storage
    {

        public void Storage_QueryData(ITask_Execution aux_qr)
        {
            int op = 0;
            bool aux_query = true;
            bool op_qr = true;


            while (aux_query)
            {
                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("\n1. Consultar uma tarefa especifica.");
                Console.WriteLine("2. Consultar todas as tarefas atuais.");
                Console.WriteLine("3. Consultar tarefas pendentes.");
                Console.WriteLine("4. Consultar tarefas finalizadas.");
                Console.WriteLine("5. Consultar tarefas expiradas.");
                Console.WriteLine("6. Consultar tarefas canceladas.");
                Console.WriteLine("7. Consultar tarefas de alta prioridade.");
                Console.WriteLine("8. Consultar tarefas de média prioridade.");
                Console.WriteLine("9. Consultar tarefas de baixa prioridade.");
                Console.WriteLine("10. Voltar ao menu principal.");
                if ((!int.TryParse(Console.ReadLine(), out op) || (op < 1 || op > 9)))
                {
                    Console.WriteLine("\nOpção inválida. Digite uma das opções a seguir (1 a 9).");
                }
                else 
                {
                    aux_query = false;

                   
                }

                switch (op)
                {
                    case 1:
                        Console.WriteLine("\nDigite o nome da tarefa que deseja realizar a consulta:");
                        string nome_task1 = Console.ReadLine();

                        aux_qr.QueryData(nome_task1);

                        break;

                    case 2:
                        aux_qr.QueryData_Full();
                        break;

                    case 3:
                        aux_qr.QueryTask_Pendence();
                        break;

                    case 4:
                        aux_qr.QueryTask_Completed();
                        break;

                    case 5:
                        aux_qr.QueryTask_Expired();
                        break;

                    case 6:
                        aux_qr.QueryTask_High();
                        break;

                    case 7:
                        aux_qr.QueryTask_Average();
                        break;

                    case 8:
                        aux_qr.QueryTask_Low();
                        break;

                    case 9:
                        aux_qr.QueryTask_Canceled();
                        break;
                    case 10:
                        aux_query = false;
                        Console_Main.Main(args);
                        break;


                }
                    }
            }
        }
    }


