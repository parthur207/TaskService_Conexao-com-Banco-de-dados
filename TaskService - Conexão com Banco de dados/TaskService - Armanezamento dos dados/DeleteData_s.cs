using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using MySql.Data.MySqlClient;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Armanezamento_dos_dados
{
    public class DeleteData_s : UpdateData_s, ITask_Storage
    {
        public void Storage_DeleteData(ITask_Execution aux_dlt_exe)
        {

            bool rem_again = true;

            while (rem_again)
            {
                int op_rem;
                string nome_task;

                Console.WriteLine("\nDigite o nome da tarefa específica que deseja realizar a remoção:");
                nome_task = Console.ReadLine();

                aux_dlt_exe.DeleteData(nome_task);

                Console.WriteLine("\nDeseja realizar uma nova remoção (1. Sim | 2. Não):");
                while (!int.TryParse(Console.ReadLine(), out op_rem) || op_rem < 1 || op_rem > 2)
                {
                    Console.WriteLine("\nDigite uma opção válida. (1. Sim || 2. Não):");
                }
                if (op_rem == 1)
                {
                    rem_again = true;
                }
                else if (op_rem == 2)
                {
                    rem_again = false;
                }

            }
        }
    }
}
