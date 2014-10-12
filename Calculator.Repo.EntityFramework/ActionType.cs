namespace Calculator.Repo.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActionType")]
    public partial class ActionType
    {
        public ActionType()
        {
            CalculationHistories = new HashSet<CalculationHistory>();
        }

        public int Id { get; set; }

        [Column("ActionType")]
        [Required]
        [StringLength(20)]
        public string ActionType1 { get; set; }

        public virtual ICollection<CalculationHistory> CalculationHistories { get; set; }
    }
}
