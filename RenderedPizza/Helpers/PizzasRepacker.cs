using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenderedPizza.Models;

namespace RenderedPizza.Helpers
{
	public class PizzasRepacker
	{
		public static List<PizzaModel> RepackPizzas(JSONPizzasModel jsonPizzasModel)
		{
			List<PizzaModel> tempPizzaModels = new List<PizzaModel>();

			foreach (Pizza pizza in jsonPizzasModel.pizzas)	
			{
				if (pizza.nil != null)
					continue;
				PizzaModel tempPizza = new PizzaModel();

				tempPizza.PizzaName = pizza.name;
				tempPizza.Price = pizza.price;
				object pizzaType = pizza.GetType().GetProperty(tempPizza.PizzaName).GetValue(pizza, null);
				object pizzaIngredients = pizzaType.GetType().GetProperty("ingredients").GetValue(pizzaType, null);
				tempPizza.Ingredients = (string[])pizzaIngredients;
				tempPizzaModels.Add(tempPizza);
			}

			return tempPizzaModels;
		}
	}
}
