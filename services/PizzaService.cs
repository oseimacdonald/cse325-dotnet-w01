using PizzaApi.Models;

namespace PizzaApi.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }

        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = false },
                new Pizza { Id = 3, Name = "Pepperoni", IsGlutenFree = false },
                new Pizza { Id = 4, Name = "Gluten Free Veggie", IsGlutenFree = true },

                // ⭐ EXTRA RECORD REQUIRED BY ASSIGNMENT
                new Pizza { Id = 5, Name = "BBQ Chicken", IsGlutenFree = false }
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza? Get(int id) =>
            Pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(Pizza pizza)
        {
            pizza.Id = Pizzas.Max(p => p.Id) + 1;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);

            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }
    }
}