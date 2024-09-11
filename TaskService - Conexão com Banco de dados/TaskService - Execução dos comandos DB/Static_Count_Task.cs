using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using TaskService___Conexão_com_Banco_de_dados.DataBase;
using TaskService___Conexão_com_Banco_de_dados.Main;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB
{
    public class Static_Count_Task
    {
        public static int ContarTarefas()
        {
            int TotalTarefas = 0;
            try
            {
                string ConnectionString = Connect_db.GetConnectionString();
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_string = @"SELECT COUNT(*) FROM All_Task;";

                    using (var comando_count = new MySqlCommand(comando_query_string, conexao))
                    {
                        conexao.Open();

                        TotalTarefas = Convert.ToInt32(comando_count.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado ao contar as tarefas:\n{ex.Message}");
            }
            return TotalTarefas;
        }
    }
}
