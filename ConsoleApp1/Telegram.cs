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
        private static string startText = "Привет я дурачёк";
        public void Bot()
        {
            botClient = new TelegramBotClient("727728678:AAF4w9wmiNvU0f0VAH_UMBCYJjVIY8jwqkE") { Timeout = TimeSpan.FromSeconds(10) };
            botClient.OnMessage += OnMessageAsync;
            botClient.StartReceiving();
        }

        public void fjlksdfjsl
        {

        }

        private async void OnMessageAsync(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
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
        public void asdgfd()
        {

        }
    }
}
