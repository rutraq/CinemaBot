using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace ConsoleApp1
{
    class Telegram
    {
        private static ITelegramBotClient botClient;
        private static List<string> commands = new List<string>() { "/comands" };
        public static List<string> films = new List<string>();
        private static string startText = "";

        public List<string> Films { get => films; set => films = value; }

        public void Bot()
        {
            botClient = new TelegramBotClient("727728678:AAF4w9wmiNvU0f0VAH_UMBCYJjVIY8jwqkE") { Timeout = TimeSpan.FromSeconds(10) };
            botClient.OnMessage += OnMessageAsync;
            botClient.StartReceiving();
        }

        private async void OnMessageAsync(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            for (int i = 0; i < films.Count; i++)
            {
                startText += films[i] + "\n";
            }
            if (text == null)
            {
                return;
            }
            else if (!commands.Contains(text))
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: startText
                    );
            }
        }
    }
}
