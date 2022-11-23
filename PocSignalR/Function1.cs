using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace PocSignalR
{
    public static class Function1
    {
        [FunctionName("Negotiate")]
        public static SignalRConnectionInfo Negotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [SignalRConnectionInfo(HubName = "HubValue")] SignalRConnectionInfo connectionInfo,
            ILogger log)
        {
            log.LogInformation($"Retornando conexões: {connectionInfo.Url} {connectionInfo.AccessToken}");

            return connectionInfo;
        }

        [FunctionName("InserirNotificacao")]
        public static async Task<IActionResult> InserirNotificacao(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", "put", Route = "inserir-notificacao")] HttpRequest req,
            [SignalR(HubName = "HubValue")] IAsyncCollector<SignalRMessage> signalRMessage, ILogger log)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string mensagem;
            if (!string.IsNullOrWhiteSpace(requestBody))
            {
                mensagem = requestBody;
            }
            else
            {
                mensagem = "Para inserir uma mensagem passe uma mensagem pelo body";
            }

            await signalRMessage.AddAsync(
                new SignalRMessage
                {
                    Target = "myMessage",
                    Arguments = new[] { $"Sua mensagem inserida é: {mensagem}" }
                });

            return new OkObjectResult("Ok deu certo");
        }
    }
}
