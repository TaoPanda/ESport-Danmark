using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace ESport_Danmark
{
    class DatabaseConection
    {
        private string connectionString = "Data Source=CV-BB-5988;Initial Catalog=Esport_Danmark;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string tableName;
        string updatingInfoOf;
        string updatedInfo;

        public string TableName { get => tableName; set => tableName = value; }
        public string UpdatingInfoOf { get => updatingInfoOf; set => updatingInfoOf = value; }
        public string UpdatedInfo { get => updatedInfo; set => updatedInfo = value; }

        public DataSet Execute(string query)
        {
            DataSet resultSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }
            return resultSet;
        }
        public void GetFromDatabase(int id)
        {
            string query = $"SELECT * FROM {TableName} WHEN ID = {id}";
            DataSet resultSet = Execute(query);
            DataTable table = resultSet.Tables[0];
            InsetData(table);
        }
        public virtual void InsetData(DataTable dataTable)
        {
        }
        public void DeleteFromDatabase(int id)
        {
            string deletingQurry = $"DELETE FROM {tableName} WHERE Id = '{id}'";
            Execute(deletingQurry);
        }
        public void UpdatingOfInfomation(int id)
        {
            string updatingQurry = $"UPDATE {tableName} SET {updatingInfoOf} = '{UpdatedInfo}' WHERE Id = '{id}'";
            Execute(updatingQurry);
        }
    }
}
