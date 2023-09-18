

using Dapr.Client;

var daprClient = new DaprClientBuilder().Build();

int i = 0;

while(true) {
    Thread.Sleep(10000);
    await daprClient.PublishEventAsync<int>("pubsub", "count",i++ );
    Console.WriteLine($"Published {i} messages");
}

