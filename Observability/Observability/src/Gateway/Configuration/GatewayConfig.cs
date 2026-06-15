namespace Gateway.Configuration
{
    public class Route
    {
        public string Path { get; set; }
        public string Method { get; set; }
    }

    public class Api
    {
        public string Name { get; set; }
        public IEnumerable<Route> Routes { get; set; }
    }

    public class GatewayConfig
    {
        public IEnumerable<Api> Apis { get; set; }
    }
}
