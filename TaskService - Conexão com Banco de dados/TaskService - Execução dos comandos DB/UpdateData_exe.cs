using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using TaskService___Conexão_com_Banco_de_dados.DataBase;
using MySql.Data.MySqlClient;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB
{
    public class UpdateData_exe : QueryData_exe, ITask_Storage
    {
        public void UpdateData_name(string nome_task)
        {

            Nome_Task = nome_task;

            string comando_verificacao_string = @"Use Task;SELECT Nome_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";

            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up = new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        conexao.Open();
            

                        int LinhasAfetadas = comando_validacao_up.ExecuteNonQuery();

                        if (LinhasAfetadas == 0)
                        {
                            Console.WriteLine("\nO nome da tarefa informado não foi encontrado.\n");
                        }
                        else
                        {
                            string comando_up_name_string = "UPDATE All_Task SET Nome_Task=@Nome_Task;";
                            using (var comando_up_name = new MySqlCommand(comando_up_name_string, conexao))
                            {
                                comando_up_name.ExecuteNonQuery();

                                int LinhasAfetadas2 = comando_up_name.ExecuteNonQuery();

                                if (LinhasAfetadas2 == 0)
                                {
                                    Console.WriteLine("\nNão foi encontrado nenhuma tarefa com o nome informado.\n");
                                }
                                else
                                {
                                    Console.WriteLine($"\nNome da tarefa atualizado com sucesso para {Nome_Task}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message.ToString()}");
            }

        }
        public void UpdateData_des(string nome_task_des, string new_descricao_task)
        {
            Nome_Task = nome_task_des;
            Descricao_Task = new_descricao_task;

            string comando_verificacao_string = @"Use Task;SELECT Nome_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";

            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up = new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        conexao.Open();
                     

                        int LinhasAfetadas = comando_validacao_up.ExecuteNonQuery();

                        if (LinhasAfetadas == 0)
                        {
                            Console.WriteLine("\nNão foi encontrado nenhuma tarefa com o nome informado.\n");
                        }
                        else
                        {

                            string comando_up_name_string = "UPDATE All_Task SET Nome_Task=@Nome_Task;";
                            using (var comando_up_name = new MySqlCommand(comando_up_name_string, conexao))
                            {
                            

                                int LinhasAfetadas2 = comando_up_name.ExecuteNonQuery();

                                if (LinhasAfetadas2 == 0)
                                {
                                    Console.WriteLine("\nO nome da tarefa informado não foi encontrado.\n");
                                }
                                else
                                {
                                    Console.WriteLine($"\nNome da tarefa atualizado com sucesso para {Nome_Task}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message.ToString()}");
            }

        }
        public void UpdateData_date(string nome_task_data, DateOnly new_data_task)
        {
            Nome_Task = nome_task_data;
            Data_Task = new_data_task;

            string comando_verificacao_string = @"Use Task;SELECT Nome_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";

            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up = new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        conexao.Open();
                        

                        int LinhasAfetadas = comando_validacao_up.ExecuteNonQuery();

                        if (LinhasAfetadas == 0)
                        {
                            Console.WriteLine("\nNão foi encontrado nenhuma tarefa com o nome informado.\n");
                        }
                        else
                        {

                            string comando_up_name_string = "UPDATE All_Task SET Data_Task=@Data_Task;";
                            using (var comando_up_name = new MySqlCommand(comando_up_name_string, conexao))
                            {

                                int LinhasAfetadas2 = comando_up_name.ExecuteNonQuery();

                                if (LinhasAfetadas2 == 0)
                                {
                                    Console.WriteLine("\nO nome da tarefa informado não foi encontrado.\n");
                                }
                                else
                                {
                                    Console.WriteLine($"\nNome da tarefa atualizado com sucesso para {Nome_Task}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message.ToString()}");
            }

        }

        public void UpdateData_pri(string nome_task_pri, Priority new_prioridade_task)
        {

            Nome_Task = nome_task_pri;
            Prioridade_Task = new_prioridade_task;

            string comando_verificacao_string = @"Use Task;SELECT Nome_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";

            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up = new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        conexao.Open();
                        

                        int LinhasAfetadas = comando_validacao_up.ExecuteNonQuery();

                        if (LinhasAfetadas == 0)
                        {
                            Console.WriteLine("\nNão foi encontrado nenhuma tarefa com o nome informado.\n");
                        }
                        else
                        {

                            string comando_up_name_string = "Use Task;UPDATE All_Task SET Prioridade_Task=@Prioridade_Task;";
                            using (var comando_up_name = new MySqlCommand(comando_up_name_string, conexao))
                            {
                                

                                int LinhasAfetadas2 = comando_up_name.ExecuteNonQuery();

                                if (LinhasAfetadas2 == 0)
                                {
                                    Console.WriteLine("\nOcorreu um erro ao tentar atualizar o status da tarefa.");
                                }
                                else
                                {
                                    Console.WriteLine($"\nPrioridade da tarefa atualizado para: '{Prioridade_Task}'");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message.ToString()}");
            }
        }
        public void UpdateData_stts(string nome_task_stts, Status_Type new_status_task)
        {
            Nome_Task = nome_task_stts;
            Status_Task = new_status_task;

            string comando_verificacao_string = @"Use Task;SELECT Nome_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";

            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up = new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        conexao.Open();
                        

                        int LinhasAfetadas = comando_validacao_up.ExecuteNonQuery();

                        if (LinhasAfetadas == 0)
                        {
                            Console.WriteLine("\nNão foi encontrado nenhuma tarefa com o nome informado.\n");
                        }
                        else
                        {
                            //validacao_up5 = false;

                            string comando_up_stts_string = "UPDATE All_Task SET Staus_Task=@Status_Task;";
                            using (var comando_up_stts = new MySqlCommand(comando_up_stts_string, conexao))
                            {
                                

                                int LinhasAfetadas2 = comando_up_stts.ExecuteNonQuery();

                                if (LinhasAfetadas2 == 0)
                                {
                                    Console.WriteLine("\nOcorreu um erro na tentativa de atualizar o status da task.");
                                }
                                else
                                {
                                    Console.WriteLine($"\nStatus da tarefa atualizado com sucesso para: '{Status_Task}'");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message.ToString()}");
            }

        }

    }
}
