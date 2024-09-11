using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using TaskService___Conexão_com_Banco_de_dados.DataBase;
using MySql.Data.MySqlClient;
using TaskService___Conexão_com_Banco_de_dados.Main;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB
{
    public class InsertData_exe : Connect_db, ITask_Execution
    {
        public void InsertData(string nome_task, string descricao_task, DateOnly data_task, Priority prioridade_task, Status_Type status_task)
        {
            Nome_Task = nome_task;
            Descricao_Task = descricao_task;
            Data_Task = data_task;
            Prioridade_Task = prioridade_task;
            Status_Task = status_task;

            try
            {
                using (var conexao = new MySqlConnection(ConnectString))
                {
                    string ComandoString = @"INSERT INTO All_Task (Nome_Task, Descricao_Task, Data_Task, Prioridade_Task, Status_Task) Values (@Nome_Task, @Descricao_Task, @Data_Task, @Prioridade_Task, @Status_Task)";

                    var Comando_Insert = new MySqlCommand(ComandoString, conexao);

                    Comando_Insert.Parameters.AddWithValue("@Nome_Task", Nome_Task);
                    Comando_Insert.Parameters.AddWithValue("@Descricao_Task", Descricao_Task);
                    Comando_Insert.Parameters.AddWithValue("@Data_Task", Data_Task.ToString("yyy-MM-dd"));
                    Comando_Insert.Parameters.AddWithValue("@Prioridade_Task", Prioridade_Task.ToString());
                    Comando_Insert.Parameters.AddWithValue("@Status_Task", Status_Task.ToString());

                    conexao.Open();

                    int LinhasAfetadas = Comando_Insert.ExecuteNonQuery();

                    if (LinhasAfetadas > 0)
                    {
                        Console.WriteLine("\nDados inseridos com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Falha na inserção dos dados.\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: \n{ex.ToString()}");
                Console_Main.Main(args);
            }
        }
    }
}
