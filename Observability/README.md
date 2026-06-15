# Observability

## Observability in distributed systems:

- Logs

Logs are structured or unstructured text records of discreet events that occurred at a specific time.

- Metrics

Metrics are the values represented as counts or measures that are often calculated or aggregated over a period of time. 

- Distributed tracing

Distributed tracing displays activity of a transaction or request as it flows through applications.

## Grafana Settup 

```
Link: http://localhost:3000/
Default user name and password will be "admin"

click on "Add new Data Source"
Name: OrderApplications
Url: http://Loki:3100

click on "Save & test"
```

## Apis

Search in grafana:
```
{Application=~"Gateway_Development|OrderApi_Development|CatalogApi_Development"} | json | __error__  != "JSONParserErr"

Or, after knowing the TraceKey
{Application=~"Gateway_Development|OrderApi_Development|CatalogApi_Development"} | json | __error__  != "JSONParserErr" | TraceKey="f3e67c7e-0292-44e5-8a36-3cf07d54921f_09/05/2022 01:07:40"
```

Request via Gate: 
```
curl --location --request GET 'http://localhost:4001/Order' \
--header 'X-Gate-Api: Order'
```

Note: Cancel button on swagger doesn't cancel the request. It must test cancelation token using Postman!

## References:

https://grafana.com/blog/2021/01/25/a-beginners-guide-to-distributed-tracing-and-how-it-can-increase-an-applications-performance/

https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests

https://github.com/aspnet/Proxy/blob/master/src/Microsoft.AspNetCore.Proxy/ProxyAdvancedExtensions.cs
