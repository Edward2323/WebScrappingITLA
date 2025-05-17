using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebScrappingITLA.Models;

namespace WebScrappingITLA.Scrapper
{
    public class HtmlParser
    {
        public List<TaskItem> ExtractTasks(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var taskNodes = doc.DocumentNode.SelectNodes("//div[@class='event mt-3']");
            var tasks = new List<TaskItem>();

            if (taskNodes == null) return tasks;

            foreach (var node in taskNodes)
            {
                var title = node.SelectSingleNode(".//h3[contains(@class, 'name')]")?.InnerText?.Trim() ?? "Sin título";
                var date = node.SelectSingleNode(".//div[contains(@class, 'col-11')]/a")?.InnerText?.Trim() ?? "Sin fecha";
                var subject = node.SelectSingleNode(".//div[@class='col-11']/a[contains(@href, 'course/view.php')]")?.InnerText?.Trim() ?? "Sin curso";

                tasks.Add(new TaskItem
                {
                    Title = WebUtility.HtmlDecode(title),
                    DueDate = WebUtility.HtmlDecode(date),
                    Subject = WebUtility.HtmlDecode(subject)
                });
            }

            return tasks;
        }
    }
}
