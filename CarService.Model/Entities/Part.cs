namespace CarService.Model.Entities
{
    public class Part
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public bool IsReplacement { get; set; }
    }
}
