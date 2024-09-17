using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.DataBase;
using MySql.Data.MySqlClient;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using TaskService___Conexão_com_Banco_de_dados.Main;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB { 

        public class QueryData_exe : DeleteData_exe, ITask_Storage
        {
        public void QueryData(string nome_task)
        {
            Nome_Task = nome_task;
            string ConnectionString = Connect_db.GetConnectionString();

            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_string = @"SELECT * FROM All_Task WHERE Nome_Task=@Nome_Task;";
                    using (var comando_query = new MySqlCommand(comando_query_string, conexao))
                    {       
                        comando_query.Parameters.AddWithValue("@Nome_Task", nome_task);  // Adiciona o parâmetro
                        conexao.Open();  // Abre a conexão
                        
                        using (MySqlDataReader Reader = comando_query.ExecuteReader())
                        {
                            if (Reader.HasRows)  // Verifica se existem linhas
                            {
                                while (Reader.Read())
                                {
                                    Console.WriteLine($"\nNome da tarefa: {Reader["Nome_Task"]} - Descrição da tarefa: {Reader["Descricao_Task"]} - Data de vencimento: {Reader["Data_Task"]} - Prioridade da tarefa: {Reader["Prioridade_Task"]} - Status da tarefa: {Reader["Status_Task"]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nTarefa não encontrada.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado:\n {ex.Message}");
                Console_Main.Main(args);
                Console.WriteLine();
            }
        }

        public void QueryData_Full()
        {
          
            try
            {
                string ConnectionString = Connect_db.GetConnectionString();
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_string = @"SELECT  *FROM All_Task;";

                    using (var comando_query_all = new MySqlCommand(comando_query_string, conexao))
                    {
                        conexao.Open();

                        using (MySqlDataReader Reader = comando_query_all.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                Console.WriteLine("\nTodas as tarefas:");
                                while (Reader.Read())
                                {
                                   
                                    Console.WriteLine($"\nNome da tarefa: {Reader.GetString("Nome_Task")} - Descrição da tarefa: {Reader.GetString("Descricao_Task")} - Data de vencimento: {Reader.GetDateTime("Data_Task"):dd/MM/yyyy} - Prioridade da tarefa: {Reader.GetString("Prioridade_Task")} - Status da tarefa: {Reader.GetString("Status_Task")}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNenhuma tarefa no momento.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado:\n{ex.Message}");
                Console_Main.Main(args);
                Console.WriteLine();
            }
        }
            public void QueryTask_Pendence()
        {
            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_pendence_string = @"SELECT * FROM All_Task WHERE Status_Task='Pendente';";
                    using (var comando_query_pendence = new MySqlCommand(comando_query_pendence_string, conexao))
                    {
                        conexao.Open();

                        using (MySqlDataReader Reader = comando_query_pendence.ExecuteReader())
                        {
                            if (Reader.HasRows)//usar 'HasRows' para verificar se a consulta retornou algum resultado
                            {
                                Console.WriteLine("\nTarefas pendentes:");
                                while (Reader.Read())
                                {
                                    Console.WriteLine($"\nNome da tarefa: {Reader["Nome_Task"]} - Descrição da tarefa: {Reader["Descricao_Task"]} - Data de vencimento: {Reader["Data_Task"]} - Prioridade da tarefa: {Reader["Prioridade_Task"]} - Status da tarefa: {Reader["Status_Task"]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNenhuma tarefa com status de 'Pendente' no momento.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado:\n{ex.Message}");
                Console_Main.Main(args);
                Console.WriteLine();
            }
        }

        // Continue refatorando as outras funções de consulta seguindo o mesmo padrão.
    
        public void QueryTask_Completed()
        {
            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_completed_string = @"SELECT * FROM All_Task WHERE Status_Task='Finalizada';";
                    using (var comando_query_completed = new MySqlCommand(comando_query_completed_string, conexao))
                    {
                        conexao.Open();
                        using (MySqlDataReader Reader = comando_query_completed.ExecuteReader())
                        {
                            
                            if (Reader.HasRows)
                            {
                                Console.WriteLine("\nTarefas finalizadas:");
                                while (Reader.Read())
                                {
                                    Console.WriteLine($"\nNome da tarefa: {Reader["Nome_Task"]} - Descrição da tarefa: {Reader["Descricao_Task"]} - Data de vencimento: {Reader["Data_Task"]} - Prioridade da tarefa: {Reader["Prioridade_Task"]} - Status da tarefa: {Reader["Status_Task"]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNenhuma tarefa com status de 'Finalizada' no momento.");
                            }  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado:\n{ex.Message.ToString()}");
                Console_Main.Main(args);
                Console.WriteLine();
            }
        }

        public void QueryTask_Expired()
        {
            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_expired_string = @"SELECT * FROM All_Task WHERE Status_Task='Expirada';";
                    using (var comando_query_expired = new MySqlCommand(comando_query_expired_string, conexao))
                    {
                        conexao.Open();
                        using (MySqlDataReader Reader = comando_query_expired.ExecuteReader())
                        {
                            
                            if (Reader.HasRows)//usar 'HasRows' para verificar se a consulta retornou algum resultado
                            {
                                Console.WriteLine("\nTarefas pendentes:");
                                while (Reader.Read())
                                {
                                    Console.WriteLine($"\nNome da tarefa: {Reader["Nome_Task"]} - Descrição da tarefa: {Reader["Descricao_Task"]} - Data de vencimento: {Reader["Data_Task"]} - Prioridade da tarefa: {Reader["Prioridade_Task"]} - Status da tarefa: {Reader["Status_Task"]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNenhuma tarefa com status de 'Expirada' no momento.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado:\n{ex.Message.ToString()}");
                Console_Main.Main(args);
                Console.WriteLine();

            }
        }

        public void QueryTask_High()
        {
            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_high_string = @"SELECT * FROM All_Task WHERE Prioridade_Task='ALTA';";
                    using (var comando_query_High = new MySqlCommand(comando_query_high_string, conexao))
                    {
                        conexao.Open();
                        using (MySqlDataReader Reader = comando_query_High.ExecuteReader())
                        {
                            
                            if (Reader.HasRows)
                            {
                                Console.WriteLine("\nTarefas de 'ALTA' prioridade:");
                                while (Reader.Read())
                                {
                                    Console.WriteLine($"\nNome da tarefa: {Reader["Nome_Task"]} - Descrição da tarefa: {Reader["Descricao_Task"]} - Data de vencimento: {Reader["Data_Task"]} - Prioridade da tarefa: {Reader["Prioridade_Task"]} - Status da tarefa: {Reader["Status_Task"]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNenhuma tarefa com prioridade como 'ALTA' no momento.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado:\n{ex.Message.ToString()}");
                Console_Main.Main(args);
                Console.WriteLine();
            }
        }

        public void QueryTask_Average()
        {
            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_average_string = @"SELECT * FROM All_Task WHERE Prioridade_Task='MEDIA';";
                    using (var comando_query_Average = new MySqlCommand(comando_query_average_string, conexao))
                    {
                        conexao.Open();
                        using (MySqlDataReader Reader = comando_query_Average.ExecuteReader())
                        {
                            
                            if (Reader.HasRows)
                            {
                                Console.WriteLine("\nTarefas de 'MEDIA' prioridade:");
                                while (Reader.Read())
                                {
                                    Console.WriteLine($"\nNome da tarefa: {Reader["Nome_Task"]} - Descrição da tarefa: {Reader["Descricao_Task"]} - Data de vencimento: {Reader["Data_Task"]} - Prioridade da tarefa: {Reader["Prioridade_Task"]} - Status da tarefa: {Reader["Status_Task"]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNenhuma tarefa com prioridade como 'MEDIA' no momento.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado:\n{ex.Message.ToString()}");
                Console_Main.Main(args);
                Console.WriteLine();
            }
        }
        public void QueryTask_Canceled()
        {
            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_low_string = @"SELECT * FROM All_Task WHERE Status_Task='Cancelada';";
                    using (var comando_query_Low = new MySqlCommand(comando_query_low_string, conexao))
                    {
                        conexao.Open();
                        using (MySqlDataReader Reader = comando_query_Low.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                Console.WriteLine("\nTarefas canceladas:");
                                while (Reader.Read())
                                {
                                    Console.WriteLine($"\nNome da tarefa: {Reader["Nome_Task"]} - Descrição da tarefa: {Reader["Descricao_Task"]} - Data de vencimento: {Reader["Data_Task"]} - Prioridade da tarefa: {Reader["Prioridade_Task"]} - Status da tarefa: {Reader["Status_Task"]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNenhuma tarefa com status de 'Cancelada' no momento.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado:\n{ex.Message.ToString()}");
                Console_Main.Main(args);
                Console.WriteLine();
            }
        }

        public void QueryTask_Low()
        {
            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    string comando_query_low_string = @"SELECT * FROM All_Task WHERE Prioridade_Task='BAIXA';";
                    using (var comando_query_Low = new MySqlCommand(comando_query_low_string, conexao))
                    {
                        conexao.Open();
                        using (MySqlDataReader Reader = comando_query_Low.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                Console.WriteLine("\nTarefas de 'BAIXA' prioridade:");
                                while (Reader.Read())
                                {
                                    Console.WriteLine($"\nNome da tarefa: {Reader["Nome_Task"]} - Descrição da tarefa: {Reader["Descricao_Task"]} - Data de vencimento: {Reader["Data_Task"]} - Prioridade da tarefa: {Reader["Prioridade_Task"]} - Status da tarefa: {Reader["Status_Task"]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNenhuma tarefa com prioridade como 'BAIXA' no momento.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado:\n{ex.Message.ToString()}");
                Console_Main.Main(args);
                Console.WriteLine();
            }
        }
    }
}
