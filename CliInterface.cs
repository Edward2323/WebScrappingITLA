using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrappingITLA.Models;

namespace WebScrappingITLA
{
    public class CliInterface
    {
        public void ShowWelcome()
        {
            Console.WriteLine("===== ITLA Scraper =====");
        }

        public void DisplayTasks(List<TaskItem> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No hay tareas pendientes.");
                return;
            }

            Console.WriteLine("Tareas pendientes:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
    }
}
