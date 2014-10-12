using Calculator.Entities;

namespace Calculator.Repo.Abstract
{
    public interface ICalculationHistoryRepo
    {
        void Save(CalculationActionDto dto);
    }
}