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

		public static List<PizzaModel> getPizzasWithMeat(List<PizzaModel> pizzasToChose)
		{
			List<PizzaModel> PizzasWithMeat = new List<PizzaModel>();
			foreach (PizzaModel pizza in pizzasToChose)
			{
				foreach (string pizzaIngredient in pizza.Ingredients)
				{
					if (pizzaIngredient.Contains("meat") || pizzaIngredient.Contains("ham") || pizzaIngredient.Contains("sausage") || pizzaIngredient.Contains("salami") || pizzaIngredient.Contains("shrimps") || pizzaIngredient.Contains("mussels") || pizzaIngredient.Contains("tuna") || pizzaIngredient.Contains("calamari") || pizzaIngredient.Contains("anchovies") || pizzaIngredient.Contains("kebab") || pizzaIngredient.Contains("beef"))
					{
						PizzasWithMeat.Add(pizza);
						break;
					}
				}
			}

			return PizzasWithMeat;
		}

		public static List<PizzaModel> getPizzasWithMultipleChease(List<PizzaModel> pizzasToChose)
		{
			List<PizzaModel> pizzasWithMultipleChease = new List<PizzaModel>();
			foreach (PizzaModel pizza in pizzasToChose)
			{
				int cheeseCount = 0;
				foreach (string pizzaIngredient in pizza.Ingredients)
				{
					if (pizzaIngredient.Contains("cheese") || pizzaIngredient.Contains("mozzarella"))
					{
						++cheeseCount;
					}

					if (cheeseCount > 1)
					{
						pizzasWithMultipleChease.Add(pizza);
						break;
					}
				}
			}
			return pizzasWithMultipleChease;
		}

		public static List<PizzaModel> getPizzasWithMeatAndOlives(List<PizzaModel> pizzasToChose)
		{
			List<PizzaModel> pizzasWithMeatAndOlives = new List<PizzaModel>();
			foreach (PizzaModel pizza in pizzasToChose)
			{
				foreach (string pizzaIngredient in pizza.Ingredients)
				{
					if (pizzaIngredient.Contains("olive"))
					{
						pizzasWithMeatAndOlives.Add(pizza);
						break;
					}
				}
			}

			return pizzasWithMeatAndOlives;
		}

		public static List<PizzaModel> getPizzasWithMozzarelaAndMushrooms(List<PizzaModel> pizzasToChose)
		{
			List<PizzaModel> pizzasWithMozzarelaAndMushrooms = new List<PizzaModel>();
			foreach (PizzaModel pizza in pizzasToChose)
			{
				Boolean containsMozzarella = false;
				Boolean containsMushrooms = false;
				foreach (string pizzaIngredient in pizza.Ingredients)
				{
					if (pizzaIngredient.Contains("mozzarella"))
					{
						containsMozzarella = true;
					}
					else
					{
						if (pizzaIngredient.Contains("mushroom"))
						{
							containsMushrooms = true;
						}
					}

					if (containsMozzarella && containsMushrooms)
					{
						pizzasWithMozzarelaAndMushrooms.Add(pizza);
						break;
					}
				}
			}

			return pizzasWithMozzarelaAndMushrooms;
		}
	}
}
