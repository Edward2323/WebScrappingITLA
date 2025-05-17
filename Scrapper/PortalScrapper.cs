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
    internal class PortalScrapper
    {
        private readonly HttpClient _client;
        private readonly HtmlParser _parser;

        public PortalScrapper()
        {
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            _client = new HttpClient(handler);
            _parser = new HtmlParser();
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var loginPage = await _client.GetStringAsync("https://plataformavirtual.itla.edu.do/login/index.php");
            var token = ExtractLoginToken(loginPage);

            var postData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("logintoken", token),
            });

            var response = await _client.PostAsync("https://plataformavirtual.itla.edu.do/login/index.php", postData);
            var content = await response.Content.ReadAsStringAsync();

            return !content.Contains("Nombre de usuario o contraseña incorrectos");
        }

        public async Task<List<TaskItem>> GetPendingTasksAsync()
        {
            var html = await _client.GetStringAsync("https://plataformavirtual.itla.edu.do/calendar/view.php?view=upcoming");
            
            return _parser.ExtractTasks(html);


        }

        private string ExtractLoginToken(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var input = doc.DocumentNode.SelectSingleNode("//input[@name='logintoken']");
            return input?.GetAttributeValue("value", "") ?? "";
        }
    }
}
