using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebScrape
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter url to scrape.");
            string url = Console.ReadLine();
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var elems =
                htmlDoc
                .DocumentNode
                .Descendants("img")
                .Select(x => x.GetAttributeValue("src", null))
                .Where(y => !String.IsNullOrEmpty(y));
                    

            foreach (var elem in elems)
            {
                Console.WriteLine(elem);
            }

            Console.ReadLine();
        }
    }
}
