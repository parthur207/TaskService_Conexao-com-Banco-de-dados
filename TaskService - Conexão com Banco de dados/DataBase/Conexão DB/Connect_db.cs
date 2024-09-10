using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.TaskService___Armanezamento_dos_dados;
using MySql.Data.MySqlClient;

namespace TaskService___Conexão_com_Banco_de_dados.DataBase
{
    public class Connect_db : InsertData_s
    {
        protected const string ConnectString = @"Server=127.0.0.1;Port=3306;Database=Task;User ID=root;Password=Admin;";

        public static string GetConnectionString() //Vinculado a "ConnectString" - Tipagem: (Protect) - Com isso será possível o acesso aos valores contidos ao "Path" do DB. 
        {
            return ConnectString;
        }
        public void Conexao()
        {

            using (var cnn = new MySqlConnection(ConnectString))
            {
                try
                {
                    cnn.Open();
                    //Console.WriteLine("Conectado.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nErro ao se conectar ao banco. Erro: {ex.ToString()}");
                }
            }
        }
    }
}
