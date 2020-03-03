using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreateAccountsProject.Services
{
    public class DelayService
    {
        /// <summary>
        /// Delay {ms} miliseconds
        /// </summary>
        /// <param name="ms"></param>
        public static void Miliseconds(int ms)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(ms));
        }

        public static void Seconds(int s)
        {
            Thread.Sleep(TimeSpan.FromSeconds(s));
        }

        public static void Minutes(int m)
        {
            Thread.Sleep(TimeSpan.FromMinutes(m));
        }

        public static void Hours(int h)
        {
            Thread.Sleep(TimeSpan.FromHours(h));
        }
    }
}
