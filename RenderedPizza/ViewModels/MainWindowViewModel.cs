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
		}
	}
}
