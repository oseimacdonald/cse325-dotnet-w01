namespace PizzaApi.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public bool IsGlutenFree { get; set; }
    }
}