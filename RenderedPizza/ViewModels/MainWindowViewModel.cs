using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenderedPizza.Helpers;
using RenderedPizza.Models;

namespace RenderedPizza.ViewModels
{
	public class MainWindowViewModel
	{
		public MainWindowViewModel()
		{
			pizzas = new List<PizzaModel>();
			pizzasWithMeat = new List<PizzaModel>();
			pizzasWithMultipleChease = new List<PizzaModel>();
			pizzasWithMeatAndOlives = new List<PizzaModel>();
			pizzasWithMozzarelaAndMushrooms = new List<PizzaModel>();
		}

		private List<PizzaModel> pizzasWithMeat;
		private List<PizzaModel> pizzasWithMultipleChease;
		private List<PizzaModel> pizzasWithMeatAndOlives;
		private List<PizzaModel> pizzasWithMozzarelaAndMushrooms;

		private double pizzasWithMeatPercentage;
		public double PizzasWithMeatPercentage
		{
			get { return pizzasWithMeatPercentage; }
			set
			{
				pizzasWithMeatPercentage = value;
			}
		}
		private double pizzasWithMultipleCheasePercentage;
		public double PizzasWithMultipleCheasePercentage
		{
			get { return pizzasWithMultipleCheasePercentage; }
			set
			{
				pizzasWithMultipleCheasePercentage = value;
			}
		}
		private double pizzasWithMeatAndOlivesPercentage;
		public double PizzasWithMeatAndOlivesPercentage
		{
			get { return pizzasWithMeatAndOlivesPercentage; }
			set
			{
				pizzasWithMeatAndOlivesPercentage = value;
			}
		}
		private double pizzasWithMozzarelaAndMushroomsPercentage;
		public double PizzasWithMozzarelaAndMushroomsPercentage
		{
			get { return pizzasWithMozzarelaAndMushroomsPercentage; }
			set
			{
				pizzasWithMozzarelaAndMushroomsPercentage = value;
			}
		}

		private PizzaModel cheapestPizzaWithMeat;
		public PizzaModel CheapestPizzaWithMeat
		{
			get { return cheapestPizzaWithMeat; }
			set { cheapestPizzaWithMeat = value; }
		}
		private PizzaModel cheapestPizzaWithMultipleChease;
		public PizzaModel CheapestPizzaWithMultipleChease
		{
			get { return cheapestPizzaWithMultipleChease; }
			set { cheapestPizzaWithMultipleChease = value; }
		}
		private PizzaModel cheapestPizzaWithMeatAndOlives;
		public PizzaModel CheapestPizzaWithMeatAndOlives
		{
			get { return cheapestPizzaWithMeatAndOlives; }
			set { cheapestPizzaWithMeatAndOlives = value; }
		}
		private PizzaModel cheapestPizzaWithMozzarelaAndMushrooms;
		public PizzaModel CheapestPizzaWithMozzarelaAndMushrooms
		{
			get { return cheapestPizzaWithMozzarelaAndMushrooms; }
			set { cheapestPizzaWithMozzarelaAndMushrooms = value; }
		}

		private List<PizzaModel> pizzas;
		public List<PizzaModel> Pizzas
		{
			get
			{
				return pizzas;
			}
			set
			{
				pizzas = value;
			}
		}

		public void LoadPizzas()
		{
			string pizzasUrl = "http://coding-challenge.renderedtext.com/";

			JSONPizzasModel jsonPizzasModel = LargeJSON.JSONmanipulator._download_serialized_json_data<JSONPizzasModel>(pizzasUrl);

			pizzas = RenderedPizza.Helpers.PizzasRepacker.RepackPizzas(jsonPizzasModel);

			pizzasWithMeat = PizzasRepacker.getPizzasWithMeat(pizzas);
			pizzasWithMultipleChease = PizzasRepacker.getPizzasWithMultipleChease(pizzas);
			pizzasWithMeatAndOlives = PizzasRepacker.getPizzasWithMeatAndOlives(pizzasWithMeat);
			pizzasWithMozzarelaAndMushrooms = PizzasRepacker.getPizzasWithMozzarelaAndMushrooms(pizzas);

			CalculatePercentages();
			FindCheapestPizzas();
		}

		public void CalculatePercentages()
		{
			PizzasWithMeatPercentage = (pizzasWithMeat.Count / (double)pizzas.Count) * 100;
			PizzasWithMultipleCheasePercentage = (pizzasWithMultipleChease.Count / (double)pizzas.Count) * 100;
			PizzasWithMeatAndOlivesPercentage = (pizzasWithMeatAndOlives.Count / (double)pizzas.Count) * 100;
			PizzasWithMozzarelaAndMushroomsPercentage = (pizzasWithMozzarelaAndMushrooms.Count / (double)pizzas.Count) * 100;
		}

		public void FindCheapestPizzas()
		{
			PizzaModel tempPizza = new PizzaModel();
			tempPizza = pizzasWithMeat.FirstOrDefault();
			foreach (PizzaModel pizza in pizzasWithMeat)
			{
				if (pizza.Price < tempPizza.Price)
				{
					tempPizza = pizza;
				}
			}
			CheapestPizzaWithMeat = tempPizza;

			tempPizza = pizzasWithMultipleChease.FirstOrDefault();
			foreach (PizzaModel pizza in pizzasWithMultipleChease)
			{
				if (pizza.Price < tempPizza.Price)
				{
					tempPizza = pizza;
				}
			}
			CheapestPizzaWithMultipleChease = tempPizza;

			tempPizza = pizzasWithMeatAndOlives.FirstOrDefault();
			foreach (PizzaModel pizza in pizzasWithMeatAndOlives)
			{
				if (pizza.Price < tempPizza.Price)
				{
					tempPizza = pizza;
				}
			}
			CheapestPizzaWithMeatAndOlives = tempPizza;

			tempPizza = pizzasWithMozzarelaAndMushrooms.FirstOrDefault();
			foreach (PizzaModel pizza in pizzasWithMozzarelaAndMushrooms)
			{
				if (pizza.Price < tempPizza.Price)
				{
					tempPizza = pizza;
				}
			}
			CheapestPizzaWithMozzarelaAndMushrooms = tempPizza;
		}
	}
}
