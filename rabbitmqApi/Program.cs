using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using rabbitmqApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var factory = new ConnectionFactory() { 
    HostName = "142.93.173.18",
    UserName = "admin",
    Password = "devintwitter"
};

var list = new Dictionary<int,dynamic>();


app.MapPost("/", (SweetPublish sweet) => {

    using(var connection = factory.CreateConnection()) //disposable
    using(var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "a2-renanfortkamp",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

    }
});

//Get para pegar a lista de mensagens  do rabbit
app.MapGet("/", () => {
    using(var connection = factory.CreateConnection()) //disposable
    using(var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "a2-renanfortkamp",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
        };
        channel.BasicConsume(queue: "a2-renanfortkamp",
                            autoAck: true,
                            consumer: consumer);
    }
    return list;
});

app.Run();
