using System;
using System.Timers;
using Topshelf;

namespace TopshelfTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   //1
            {
                x.Service<TownCrier>(s =>                                   //2
                {
                    s.ConstructUsing(name => new TownCrier());                //3
                    s.WhenStarted(tc => tc.Start());                         //4
                    s.WhenStopped(tc => tc.Stop());                          //5
                });
                x.RunAsLocalSystem();                                       //6

                x.SetDescription("[Description Sample Topshelf Host]");                   //7
                x.SetDisplayName("[DisplayName]");                                  //8
                x.SetServiceName("[ServiceName]");                                  //9

                x.StartAutomatically(); // Start the service automatically
                                        //x.StartAutomaticallyDelayed(); // Automatic (Delayed) -- only available on .NET 4.0 or later
                                        //x.StartManually(); // Start the service manually
                                        //x.Disabled(); // install the service as disabled


                //x.EnableServiceRecovery(r =>
                //{
                //    //you can have up to three of these
                //    //r.RestartComputer(5, "message");
                //    r.RestartService(0);
                //    //the last one will act for all subsequent failures
                //    //r.RunProgram(7, "ping google.com");

                //    //should this be true for crashed or non-zero exits
                //    r.OnCrashOnly();

                //    //number of days until the error count resets
                //    r.SetResetPeriod(1);
                //});


            });                                                             //10

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            Environment.ExitCode = exitCode;
        }
    }
    public class TownCrier
    {
        private readonly Timer _timer;
        public TownCrier()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} and all is well", DateTime.Now);
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
}
