var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Web_Server>("web");

builder.Build().Run();
