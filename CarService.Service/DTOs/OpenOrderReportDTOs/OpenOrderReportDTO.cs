using System.Collections.Generic;

namespace CarService.Service.DTOs.OpenOrderReportDTOs
{
    public class OpenOrderReportDTO
    {
        public List<AvailDetailsOpenOrderReportDTO> AvailDetails { get; set; }
        public decimal LaborTotalPrice { get; set; }
    }
}
