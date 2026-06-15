namespace Gateway.Clients
{
    public interface IOrderClient
    {
        Task<HttpResponseMessage> SendAsync(HttpContext context);
    }
}
