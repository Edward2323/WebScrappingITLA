using WebScrappingITLA.Scrapper;
using WebScrappingITLA.Services;
using WebScrappingITLA;

var cli = new CliInterface();
cli.ShowWelcome();

var (username, password) = CredentialManager.LoadCredentials();
var scraper = new PortalScrapper();

Console.WriteLine("Iniciando sesión...");
var success = await scraper.LoginAsync(username, password);

if (!success)
{
    Console.WriteLine("Error al iniciar sesión. Verifica tus credenciales.");
    return;
}

Console.WriteLine("Inicio de sesión exitoso. Obteniendo tareas...");
var tasks = await scraper.GetPendingTasksAsync();
cli.DisplayTasks(tasks);