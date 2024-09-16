using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using TaskService___Conexão_com_Banco_de_dados.DataBase;
using MySql.Data.MySqlClient;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using TaskService___Conexão_com_Banco_de_dados.Main;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB
{
    public class DeleteAll_exe : Task_Attributes, ITask_Storage
    {
        public void DeleteAll()
        {
            string cnn_dl_tall_string = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(cnn_dl_tall_string))
                {
                    conexao.Open();
                    string Comando_Delete_All = @"DELETE FROM All_Task;";
                    var cmd_delete = new MySqlCommand(Comando_Delete_All, conexao);

                    int linhasafetadas = cmd_delete.ExecuteNonQuery();
                    if (linhasafetadas > 0)
                    {
                        Console.WriteLine("\n\nTodos os dados foram excluídos.");
                    }

                    else
                    {
                        Console.WriteLine("\nOcorreu um erro na tentativa de exclusão do banco de dados. Certifique-se se o banco já está vazio.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado:\n {ex.Message.ToString()}");
                Console_Main.Main(args);
            }
        }
    }
}
