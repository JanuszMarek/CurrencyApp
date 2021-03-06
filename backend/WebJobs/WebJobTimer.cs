using Microsoft.Azure.WebJobs;
using System;

namespace WebJobs
{
    public class WebJobTimer
    {
        //If I scale out, it should still only have one instance running
        [Singleton] 
        public static void CryptoApiTimer([TimerTrigger("0/1 * * * *")] TimerInfo myTimer)
        {
            Console.WriteLine($"Hello at {DateTime.UtcNow.ToString()}");
        }
    }
}
