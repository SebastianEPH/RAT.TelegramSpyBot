
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using RAT_TelegramBot.Models;
using System.Threading.Tasks;

namespace RAT_TelegramBot.Controllers
{
    public class MessageController : ApiController{

        [Route(@"api/message/update")] // WenHook
        public async Task<OkResult> Update([FromBody]Update update) {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            foreach (var command in commands) {
                if (command.Contains(message.Text)) {
                    command.Execute(message, client);
                    break;
                }
            }

            return Ok();
        }
    }
}
