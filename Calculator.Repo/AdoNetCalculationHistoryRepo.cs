using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Calculator.Entities;
using Calculator.Repo.Abstract;

namespace Calculator.Repo
{
    public class AdoNetCalculationHistoryRepo : ICalculationHistoryRepo
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

        public IList<CalculationActionDto> Load()
        {
            var connection = new SqlConnection(
                "Data Source=.\\SQLEXPRESS;" +
                "Integrated Security=true;" +
                "initial catalog=Calculator;");

            var command = new SqlCommand("GetAllCalculationHistory", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            var result = new List<CalculationActionDto>();

            while (reader.Read())
            {
                var calculationActionDto = new CalculationActionDto(
                    (double)((decimal)reader["FirstNumber"]),
                    (double)((decimal) reader["SecondNumber"]),
                    GetActionType(reader),
                    GetCalculationResult(reader));

                result.Add(calculationActionDto);
            }

            connection.Close();

            return result;
        }

        private static ActionType GetActionType(SqlDataReader reader)
        {
            ActionType actionType;

            if (!Enum.TryParse((string) reader["ActionType"], out actionType))
                throw new DataException("Wrong data in a database for ActionType");

            return actionType;
        }

        private static double? GetCalculationResult(SqlDataReader reader)
        {
            if (reader["Result"] == DBNull.Value)
                return null;

            double calculationResult;

            if (!double.TryParse(reader["Result"].ToString(), out calculationResult))
                throw new DataException("Wrong data in a database for ActionType");

            return calculationResult;
        }
    }
}
