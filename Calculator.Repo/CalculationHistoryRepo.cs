using System;
using System.Data;
using System.Data.SqlClient;
using Calculator.Entities;
using Calculator.Repo.Abstract;

namespace Calculator.Repo
{
    public class CalculationHistoryRepo : ICalculationHistoryRepo
    {
        public void Save(CalculationActionDto dto)
        {
            var connection = new SqlConnection(
                "Data Source=.\\SQLEXPRESS;" +
                "Integrated Security=true;" +
                "initial catalog=Calculator;");

            var command = new SqlCommand("SaveCalculationHistory", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddRange(new []
            {
                new SqlParameter("FirstNumber", dto.FirstNumber),
                new SqlParameter("SecondNumber", dto.SecondNumber),
                new SqlParameter("ActionTypeId", dto.ActionType),
                new SqlParameter("Result", dto.Result ?? (object)DBNull.Value )
            });

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
