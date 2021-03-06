using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso.Apps.PaymentGateway.Throttling
{
    /// <summary>
    /// Creates an in-memory throttle cache to keep track of how many Http
    /// requests within a timespan each client is making.
    /// </summary>
    public class InMemoryThrottleStore : IThrottleStore
    {
        private readonly ConcurrentDictionary<string, ThrottleEntry> _throttleStore = new ConcurrentDictionary<string, ThrottleEntry>();

        public bool TryGetValue(string key, out ThrottleEntry entry)
        {
            return _throttleStore.TryGetValue(key, out entry);
        }

        public void IncrementRequests(string key)
        {
            _throttleStore.AddOrUpdate(key,
                                       k =>
                                       {
                                           return new ThrottleEntry() { Requests = 1 };
                                       },
                                       (k, e) =>
                                       {
                                           e.Requests++;
                                           return e;
                                       });
        }

        public void Rollover(string key)
        {
            ThrottleEntry dummy;
            _throttleStore.TryRemove(key, out dummy);
        }

        public void Clear()
        {
            _throttleStore.Clear();
        }
    }
}