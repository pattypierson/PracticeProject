using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeProject.Services
{
    public class ScrapeService
    {
        public List<string> Scrape(string imgname)
        {
            var document = new HtmlWeb().Load("https://www.pexels.com/search/" + imgname);
            var urls = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s));
            List<string> list = urls.ToList();
            List<string> newList = new List<string>();
            foreach (var item in list)
            {
                newList.Add(item);
            }
            return newList;
        }
    }
}
