using CarService.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Model.Entities
{
    public enum AvailStatusEnum : int
    {
        [StringValue("Oczekiwanie na części")]
        WaitingForParts,
        [StringValue("Zakończona")]
        Finished,
        [StringValue("Brak prac")]
        NoWork,
        [StringValue("Praca w toku")]
        WorkInProgress,
        [StringValue("Domówienie brakujących części")]
        OrderingTheMissingParts
    }

    public class AvailStatus
    {
        public int Id { get; set; }

        public string StatusName { get; set; }
    }
}
