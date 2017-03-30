using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenderedPizza.Helpers;
using RenderedPizza.Models;
using Weather3.Helpers;

namespace RenderedPizza.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public MainWindowViewModel()
		{
			pizzas = new ObservableCollection<PizzaModel>();
			PizzasWithMeat = new ObservableCollection<PizzaModel>();
			PizzasWithMultipleChease = new ObservableCollection<PizzaModel>();
			PizzasWithMeatAndOlives = new ObservableCollection<PizzaModel>();
			PizzasWithMozzarelaAndMushrooms = new ObservableCollection<PizzaModel>();
		}

		public ObservableCollection<PizzaModel> PizzasWithMeat { get; set; }
		public ObservableCollection<PizzaModel> PizzasWithMultipleChease { get; set; }
		public ObservableCollection<PizzaModel> PizzasWithMeatAndOlives { get; set; }
		public ObservableCollection<PizzaModel> PizzasWithMozzarelaAndMushrooms { get; set; }

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

		private ObservableCollection<PizzaModel> pizzas;
		public ObservableCollection<PizzaModel> Pizzas
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

			PizzasWithMeat = PizzasRepacker.getPizzasWithMeat(pizzas);
			OnPropertyChanged("PizzasWithMeat");
			PizzasWithMultipleChease = PizzasRepacker.getPizzasWithMultipleChease(pizzas);
			OnPropertyChanged("PizzasWithMultipleChease");
			PizzasWithMeatAndOlives = PizzasRepacker.getPizzasWithMeatAndOlives(PizzasWithMeat);
			OnPropertyChanged("PizzasWithMeatAndOlives");
			PizzasWithMozzarelaAndMushrooms = PizzasRepacker.getPizzasWithMozzarelaAndMushrooms(pizzas);
			OnPropertyChanged("PizzasWithMozzarelaAndMushrooms");

			CalculatePercentages();
			FindCheapestPizzas();

			PrintJSONinFile();
		}

		public void CalculatePercentages()
		{
			PizzasWithMeatPercentage = (PizzasWithMeat.Count / (double)pizzas.Count) * 100;
			PizzasWithMultipleCheasePercentage = (PizzasWithMultipleChease.Count / (double)pizzas.Count) * 100;
			PizzasWithMeatAndOlivesPercentage = (PizzasWithMeatAndOlives.Count / (double)pizzas.Count) * 100;
			PizzasWithMozzarelaAndMushroomsPercentage = (PizzasWithMozzarelaAndMushrooms.Count / (double)pizzas.Count) * 100;
		}

		public void FindCheapestPizzas()
		{
			PizzaModel tempPizza = new PizzaModel();
			tempPizza = PizzasWithMeat.FirstOrDefault();
			foreach (PizzaModel pizza in PizzasWithMeat)
			{
				if (pizza.Price < tempPizza.Price)
				{
					tempPizza = pizza;
				}
			}
			CheapestPizzaWithMeat = tempPizza;

			tempPizza = PizzasWithMultipleChease.FirstOrDefault();
			foreach (PizzaModel pizza in PizzasWithMultipleChease)
			{
				if (pizza.Price < tempPizza.Price)
				{
					tempPizza = pizza;
				}
			}
			CheapestPizzaWithMultipleChease = tempPizza;

			tempPizza = PizzasWithMeatAndOlives.FirstOrDefault();
			foreach (PizzaModel pizza in PizzasWithMeatAndOlives)
			{
				if (pizza.Price < tempPizza.Price)
				{
					tempPizza = pizza;
				}
			}
			CheapestPizzaWithMeatAndOlives = tempPizza;

			tempPizza = PizzasWithMozzarelaAndMushrooms.FirstOrDefault();
			foreach (PizzaModel pizza in PizzasWithMozzarelaAndMushrooms)
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
