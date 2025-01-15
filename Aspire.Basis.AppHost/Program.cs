using Aspire.Basis.Constants;

var builder = DistributedApplication.CreateBuilder(args);

var ingress = builder.AddProject<Projects.Yarp>(AspireServices.Ingress.Name);

var web = builder.AddProject<Projects.Web_Server>(AspireServices.Web.Name);

ingress.WithReference(web);

builder.Build().Run();
