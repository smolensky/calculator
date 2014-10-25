using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        public IList<CalculationActionDto> Load()
        {
            using (var db = new CalculatorContext())
            {
                IEnumerable<CalculationActionDto> calculationActionDtos
                    = db.CalculationHistories.AsEnumerable().Select(ch =>
                        new CalculationActionDto((double)ch.FirstNumber,
                            (double)ch.SecondNumber,
                            Entities.ActionType.Plus,
                            //(Entities.ActionType)Enum.Parse(typeof(ActionType), ch.ActionType.ActionType1), 
                            (double?) ch.Result));


                return calculationActionDtos.ToList();

                //foreach (var item in query)
                //{
                //        calculationHistories.Add(item.FirstNumber.ToString(CultureInfo.InvariantCulture));
                //        calculationHistories.Add(item.ActionType.ToString());
                //        calculationHistories.Add(item.SecondNumber.ToString(CultureInfo.InvariantCulture));
                //        calculationHistories.Add(item.Result.ToString());
                //}
            }
        }
    }
}