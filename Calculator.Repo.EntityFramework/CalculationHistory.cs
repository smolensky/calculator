namespace Calculator.Repo.EntityFramework
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CalculationHistory")]
    public class CalculationHistory
    {
        public int Id { get; set; }

        public decimal FirstNumber { get; set; }

        public decimal SecondNumber { get; set; }

        public int ActionTypeId { get; set; }

        public decimal? Result { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }

        public virtual ActionType ActionType { get; set; }
    }
}
