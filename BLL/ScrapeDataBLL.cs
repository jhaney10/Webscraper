using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace BLL
{
    public class ScrapeDataBLL
    {
        public List<string> ScrapeData(string page)
        {
            //initiates a html document
            var web = new HtmlWeb();
            var doc = web.Load(page);
            var Products = doc.DocumentNode.SelectNodes("//*[@class = 'name']");
            List<string> list = new List<string>();
            foreach (var text in Products)
            {
                var header = HttpUtility.HtmlDecode(text.InnerText);
                list.Add(header);
            }
            return list;
        }
    }
}
