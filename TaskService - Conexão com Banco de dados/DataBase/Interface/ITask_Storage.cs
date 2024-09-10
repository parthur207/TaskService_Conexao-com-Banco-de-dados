using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TaskService___Conexão_com_Banco_de_dados.DataBase.Interface
{
    public interface ITask_Storage : ITask_Execution//Interface que colhe os dados 
    {
        public void Storage_DeleteAll(ITask_Execution aux_dlt_all) { }//Colhe os dados para apontamento a classe 'DeleteAll_exe'
        public void Storage_DeleteData(ITask_Execution aux_dlt) { }//Colhe os dados para apontamento a classe 'DeleteData_exe'
        public void Storage_InsertData(ITask_Execution aux_ins) { }//Colhe os dados para apontamento a classe 'InsertData_exe'
        public void Storage_QueryData(ITask_Execution aux_qr) { }//Colhe os dados para apontamento a classe 'QueryData_exe'
        public void Storage_UpdateData(ITask_Execution aux_up) { }//Colhe os dados para apontamento a classe  'UpdateData_exe'
    }
}
