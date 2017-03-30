# RenderedPizza
Rendered Text Pizza Coding Challenge

Project made for the above coding challenge.
The application should download a JSON file from http://coding-challenge.renderedtext.com/.
From that JSON file, the application sorts the pizzas into 4 categories:
1. Pizzas with meat
2. Pizzas with more than one type of cheese
3. Pizzas with meat and olives
4. Pizzas with mozzarela and mushrooms

Each categorie's percentage from the overall pizza offer should be calculated.
Also, the cheapest pizza from each group should be found along with it's ingredients and price.
Once found, the result should be posted with the HTTP POST request on the following site:
http://coding-challenge.renderedtext.com/submit
A JSON file should be sent in that POST request as an answer to the challenge and the JSON should be formated as following:
```javascript
{
   "personal_info":
	  {"full_name":"Ime Prezime", "email":"vas email", "code_link": "link do tvog koda"},
	"answer": [{"group_1": {"percentage": "x%", "cheapest": "<pizza with its price and ingridients>"}},
		   {"group_2": {"percentage": "x%", "cheapest": "<pizza with its price and ingridients>"}},
		   {"group_3": {"percentage": "x%", "cheapest": "<pizza with its price and ingridients>"}},
		   {"group_4": {"percentage": "x%", "cheapest": "<pizza with its price and ingridients>"}}]
}
```

The application is written in C# and VS2015 is needed to compile the application and run it.