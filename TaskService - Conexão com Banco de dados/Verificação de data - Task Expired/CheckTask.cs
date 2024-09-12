using System;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using TaskService___Conexão_com_Banco_de_dados.DataBase;
using MySql.Data.MySqlClient;

namespace TaskService___Conexão_com_Banco_de_dados.Verificação_de_data___Task_Expired
{
    public class CheckTask : Task_Attributes
    {
        /* As tarefas que possuírem datas expiradas, ou seja, antecedentes a data de hoje, 
        terão seus status alterados automaticamente após a introdução do programa */
        public static void VerificationDate_Expired(Task_Attributes aux_date)
        {
           
            string connectionString = Connect_db.GetConnectionString();
            string comando_verificacao_date_string = @"SELECT * FROM All_Task WHERE Status_Task='Pendente';";

            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    using (var comando_verificacao_date = new MySqlCommand(comando_verificacao_date_string, conexao))
                    {
                        conexao.Open();

                        using (MySqlDataReader Reader = comando_verificacao_date.ExecuteReader())
                        {
                            while (Reader.Read()) 
                            {
                                DateOnly data_task = DateOnly.FromDateTime(Convert.ToDateTime(Reader["Data_Task"]));

                                if (data_task < aux_date.Data_Atual)
                                {
                                    
                                    string tarefaNome = Reader["Nome_Task"].ToString();
                                    string DataExpirada = data_task.ToString("dd/MM/yyyy");

                                  
                                    Reader.Close();

                                    string comando_up_stts_string = @"UPDATE All_Task SET Status_Task='Expirada' WHERE Nome_Task=@Nome_Task;";
                                    using (var comando_up_stts = new MySqlCommand(comando_up_stts_string, conexao))
                                    {
                                        comando_up_stts.Parameters.AddWithValue("@Nome_Task", tarefaNome);

                                        int linhasAfetadas = comando_up_stts.ExecuteNonQuery();

                                        if (linhasAfetadas > 0)
                                        {
                                            Console.WriteLine("Bem vindo(a) de volta!");
                                            Console.WriteLine($"A Tarefa ({tarefaNome}) foi marcada como Expirada. Data da tarefa: {DataExpirada}");
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Tratamento de exceção (pode ser ajustado conforme necessário)
                Console.WriteLine($"Ocorreu um erro durante a verificação de tarefas expiradas. Verifique sua conexão com o banco de dados. \nErro: {ex.Message.ToString()}\n");
            }
        }
    }
}