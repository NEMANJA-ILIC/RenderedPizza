using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using RenderedPizza.Models;

namespace LargeJSON
{
	public class JSONmanipulator
	{
		public static T _download_serialized_json_data<T>(string url) where T : new()
		{
			using (var w = new WebClient())
			{
				var json_data = string.Empty;
				// attempt to download JSON data as a string
				w.Encoding = Encoding.UTF8;
				try
				{
					json_data = w.DownloadString(url);
				}
				catch (Exception) { }
				// if string with JSON data is not empty, deserialize it to class and return its instance 
				return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
			}
		}

		public static T _parse_serialized_json_data<T>(string json) where T : new()
		{
			// if string with JSON data is not empty, deserialize it to class and return its instance 
			return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<T>(json) : new T();	
		}
	}
}
