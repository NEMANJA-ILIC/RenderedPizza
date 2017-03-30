using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderedPizza.Models
{
	public class PizzaModel
	{
		private String pizzaName;
		private String[] ingredients;
		private Int32 price;

		public String PizzaName
		{
			get
			{
				return pizzaName;
			}
			set
			{
				pizzaName = value;
			}
		}

		public String[] Ingredients
		{
			get
			{
				return ingredients;;
			}
			set
			{
				ingredients = value;
			}
		}

		public Int32 Price
		{
			get
			{
				return price;
			}
			set
			{
				price = value;
			}
		}
	}
}
