using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TaskService___Conexão_com_Banco_de_dados.DataBase.Interface;

namespace TaskService___Conexão_com_Banco_de_dados.Atributos
{
    public class Task_Attributes
    {
        #region Password (Deletar banco)
        private string Password = "Foco!";
        protected string Password_Acess { get { return Password; } }

        #endregion

        protected string Nome_Task { get; set; }
        protected string Descricao_Task { get; set; }
        protected DateOnly Data_Task { get; set; }
        protected Priority Prioridade_Task { get; set; } //Atributo incluso com tipagem "Priority" com vinculação a um enum, permitindo somente três tipos de valores de atribuição.
        protected Status_Type Status_Task { get; set; } //Atributo incluso de tipagem "StatusTask" com vinculação a um enum, permitindo somente três tipos de valores a se atribuir.

        public DateOnly Data_Atual = DateOnly.FromDateTime(DateTime.Now); //Atributo com a data atual para comparativos.


    }
    public enum Priority //Criação de uma tipagem "Priority", vinculada a um "Enum" dando a possibilidade de atribuir somente os tres valores a variavel "TaskPriority".
    {
        ALTA, //Alta prioridade
        MEDIA, //Media prioridade
        BAIXA //Baixa prioridade
    }
    public enum Status_Type //Criação de uma tipagem "StatusTask", vinculada a um "Enum" dando a possibilidade de atribuir somente os dois valores a variavel "TaskCompleted"
    {
        Expirada,
        Pendente,
        Cancelada,
        Finalizada
    }
}
