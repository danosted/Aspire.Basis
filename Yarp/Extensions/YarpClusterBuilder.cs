using Yarp.ReverseProxy.Configuration;

namespace Aspire.Basis.Yarp;

public class YarpClusterBuilder(string clusterId, YarpConfigBuilder builder)
{
    public YarpClusterBuilder Route(string routeId, string path, Func<RouteConfig, RouteConfig>? configure = null)
    {
        if (builder.RouteConfigs.ContainsKey(routeId))
        {
            throw new InvalidOperationException($"Route with id {routeId} already exists.");
        }
        var routeConfig = new RouteConfig
        {
            RouteId = routeId,
            ClusterId = clusterId,
            Match = new RouteMatch
            {
                Path = path,
            },
        };
        if (configure != null)
        {
            routeConfig = configure(routeConfig);
        }
        builder.RouteConfigs[routeId] = routeConfig;
        return this;
    }
}