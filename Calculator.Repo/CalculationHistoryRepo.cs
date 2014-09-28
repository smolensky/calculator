using System.Data.SqlClient;
using Calculator.Entities;

namespace Calculator.Repo
{
    public class CalculationHistoryRepo
    {
        void Save(CalculationActionDto dto)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=.\\SQLEXPRESS;" +
                "Integrated Security=true;" +
                "initial catalog=Calculator;");

            var command = new SqlCommand("GetCalculationHistory");
        }
    }
}
