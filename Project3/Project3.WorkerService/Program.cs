IHost host = Host.CreateDefaultBuilder(args)
    .Inject()
    .ConfigureServices(services =>
    {
        services.AddHttpContextAccessor();
        services.AddRemoteRequest();
        services.AddLogging();
        services.AddFileLogging();

        //services.AddHostedService<Worker>();
    })

    .Build();

host.Run();