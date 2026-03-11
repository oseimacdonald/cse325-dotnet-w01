using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using PizzaApi.Services;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzasController : ControllerBase
    {
        // GET /pizzas
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll()
        {
            return PizzaService.GetAll();
        }

        // GET /pizzas/5
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        // POST /pizzas
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);

            return CreatedAtAction(
                nameof(Get),
                new { id = pizza.Id },
                pizza);
        }

        // DELETE /pizzas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}