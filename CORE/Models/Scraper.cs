using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Webscraper.Models;

namespace CORE.Models
{
    public class Scraper
    {
		private ObservableCollection<ProductListing> _products = new ObservableCollection<ProductListing>();

		public ObservableCollection<ProductListing> Products
		{
			get { return _products; }
			set { _products = value; }
		}



	}
}
