using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;

namespace CasinoBot.Services
{
    /// <summary>
    /// service class for handling commands
    /// </summary>
    public class CommandHandlerService
    {

        #region Fields

        private readonly CommandService _commands;
        private readonly DiscordSocketClient _client;
        private IServiceProvider _provider;

        #endregion

        #region CTOR

        /// <summary>
        /// CTOR for class
        /// </summary>
        /// <param name="client"></param>
        /// <param name="provider"></param>
        /// <param name="commands"></param>
        public CommandHandlerService(DiscordSocketClient client,
                                     IServiceProvider provider,
                                     CommandService commands)
        {
            _commands = commands;
            _client = client;
            _provider = provider;

            _client.MessageReceived += MessageReceived;
        }

        #endregion

        #region CommandHandler

        /// <summary>
        /// Task for setting up the class
        /// </summary>
        /// <param name="provider"></param>
        public async Task InitializeAsync(IServiceProvider provider)
        {
            _provider = provider;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
        }

        /// <summary>
        /// Message handler, should manage the commands
        /// </summary>
        /// <param name="message"></param>
        private async Task MessageReceived(SocketMessage message)
        {
            var prefix = Environment.GetEnvironmentVariable("prefix");

            if (!(message is SocketUserMessage socketMessage))
            {
                return;
            }

            if (message.Source != Discord.MessageSource.User)
            {
                return;
            }

            var context = new SocketCommandContext(_client, socketMessage);

            if (prefix != "!" && message.Content.ToLower().StartsWith("!prefix"))
            {
                prefix = "!";
                await _commands.ExecuteAsync(context, prefix.Length, _provider);
            }
            else if (!(message.ToString().StartsWith(prefix)))
            {
                return;
            }
            else
            {
                await _commands.ExecuteAsync(context, prefix.Length, _provider);
            }
        }

        #endregion
    }
}
