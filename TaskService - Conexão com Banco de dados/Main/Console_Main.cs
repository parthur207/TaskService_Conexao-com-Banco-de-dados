using MySql.Data.MySqlClient;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using TaskService___Conexão_com_Banco_de_dados.TaskService___Armanezamento_dos_dados;
using TaskService___Conexão_com_Banco_de_dados.TaskService___Execução_dos_comandos_DB;
using TaskService___Conexão_com_Banco_de_dados.Verificação_de_data___Task_Expired;
using System;
using TaskService___Conexão_com_Banco_de_dados.DataBase;
using System.Security.Cryptography.X509Certificates;

namespace TaskService___Conexão_com_Banco_de_dados.Main
{
    public class Console_Main : Connect_db
    {
        public static void Main(string[] args)
        {
            
            #region Instanciação de objetos
            Connect_db auxiliador_cnn = new Connect_db();

            DeleteAll_s auxiliador_dlt_all = new DeleteAll_s();
            DeleteData_s auxiliador_dlt = new DeleteData_s();
            InsertData_s auxiliador_ins = new InsertData_s();
            QueryData_s auxiliador_qr = new QueryData_s();
            UpdateData_s auxiliador_up = new UpdateData_s();

            Task_Attributes aux_date = new Task_Attributes();

            DeleteAll_exe aux_DltAll_exe = new DeleteAll_exe();
            DeleteData_exe aux_dlt_exe = new DeleteData_exe();
            InsertData_exe aux_Ins_exe = new InsertData_exe();
            QueryData_exe aux_Qr_exe = new QueryData_exe();
            UpdateData_exe aux_Up_exe = new UpdateData_exe();

            Static_Count_Task aux_count = new Static_Count_Task();
            #endregion


            while (auxiliador_cnn.validacao_conexao)
            {

                
                VerificationDate.VerificationDate_Expired(aux_date);

                Console.WriteLine("Task Service\n");
                Console.WriteLine("Menu CRUD");
                Console.WriteLine("1. Adicionar Tarefa.");
                Console.WriteLine("2. Deletar tarefa.");
                Console.WriteLine("3. Atualizar atributo de uma tarefa.");
                Console.WriteLine("4. Realizar consulta de uma tarefa.");
                Console.WriteLine("5. Exibir numero de tarefas atuais.");
                Console.WriteLine("6. Sair");
                if (!int.TryParse(Console.ReadLine(), out int op) || op < 1 || op > 6)
                {
                    Console.WriteLine("\nOpção inválida");
                    Console.WriteLine("\nDigite novamente.\n");
                }
                else
                {
                    auxiliador_cnn.Conexao();
                }
                while (auxiliador_cnn.validacao_conexao) {
                    switch (op)
                    {
                        case 1:
                            auxiliador_ins.Storage_InsertData(aux_Ins_exe);
                            break;

                        case 2:
                            Console.WriteLine("\n1. Remover linha, ou dado específico.\n2. Apagar todos os dados no diretório.");
                            if (!int.TryParse(Console.ReadLine(), out int op_delete) || op_delete < 1 || op_delete > 2)
                            {
                                Console.WriteLine("É necessário digitar um numero, sendo 1 ou 2.\n");
                            }
                            else
                            {
                                if (op_delete == 1)
                                {
                                    auxiliador_dlt.Storage_DeleteData(aux_dlt_exe);
                                }
                                else if (op_delete == 2)
                                {
                                    auxiliador_dlt_all.Storage_DeleteAll(aux_DltAll_exe);
                                }
                            }
                            break;

                        case 3:
                            auxiliador_up.Storage_UpdateData(aux_Up_exe);
                            break;

                        case 4:
                            auxiliador_qr.Storage_QueryData(aux_Qr_exe);
                            break;
                        case 5:
                            int NumeroTarefas= ContarTarefas();
                            Console.WriteLine($"\nNumero de tarefas presentes: {NumeroTarefas}\n");
                            Console_Main.Main(args);
                            break;

                        case 6:
                            Console.WriteLine("\nPrograma Encerrado.");
                            string ConnectionString_main = GetConnectionString();
                            using (var close_db = new MySqlConnection(ConnectionString_main))
                            {
                                close_db.Close();//interrompe a conexão com o banco
                            }
                            return;

                    }
                }
            }
        }
    }
}
