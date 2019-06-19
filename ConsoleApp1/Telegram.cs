using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleApp1
{
    class Telegram
    {
        private static ITelegramBotClient botClient;
        private static List<string> commands = new List<string>() { "/comands" };
        private static List<string> films = new List<string>();
        private static string startText = "";
        public  List<string> Films { get => films; set => films = value; }

        public void Bot()
        {
            botClient = new TelegramBotClient("727728678:AAF4w9wmiNvU0f0VAH_UMBCYJjVIY8jwqkE") { Timeout = TimeSpan.FromSeconds(10) };
            botClient.OnMessage += OnMessageAsync;
            botClient.StartReceiving();
        }

        private async void OnMessageAsync(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            for (int i = 0; i < Films.Count; i++)
            {
                startText += Films[i] + "\n";
            }
            if (text == null)
            {
                return;
            }
            else if (!commands.Contains(text))
            {
                ReplyKeyboardMarkup replykeyboard = new ReplyKeyboardMarkup
                (
                    new[]
                    {
                        new[]
                        {
                            new KeyboardButton("Вывод популярных фильмов"),
                            new KeyboardButton("Поиск фильма")
                        }
                    }
                );
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat, 
                    replyMarkup: replykeyboard,
                    text: startText
                    );
            }
            //Популярные фильмы
            else if (text == commands[0])
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: startText
                    );
            }
            //Поиск фильма
            //else if (text == commands[1])
            //{
            //    SearchFilm film = new SearchFilm("Докторс стрендж");
            //}
        }
    }
}
