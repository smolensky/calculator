using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using Calculator.Entities;
using Calculator.Repo.Abstract;

namespace Calculator.Repo.EntityFramework
{
    public class EntityFrameworkCalculationHistoryRepo : ICalculationHistoryRepo
    {
        public void Save(CalculationActionDto dto)
        {
            using (var db = new CalculatorContext())
            {
                var calculationHistory = new CalculationHistory
                {
                    ActionTypeId = (int) dto.ActionType,
                    CreationDate = DateTime.UtcNow,
                    FirstNumber = (decimal) dto.FirstNumber,
                    SecondNumber = (decimal) dto.SecondNumber,
                    Result = (decimal?) dto.Result,
                    UserId = 1
                };

                db.CalculationHistories.Add(calculationHistory);

                db.SaveChanges();
            }
        }

        public ICollection<CalculationActionDto> Load()
        {
            throw new NotImplementedException();
        }
    }
}