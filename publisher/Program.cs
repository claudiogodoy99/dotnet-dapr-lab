

using Dapr.Client;

var daprClient = new DaprClientBuilder().Build();

int i =0;
while(true) {
    
    await daprClient.PublishEventAsync<int>("pubsub", "count",i++ );

    if(i % 500 == 0){
        await Task.Delay(5);
        Console.WriteLine($"Published {i} messages");
    }
}

