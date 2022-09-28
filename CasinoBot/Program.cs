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
            var config = new DiscordSocketConfig()
            {
                // Other config options can be presented here.
                GatewayIntents = GatewayIntents.All
            };

            _client = new DiscordSocketClient(config);

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

                // Custom Services
                .AddSingleton<CommandHandlerService>()
                .AddTransient<ISlotMachine, SlotMachine>()

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