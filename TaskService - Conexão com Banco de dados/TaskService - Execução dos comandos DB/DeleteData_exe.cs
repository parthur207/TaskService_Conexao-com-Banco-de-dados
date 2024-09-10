using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.DataBase;
using MySql.Data.MySqlClient;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB
{
    public class DeleteData_exe : DeleteAll_exe, ITask_Storage
    {
        public void DeleteData(string nome_task)
        {

            Nome_Task = nome_task;

            string cnn_dlt = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(cnn_dlt))
                {
                    string Comnando_Delete_string = @"DELETE *FROM All_Task WHERE Nome_Task=@Nome_Task;";

                    var Comando_delete = new MySqlCommand(Comnando_Delete_string, conexao);

                    Comando_delete.Parameters.AddWithValue("@Nome_Task", Nome_Task); //LEMBRETE: ATRIBUTO DE COLETA SEMPRE NO SEGUNDO CAMPO PÓS VIRGULA

                    conexao.Open();
                    int LinhasAfetadas = Comando_delete.ExecuteNonQuery();

                    if (LinhasAfetadas == 0)
                    {
                        Console.WriteLine($"\nNão foi possível encontrar a tarefa ({nome_task}) para exclusão.\nCertifique-se se a escrita esteja correta. ");
                    }
                    else
                    {
                        Console.WriteLine("\nTarefa removida com sucesso.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado:\n{ex.Message.ToString()}");
            }
        }
    }
}
