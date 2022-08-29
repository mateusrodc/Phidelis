using Back.PhidelisSystem.Application.Interfaces;

namespace Back.PhidelisSystem.HostedService
{
    public class TimerHostedService : IHostedService
    {
        private readonly ILogger _logger;
        static readonly HttpClient client = new HttpClient();


        public TimerHostedService(ILogger<TimerHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
            return Task.CompletedTask;
        }

        private async void ExecuteProcess(object ?state)
        {
            _logger.LogInformation("### Proccess executing ###");
            _logger.LogInformation($"{DateTime.Now}");

            var names = await GetRandomNames();
            var lista = names.Replace("[", "").Replace("]", "").Split(",").ToList();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("### Proccess stoping ###");
            _logger.LogInformation($"{DateTime.Now}");
            return Task.CompletedTask;
        }
        private async Task<string> GetRandomNames()
        {
            string url = "https://gerador-nomes.wolan.net/nomes/5";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return responseBody;
        }
        
    }
}
