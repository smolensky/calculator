namespace Calculator.Repo.EntityFramework
{
    using System.Data.Entity;

    public class CalculatorContext : DbContext
    {
        public CalculatorContext()
            : base("name=CalculatorContext")
        {
        }

        public virtual DbSet<ActionType> ActionTypes { get; set; }
        public virtual DbSet<CalculationHistory> CalculationHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionType>()
                .HasMany(e => e.CalculationHistories)
                .WithRequired(e => e.ActionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CalculationHistory>()
                .Property(e => e.FirstNumber)
                .HasPrecision(18, 8);

            modelBuilder.Entity<CalculationHistory>()
                .Property(e => e.SecondNumber)
                .HasPrecision(18, 8);

            modelBuilder.Entity<CalculationHistory>()
                .Property(e => e.Result)
                .HasPrecision(18, 8);
        }
    }
}
