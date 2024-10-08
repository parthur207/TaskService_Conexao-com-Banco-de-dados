﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;
using TaskService___Conexão_com_Banco_de_dados.DataBase;
using MySql.Data.MySqlClient;
using TaskService___Conexão_com_Banco_de_dados.Main;
using TaskService___Conexão_com_Banco_de_dados.TaskService___Armanezamento_dos_dados;
using System.Diagnostics.Eventing.Reader;

namespace TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB
{
    public class UpdateData_exe : QueryData_exe, ITask_Storage
    {
        #region Atributos de validações 
        public static bool aux_up_exe { get; set; } = true;
        public static bool validation1 { get; set; } = true; public static bool validation2 { get; set; } = true; public static bool validation3 { get; set; } = true; public static bool validation4 { get; set; } = true; public static bool validation5 { get; set; } = true; public static bool validation6 { get; set; } = true; public static bool validation7 { get; set; } = true;
        public static bool validation8 { get; set; } = true; 
        #endregion
        public void UpdateData_name(string nome_task, string new_nome_task)
        {
            Nome_Task = nome_task;

            string comando_verificacao_string=@"SELECT Nome_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";

            string ConnectionString=Connect_db.GetConnectionString();

            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up=new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        conexao.Open();
                        comando_validacao_up.Parameters.AddWithValue("@Nome_Task", nome_task);

                        var LinhasAfetadas = comando_validacao_up.ExecuteScalar();

                        if (LinhasAfetadas==null)
                        {
                            Console.WriteLine("\nO nome da tarefa informado não foi encontrado.");
                            aux_up_exe = true; validation1 = true;
                        }
                        else
                        {
                            string comando_up_name_string = "UPDATE All_Task SET Nome_Task=@new_nome_task WHERE Nome_Task=@Nome_Task;";
                            using (var comando_up_name=new MySqlCommand(comando_up_name_string, conexao))
                            {

                                comando_up_name.Parameters.AddWithValue("@new_nome_task", new_nome_task);
                                comando_up_name.Parameters.AddWithValue("@Nome_Task", nome_task);

                                int LinhasAfetadas2=comando_up_name.ExecuteNonQuery();

                                if (LinhasAfetadas2 == 0)
                                {
                                    Console.WriteLine("\nOcorreu um erro na tentativa de atualizar o nome da tarefa solicitada.");

                                    aux_up_exe = true; validation1 = true;
                                }
                                else
                                {
                                    Console.WriteLine($"\nNome da tarefa atualizado com sucesso para ({new_nome_task})");
                                    aux_up_exe = true; validation1 = true; 
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message.ToString()}");
                Console_Main.Main(args);
            }
        }

        public void UpdateData_des(string nome_task_des, string new_descricao_task)
        {
            Nome_Task = nome_task_des;
            Descricao_Task = new_descricao_task;

            string comando_verificacao_string = @"SELECT Descricao_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";
            string ConnectionString = Connect_db.GetConnectionString();

            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up = new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        comando_validacao_up.Parameters.AddWithValue("@Nome_Task", nome_task_des);

                        conexao.Open();

                        var resultado = comando_validacao_up.ExecuteScalar();

                        if (resultado == null)
                        {
                            Console.WriteLine("\nNão foi encontrado nenhuma tarefa com o nome informado.");
                            aux_up_exe = true; validation3 = true; 
                        }
                        else
                        {
                            string comando_up_des_string = "UPDATE All_Task SET Descricao_Task=@Descricao_Task WHERE Nome_Task=@Nome_Task;";

                            using (var comando_up_des = new MySqlCommand(comando_up_des_string, conexao))
                            {
                                comando_up_des.Parameters.AddWithValue("@Descricao_Task", new_descricao_task);
                                comando_up_des.Parameters.AddWithValue("@Nome_Task", nome_task_des);

                                int LinhasAfetadas2 = comando_up_des.ExecuteNonQuery();

                                if (LinhasAfetadas2 == 0)
                                {
                                    Console.WriteLine("\nOcorreu um erro na tentativa de atualizar a descrição da tarefa solicitada.");
                                    aux_up_exe = true; validation3= true; 
                                }
                                else
                                {
                                    Console.WriteLine($"\nDescrição da tarefa atualizada com sucesso. Nova descrição de {nome_task_des}: {new_descricao_task}");
                                    aux_up_exe = true; validation3 = true; 
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message}");
            }
        }

        public void UpdateData_date(string nome_task_data, DateOnly new_data_task)
        {
            Nome_Task=nome_task_data;
            Data_Task=new_data_task;

            string comando_verificacao_string=@"SELECT Data_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";

            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up = new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        conexao.Open();

                        comando_validacao_up.Parameters.AddWithValue("@Nome_Task", nome_task_data);

                        var LinhasAfetadas = comando_validacao_up.ExecuteScalar();

                        if (LinhasAfetadas == null)
                        {
                            Console.WriteLine("\nNão foi encontrado nenhuma tarefa com o nome informado.");
                            aux_up_exe = true; validation5 = true;
                        }
                        else
                        {
                            string comando_up_date_string = "UPDATE All_Task SET Data_Task=@Data_Task WHERE Nome_Task=@Nome_Task;";
                            using (var comando_up_date = new MySqlCommand(comando_up_date_string, conexao))
                            {
                                comando_up_date.Parameters.AddWithValue(@"Data_Task", new_data_task.ToString("yyy-MM-dd"));
                                comando_up_date.Parameters.AddWithValue(@"Nome_Task", nome_task_data);
                                int LinhasAfetadas2 = comando_up_date.ExecuteNonQuery();

                                if (LinhasAfetadas2 == 0)
                                {
                                    Console.WriteLine("\nOcorreu um erro na tentativa de atualizar a data da tarefa solicitada.");
                                    aux_up_exe = true; validation5 = true;

                                }
                                else
                                {
                                    Console.WriteLine($"\nData da tarefa atualizado com sucesso para ({new_data_task})");
                                    aux_up_exe = true; validation5 = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message.ToString()}");
                Console_Main.Main(args);
            }
        }

        public void UpdateData_pri(string nome_task_pri, Priority new_prioridade_task)
        {

            Nome_Task = nome_task_pri;
            Prioridade_Task = new_prioridade_task;

            string comando_verificacao_string = @"SELECT Nome_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";

            string ConnectionString=Connect_db.GetConnectionString();
            try
            {
                using (var conexao=new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up=new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        conexao.Open();

                        comando_validacao_up.Parameters.AddWithValue("@Nome_Task", nome_task_pri);

                        var LinhasAfetadas=comando_validacao_up.ExecuteScalar();

                        if (LinhasAfetadas==null)
                        {
                            Console.WriteLine("\nNão foi encontrado nenhuma tarefa com o nome informado.");
                            aux_up_exe = true; validation4 = true;
                        }
                        else
                        {
                            string comando_up_pri_string="UPDATE All_Task SET Prioridade_Task=@Prioridade_Task WHERE Nome_Task=@Nome_Task;";
                            using (var comando_up_pri=new MySqlCommand(comando_up_pri_string, conexao))
                            {

                                comando_up_pri.Parameters.AddWithValue(@"Nome_Task", nome_task_pri);
                                comando_up_pri.Parameters.AddWithValue(@"Prioridade_Task", new_prioridade_task.ToString());

                                int LinhasAfetadas2= comando_up_pri.ExecuteNonQuery();

                                if (LinhasAfetadas2 == 0)
                                {
                                    Console.WriteLine("\nOcorreu um erro na tentativa de atualizar a prioridade da tarefa solicitada.\n");
                                    aux_up_exe = true; validation4 = true;
                                }
                                else
                                {
                                    Console.WriteLine($"\nPrioridade da tarefa atualizado para: '{Prioridade_Task}'");
                                    aux_up_exe = true; validation4 = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message.ToString()}");
                Console_Main.Main(args);
            }
        }
        public void UpdateData_stts(string nome_task_stts, Status_Type new_status_task)
        {
            Nome_Task = nome_task_stts;
            Status_Task = new_status_task;

            string comando_verificacao_string = @"SELECT Status_Task FROM All_Task WHERE Nome_Task=@Nome_Task;";

            string ConnectionString = Connect_db.GetConnectionString();
            try
            {
                using (var conexao = new MySqlConnection(ConnectionString))
                {
                    using (var comando_validacao_up = new MySqlCommand(comando_verificacao_string, conexao))
                    {
                        conexao.Open();
                        comando_validacao_up.Parameters.AddWithValue(@"Nome_Task",nome_task_stts);

                        var LinhasAfetadas = comando_validacao_up.ExecuteScalar();

                        if (LinhasAfetadas==null)
                        {
                            Console.WriteLine("\nNão foi encontrado nenhuma tarefa com o nome informado.\n");
                            aux_up_exe = true; validation5 = true;
                        }
                        else
                        {
                            //validacao_up5 = false;

                            string comando_up_stts_string = "UPDATE All_Task SET Status_Task=@new_status_task WHERE Nome_Task=@Nome_Task;";
                            using (var comando_up_stts = new MySqlCommand(comando_up_stts_string, conexao)) { 

                                comando_up_stts.Parameters.AddWithValue(@"new_status_task", new_status_task.ToString());
                                comando_up_stts.Parameters.AddWithValue(@"Nome_Task", nome_task_stts);
                            
                                int LinhasAfetadas2=comando_up_stts.ExecuteNonQuery();

                                if (LinhasAfetadas2==0)
                                {
                                    Console.WriteLine("\nOcorreu um erro na tentativa de atualizar o status da tarefa.");
                                    aux_up_exe = true; validation5 = true;
                                }
                                else
                                {
                                    Console.WriteLine($"\nStatus da tarefa atualizado com sucesso para: '{Status_Task}'");
                                    aux_up_exe = true; validation5 = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message.ToString()}");
                Console_Main.Main(args);
            }
        }

    }
}
