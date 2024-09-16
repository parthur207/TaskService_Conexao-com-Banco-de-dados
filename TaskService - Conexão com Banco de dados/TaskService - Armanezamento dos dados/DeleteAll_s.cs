using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB;
using MySql.Data.MySqlClient;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Armanezamento_dos_dados
{
    public class DeleteAll_s : DeleteData_s, ITask_Storage
    {
        public void Storage_DeleteAll(ITask_Execution aux_dlt_all)
        {
            DeleteAll_exe aaux_dlt_all2 = new DeleteAll_exe();
            Console.WriteLine("\nConfirme a ação digitando a senha cadastrada:");
            string Teclas_digitadas = string.Empty;
            ConsoleKeyInfo Teclas;

            do
            {
                Teclas = Console.ReadKey(intercept: true);
                if (Teclas.Key != ConsoleKey.Enter)
                {
                    Teclas_digitadas += Teclas.KeyChar;
                }
                Console.Write("*");
            }
            while (Teclas.Key != ConsoleKey.Enter);

            if (Teclas_digitadas != Password_Acess)
            {
                Console.WriteLine("\n\nSenha incorreta.");
            }
            else
            {
                aaux_dlt_all2.DeleteAll();
            }
        }
    }
}
