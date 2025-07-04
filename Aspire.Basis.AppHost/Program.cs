using Aspire.Basis.Constants;

var builder = DistributedApplication.CreateBuilder(args);

var ingress = builder.AddProject<Projects.Yarp>(AspireServices.Ingress.Name);

var web = builder.AddProject<Projects.Web_Server>(AspireServices.Web.Name)
                .WithEndpoint(name: "scalar", scheme: "https")
                .WithUrlForEndpoint("scalar", url => url.Url += "/scalar");

ingress.WithReference(web);

builder.Build().Run();
