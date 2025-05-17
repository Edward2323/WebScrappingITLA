using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrappingITLA.Models
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string DueDate { get; set; }
        public string Subject { get; set; }

        public override string ToString()
        {
            return $"{Title} | {DueDate} | {Subject}";
        }
    }
}
