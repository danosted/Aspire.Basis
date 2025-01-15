using Yarp.ReverseProxy.Configuration;

namespace Aspire.Basis.Yarp;

public class YarpConfigBuilder
{
    public Dictionary<string, ClusterConfig> ClusterConfigs { get; } = [];
    public Dictionary<string, RouteConfig> RouteConfigs { get; } = [];

    public static YarpConfigBuilder Create() => new YarpConfigBuilder();

    public struct YarpConfig
    {
        public required IReadOnlyList<ClusterConfig> ClusterConfigs;
        public required IReadOnlyList<RouteConfig> RouteConfigs;
    }

    public YarpConfig Build()
    {
        return new YarpConfig
        {
            ClusterConfigs = ClusterConfigs.Values.ToList(),
            RouteConfigs = RouteConfigs.Values.ToList(),
        };
    }

    public YarpConfigBuilder AddCluster(string clusterId, string address, Action<YarpClusterBuilder>? configure = null)
    {
        if (ClusterConfigs.ContainsKey(clusterId))
        {
            throw new InvalidOperationException($"Cluster with id {clusterId} already exists.");
        }
        ClusterConfigs[clusterId] = new ClusterConfig
        {
            ClusterId = clusterId,
            Destinations = new Dictionary<string, DestinationConfig>
            {
                [clusterId] = new DestinationConfig
                {
                    Address = address,
                },
            },
        };
        var clusterBuilder = new YarpClusterBuilder(clusterId, this);
        if (configure != null)
        {
            configure(clusterBuilder);
        }

        return this;
    }
}