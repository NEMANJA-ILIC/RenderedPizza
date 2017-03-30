using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenderedPizza.Models;
using System.Collections.ObjectModel;

namespace RenderedPizza.Helpers
{
	public class PizzasRepacker
	{
		public static ObservableCollection<PizzaModel> RepackPizzas(JSONPizzasModel jsonPizzasModel)
		{
			ObservableCollection<PizzaModel> tempPizzaModels = new ObservableCollection<PizzaModel>();

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

		public static ObservableCollection<PizzaModel> getPizzasWithMeat(ObservableCollection<PizzaModel> pizzasToChose)
		{
			ObservableCollection<PizzaModel> PizzasWithMeat = new ObservableCollection<PizzaModel>();
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

		public static ObservableCollection<PizzaModel> getPizzasWithMultipleChease(ObservableCollection<PizzaModel> pizzasToChose)
		{
			ObservableCollection<PizzaModel> pizzasWithMultipleChease = new ObservableCollection<PizzaModel>();
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

		public static ObservableCollection<PizzaModel> getPizzasWithMeatAndOlives(ObservableCollection<PizzaModel> pizzasToChose)
		{
			ObservableCollection<PizzaModel> pizzasWithMeatAndOlives = new ObservableCollection<PizzaModel>();
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

		public static ObservableCollection<PizzaModel> getPizzasWithMozzarelaAndMushrooms(ObservableCollection<PizzaModel> pizzasToChose)
		{
			ObservableCollection<PizzaModel> pizzasWithMozzarelaAndMushrooms = new ObservableCollection<PizzaModel>();
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
