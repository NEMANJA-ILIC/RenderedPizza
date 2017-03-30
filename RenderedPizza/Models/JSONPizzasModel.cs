using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderedPizza.Models
{
	public class JSONPizzasModel
	{
		public Pizza[] pizzas { get; set; }
	}

	// ew, really awful json...
	// this model is needed so that the incoming JSON can be mapped to a class
	// this is the way C# works with JSON, nothing much I can do about it
	public class Pizza
	{
		private Margherita margherita;
		public Margherita Margherita
		{
			get { return margherita; }
			set
			{
				margherita = value;
				name = "Margherita";
			}
		}
		public string name { get; set; }
		public int price { get; set; }
		private Funghi funghi;
		public Funghi Funghi
		{
			get { return funghi; }
			set
			{
				funghi = value;
				name = "Funghi";
			}
		}

		public string nil { get; set; }
		private Capricciosa capricciosa;
		public Capricciosa Capricciosa
		{
			get { return capricciosa; }
			set
			{
				capricciosa = value;
				name = "Capricciosa";
			}
		}

		private Quattro_Stagioni quattro_stagioni;
		public Quattro_Stagioni Quattro_stagioni
		{
			get { return quattro_stagioni; }
			set
			{
				quattro_stagioni = value;
				name = "Quattro_stagioni";
			}
		}

		private Vegetariana vegetariana;
		public Vegetariana Vegetariana
		{
			get { return vegetariana; }
			set
			{
				vegetariana = value;
				name = "Vegetariana";
			}
		}

		private Quattro_Formaggi quattro_formaggi;
		public Quattro_Formaggi Quattro_formaggi
		{
			get { return quattro_formaggi; }
			set
			{
				quattro_formaggi = value;
				name = "Quattro_formaggi";
			}
		}

		private Marinara marinara;
		public Marinara Marinara
		{
			get { return marinara; }
			set
			{
				marinara = value;
				name = "Marinara";
			}
		}

		private Peperoni peperoni;
		public Peperoni Peperoni
		{
			get { return peperoni; }
			set
			{
				peperoni = value;
				name = "Peperoni";
			}
		}

		private Napolitana napolitana;
		public Napolitana Napolitana
		{
			get { return napolitana; }
			set
			{
				napolitana = value;
				name = "Napolitana";
			}
		}

		private Hawaii hawaii;
		public Hawaii Hawaii
		{
			get { return hawaii; }
			set
			{
				hawaii = value;
				name = "Hawaii";
			}
		}

		private Calzone calzone;
		public Calzone Calzone
		{
			get { return calzone; }
			set
			{
				calzone = value;
				name = "Calzone";
			}
		}

		private Rucola rucola;
		public Rucola Rucola
		{
			get { return rucola; }
			set
			{
				rucola = value;
				name = "Rucola";
			}
		}

		private Bolognese bolognese;
		public Bolognese Bolognese
		{
			get { return bolognese; }
			set
			{
				bolognese = value;
				name = "Bolognese";
			}
		}

		private Meat_Feast meat_feast;
		public Meat_Feast Meat_Feast
		{
			get { return meat_feast; }
			set
			{
				meat_feast = value;
				name = "Meat_Feast";
			}
		}

		private Kebabpizza kebabpizza;
		public Kebabpizza Kebabpizza
		{
			get { return kebabpizza; }
			set
			{
				kebabpizza = value;
				name = "Kebabpizza";
			}
		}

		private Mexicana mexicana;
		public Mexicana Mexicana
		{
			get { return mexicana; }
			set
			{
				mexicana = value;
				name = "Mexicana";
			}
		}
	}

	public class Margherita
	{
		public string[] ingredients { get; set; }
	}

	public class Funghi
	{
		public string[] ingredients { get; set; }
	}

	public class Capricciosa
	{
		public string[] ingredients { get; set; }
	}

	public class Quattro_Stagioni
	{
		public string[] ingredients { get; set; }
	}

	public class Vegetariana
	{
		public string[] ingredients { get; set; }
	}

	public class Quattro_Formaggi
	{
		public string[] ingredients { get; set; }
	}

	public class Marinara
	{
		public string[] ingredients { get; set; }
	}

	public class Peperoni
	{
		public string[] ingredients { get; set; }
	}

	public class Napolitana
	{
		public string[] ingredients { get; set; }
	}

	public class Hawaii
	{
		public string[] ingredients { get; set; }
	}

	public class Calzone
	{
		public string[] ingredients { get; set; }
	}

	public class Rucola
	{
		public string[] ingredients { get; set; }
	}

	public class Bolognese
	{
		public string[] ingredients { get; set; }
	}

	public class Meat_Feast
	{
		public string[] ingredients { get; set; }
	}

	public class Kebabpizza
	{
		public string[] ingredients { get; set; }
	}

	public class Mexicana
	{
		public string[] ingredients { get; set; }
	}
}
