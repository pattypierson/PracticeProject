using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeProject.Services
{
    public class ScrapeService
    {
        public List<string> Scrape(string img)
        {
            var document = new HtmlWeb().Load("https://www.pexels.com/search" + img);
            var urls = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s));
            List<string> list = urls.ToList();
            List<string> newList = new List<string>();
            for (var i = 0; i < 16; i++)
            {
                newList.Add(list[i]);
            }
            return newList;
        }
    }
}
