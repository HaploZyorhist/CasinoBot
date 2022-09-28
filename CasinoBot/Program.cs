using CasinoBot.Services;
using CasinoBot.Services.Interfaces;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Interactivity;
using Microsoft.Extensions.DependencyInjection;

namespace CasinoBot
{
    public class Program
    {
        private DiscordSocketClient _client;

        public static Task Main(string[] args) => new Program().MainAsync();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            var services = ConfigureServices();

            await services.GetRequiredService<CommandHandlerService>().InitializeAsync(services);

            var token = Environment.GetEnvironmentVariable("token");
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                // Base
                .AddSingleton(_client)
                .AddSingleton<CommandService>()
                .AddSingleton<InteractivityService>()
                .AddSingleton(new InteractivityConfig { DefaultTimeout = TimeSpan.FromSeconds(15) })

            #region Custom Services

                // Singletons
                .AddSingleton<CommandHandlerService>()
                .AddSingleton<IUserInformation, UserInformation>()

                // Transients

            #endregion

                // Database
                //.AddDbContext<LoLBotContext>(options =>
                //options.UseSqlServer(Environment.GetEnvironmentVariable("DBConnection"),
                //sqlServerOptionsAction: sqlOptions =>
                //{
                // sqlOptions.EnableRetryOnFailure();
                //}
                //),
                //ServiceLifetime.Transient)

                .BuildServiceProvider();
        }
    }
}