using Aspire.Basis.Constants;
using Aspire.Basis.Yarp;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddCors();

var clusters = YarpConfigBuilder.Create()
                    .AddCluster(AspireServices.Web.Name, AspireServices.Web.Endpoint, cluster =>
                    {
#if !DEBUG
                        // In deployed scenarios, we want to use the default route that points to our client hosting site
                        cluster.Route("default", "{**catch-all}", route =>
                        {
                            return route with
                            {
                                Order = 999
                            };
                        });
#endif
                    })
#if DEBUG
                    // in development, we want to proxy the SPA to the local development server
                    .AddCluster("spa", AspireServices.Web.SpaProxyUrl, cluster =>
                    {
                        cluster.Route("fallback", "{**catch-all}", route =>
                        {
                            return route with
                            {
                                Order = 999
                            };
                        });
                    })
#endif
                    .Build();
builder.Services.AddReverseProxy()
                .ConfigureHttpClient((client, handler) =>
                {
                    // If using external Identity Provider, set the handler to allow auto-redirect
                    handler.AllowAutoRedirect = true;
#if DEBUG
                    // Localhost is using self-signed certificates, set the handler to allow any certificate
                    handler.SslOptions.RemoteCertificateValidationCallback = (_, _, _, _) => true;
#endif
                })
                .LoadFromMemory(clusters.RouteConfigs, clusters.ClusterConfigs)
                .AddServiceDiscoveryDestinationResolver();

var app = builder.Build();

app.UseCors();

app.MapReverseProxy();

app.Run();
