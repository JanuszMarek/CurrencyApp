using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJobs
{
    public class SayHelloWebJob
    {
        //If I scale out, it should still only have one instance running
        [Singleton] 
        public static void TimerTick([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            Console.WriteLine($"Hello at {DateTime.UtcNow.ToString()}");
        }
    }
}
