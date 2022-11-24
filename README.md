# PocSignalR
Para utilizar esse projeto é necessário criar o seu arquivo local.settings.json na function seguindo a estrutura abaixo
```
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AzureWebJobsSecretStorageType": "files",
    "AzureSignalRConnectionString": "<sua connectionstring do signalR no Azure>"
  },
  "Host": {
    "LocalHttpPort": 7194,
    "CORS": "https://localhost:7214",
    "CORSCredentials": true
  }
}
```

## Criar um SignalR
É bem simples, basta entrar no portal do Azure e buscar por SignalR, existe uma opção free para quem tem até 20k de requisições por dia.

## Testando
Rode os dois projetos, verifique se as portas estão corretas e faça uma chamada para o endpoint inserir-notificacao via post e veja a se a mensagem aparece no webapp

## Publicando
É possível publicar os dois através da ferramente de publish do próprio Visual Studio, não esqueça de atribuir o CORS na sua Function recém criada e também a connectionstring do SignalR no Configuration.
