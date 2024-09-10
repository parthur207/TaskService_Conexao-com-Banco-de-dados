using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService___Conexão_com_Banco_de_dados.Atributos;
using MySql.Data.MySqlClient;

namespace TaskService___Conexão_com_Banco_de_dados.DataBase.Interface
{
    public interface ITask_Execution //interface que contem os métodos 
    {
        /*Execução dos comandos de exclusão de dados*/
        public void DeleteAll() { }
        public void DeleteData(string nome_task) { }


        /*Execução da inserção de uma nova task*/
        public void InsertData(string nome_task, string descricao_task, DateOnly data_task, Priority prioridade_task, Status_Type status_task) { }//Coletar nova task


        /*Execução dos comandos de consulta de dados (Especifica/Totais/Por status/Por prioridade)*/
        public void QueryData(string nome_task) { }
        public void QueryTask_Completed() { }

        public void QueryData_Full() { }
        public void QueryTask_Pendence() { }
        public void QueryTask_Expired() { }

        public void QueryTask_High() { }
        public void QueryTask_Average() { }
        public void QueryTask_Low() { }


        /*Execução do comando de atualização de dados conforme atributo*/
        public void UpdateData_name(string nome_task) { }
        public void UpdateData_des(string nome_task, string descricao_task) { }
        public void UpdateData_date(string nome_task, DateOnly data_task) { }
        public void UpdateData_pri(string nome_task, Priority prioridade_task) { }
        public void UpdateData_stts(string nome_task, Status_Type status_task) { }
    }
}
