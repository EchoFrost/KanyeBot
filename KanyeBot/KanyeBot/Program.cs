using Discord;
using Discord.WebSocket;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace KanyeBot
{
	public class Program
	{
		private DiscordSocketClient _client;

		public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
		private static RestClient _restClient = new RestClient("https://api.kanye.rest/");

		public async Task MainAsync()
		{
			_client = new DiscordSocketClient(new DiscordSocketConfig()
			{
				LogLevel = LogSeverity.Info
			});

			_client.Log += Log;
			_client.MessageReceived += MessageReceived;

			await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("DiscordToken"));
			await _client.StartAsync();

			// Block this task until the program is closed.
			await Task.Delay(-1);
		}

		private async Task MessageReceived(SocketMessage message)
		{
			string messageContent = message.Content.ToLower();

			if (messageContent.Contains("kanye") || messageContent.Contains("west"))
			{
				RestRequest kanyeRestRequest = new RestRequest("", Method.GET, DataFormat.Json);
				KanyeRestResponse kanyeRestResponse = await _restClient.GetAsync<KanyeRestResponse>(kanyeRestRequest);
				await message.Channel.SendMessageAsync(kanyeRestResponse.quote);
			}
		}

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}
	}
}
