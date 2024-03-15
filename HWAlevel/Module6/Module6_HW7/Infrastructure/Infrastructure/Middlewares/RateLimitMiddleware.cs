using System.Collections.Concurrent;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middlewares
{
    public class RequestLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly int _limit;
        private readonly ConcurrentDictionary<string, Queue<DateTime>> _requestTimesByIp;

        public RequestLimitMiddleware(RequestDelegate next, int limit)
        {
            _next = next;
            _limit = limit;
            _requestTimesByIp = new ConcurrentDictionary<string, Queue<DateTime>>();
        }

        public async Task Invoke(HttpContext context)
        {
            var now = DateTime.UtcNow;
            var ip = context.Connection.RemoteIpAddress.ToString();

            var requestTimes = _requestTimesByIp.GetOrAdd(ip, new Queue<DateTime>());

            while (requestTimes.Count > 0 && (now - requestTimes.Peek()).TotalSeconds > 60)
            {
                requestTimes.TryDequeue(out _);
            }

            if (requestTimes.Count >= _limit)
            {
                context.Response.StatusCode = 429; 
                return;
            }

            requestTimes.Enqueue(now);

            await _next(context);
        }
    }
}