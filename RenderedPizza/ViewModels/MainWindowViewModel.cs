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

			PrintJSONinFile();
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

		public void PrintJSONinFile()
		{
			using (System.IO.StreamWriter file = new System.IO.StreamWriter("Pizzas.json"))
			{
				file.WriteLine("{");
				file.WriteLine("\t\"personal_info\":");
				file.WriteLine("\t\t{\"full_name\":\"Nemanja Ilic\", \"email\":\"nemanja.ilic@outlook.com\", \"code_link\": \"https://github.com/NEMANJA-ILIC/RenderedPizza\"},");

				file.Write("\t\"answer\": [{\"group_1\": {\"percentage\": \"");
				file.Write(PizzasWithMeatPercentage);
				file.Write("%\", \"cheapest\":{\"");
				file.Write(cheapestPizzaWithMeat.PizzaName.ToLower());
				file.Write("\":{\"ingredients\":[");
				
				for (int i = 0; i < cheapestPizzaWithMeat.Ingredients.Length - 1; i++)
				{
					file.Write("\"");
					file.Write(cheapestPizzaWithMeat.Ingredients[i]);
					file.Write("\",");
				}
				file.Write("\"");
				file.Write(cheapestPizzaWithMeat.Ingredients.Last());
				file.Write("\"]},\"price\":");

				file.Write(cheapestPizzaWithMeat.Price);
				file.WriteLine("}}},");

				// group_2
				file.Write("\t\t\t\t{\"group_2\": {\"percentage\": \"");
				file.Write(PizzasWithMultipleCheasePercentage);
				file.Write("%\", \"cheapest\":{\"");
				file.Write(cheapestPizzaWithMultipleChease.PizzaName.ToLower());
				file.Write("\":{\"ingredients\":[");

				for (int i = 0; i < cheapestPizzaWithMultipleChease.Ingredients.Length - 1; i++)
				{
					file.Write("\"");
					file.Write(cheapestPizzaWithMultipleChease.Ingredients[i]);
					file.Write("\",");
				}
				file.Write("\"");
				file.Write(cheapestPizzaWithMultipleChease.Ingredients.Last());
				file.Write("\"]},\"price\":");

				file.Write(cheapestPizzaWithMultipleChease.Price);
				file.WriteLine("}}},");

				// group_3
				file.Write("\t\t\t\t{\"group_3\": {\"percentage\": \"");
				file.Write(PizzasWithMeatAndOlivesPercentage);
				file.Write("%\", \"cheapest\":{\"");
				file.Write(cheapestPizzaWithMeatAndOlives.PizzaName.ToLower());
				file.Write("\":{\"ingredients\":[");

				for (int i = 0; i < cheapestPizzaWithMeatAndOlives.Ingredients.Length - 1; i++)
				{
					file.Write("\"");
					file.Write(cheapestPizzaWithMeatAndOlives.Ingredients[i]);
					file.Write("\",");
				}
				file.Write("\"");
				file.Write(cheapestPizzaWithMeatAndOlives.Ingredients.Last());
				file.Write("\"]},\"price\":");

				file.Write(cheapestPizzaWithMeatAndOlives.Price);
				file.WriteLine("}}},");

				// group_4
				file.Write("\t\t\t\t{\"group_4\": {\"percentage\": \"");
				file.Write(PizzasWithMozzarelaAndMushroomsPercentage);
				file.Write("%\", \"cheapest\":{\"");
				file.Write(cheapestPizzaWithMozzarelaAndMushrooms.PizzaName.ToLower());
				file.Write("\":{\"ingredients\":[");

				for (int i = 0; i < cheapestPizzaWithMozzarelaAndMushrooms.Ingredients.Length - 1; i++)
				{
					file.Write("\"");
					file.Write(cheapestPizzaWithMozzarelaAndMushrooms.Ingredients[i]);
					file.Write("\",");
				}
				file.Write("\"");
				file.Write(cheapestPizzaWithMozzarelaAndMushrooms.Ingredients.Last());
				file.Write("\"]},\"price\":");

				file.Write(cheapestPizzaWithMozzarelaAndMushrooms.Price);
				file.WriteLine("}}}]");

				file.WriteLine("}");
			}
		}
	}
}
