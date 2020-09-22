using System.ComponentModel.DataAnnotations;

namespace ExpensesManagement.api.Dtos
{
    public class EmpTaxDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int FoodAmount { get; set; }
        public int FuelAmount { get; set; }
        public int HraAmount { get; set; }
        public int TravelAmount { get; set; }
        public string FoodPath { get; set; }
        public string FuelPath { get; set; }
        public string HraPath { get; set; }
        public string TravelPath { get; set; }
    }
}