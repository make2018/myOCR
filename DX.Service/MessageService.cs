using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DX.Contract;

namespace DX.Service
{
    public class MessageService
    {
        private static ConcurrentQueue<Dictionary<String, OPCContract>> Requests = new ConcurrentQueue<Dictionary<String, OPCContract>>();
        public static void InQueue(Dictionary<String, OPCContract> request)
        {
            Requests.Enqueue(request);
        }

        public static Dictionary<String, OPCContract> OutQueue()
        {
            Dictionary<String, OPCContract> result;

            Requests.TryDequeue(out result);

            return result;
        }
    }
}
