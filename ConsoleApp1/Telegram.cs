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
        private static List<string> commands = new List<string>() { "Вывод популярных фильмов", "Поиск фильма" };
        public static List<long> searchFromUser = new List<long>();

        private static string startText = "Привет я дурачёк";
        public void Bot()
        {
            botClient = new TelegramBotClient("727728678:AAF4w9wmiNvU0f0VAH_UMBCYJjVIY8jwqkE") { Timeout = TimeSpan.FromSeconds(10) };
            botClient.OnMessage += OnMessageAsync;
            botClient.StartReceiving();
        }
        private async void OnMessageAsync(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            if (searchFromUser.Contains(e.Message.Chat.Id))
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat.Id,
                    text: "Пожалуйста подождите. Это может занять до 15 секунд"
                    );
                SearchFilms films = new SearchFilms(e.Message.Text);
                List<string> mess = films.Search();
                await botClient.SendPhotoAsync(
                    chatId: e.Message.Chat,
                    photo: mess[1]
                    );
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: mess[0]
                    );
                searchFromUser.Remove(e.Message.Chat.Id);
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
                    text: "Популярные фильмы делает женя так что пока что идите нахуй"
                    );
            }
            //Поиск фильма
            else if (text == commands[1])
            {
                await botClient.DeleteMessageAsync(
                    chatId: e.Message.Chat,
                    messageId: e.Message.MessageId
                    );
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Введите названия фильма"
                    );
                searchFromUser.Add(e.Message.Chat.Id);
            }
        }
    }
}
