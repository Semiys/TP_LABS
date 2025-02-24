using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab5Web.Models
{
    public class CashCollection
    {
        [DisplayName("Номер маршрута")]
        public int RouteNumber { get; set; }

        [DisplayName("ФИО инкассатора")]
        public string CollectorName { get; set; }

        [DisplayName("Сумма инкассации")]
		
		public decimal Amount { get; set; }
        [DisplayName("Дата и время инкассации")]
        public DateTime CollectionDateTime { get; set; }
        [DisplayName("Статус выполнения")]
        public bool IsCompleted { get; set; }
        [DisplayName("Примечания")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }
}
