using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace QuartzNet
{
    internal class Program
    {
        //https://www.quartz-scheduler.net/documentation/index.html
        private static void Main(string[] args)
        {
            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine(DateTime.Now);
            //        Thread.Sleep(500);
            //    }
            //});
            RunProgram().GetAwaiter().GetResult();


            Console.ReadKey();
        }

        private static volatile int counter = 0;
        private static async Task RunProgram()
        {
            try
            {

                NameValueCollection props = new NameValueCollection
                {
                    {"quartz.serializer.type", "binary"}
                };
                // get a scheduler
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                //start is off
                await scheduler.Start();
                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<HelloJob>()
                    .WithIdentity("myJob", "group1")
                    .WithDescription("my job description")
                    .UsingJobData("jobSays", "Hello World!")
                    .UsingJobData("myFloatValue", 3.141f)
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("myTrigger", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(3).RepeatForever())
                    .Build();

                trigger.JobDataMap.Add("datetime", 1);
                await scheduler.ScheduleJob(job, trigger);


            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
        [DisallowConcurrentExecution]
        [PersistJobDataAfterExecution]
        //Each (and every) time the scheduler executes the job, it creates a new instance of the class before calling its Execute(..) method.
        //One of the ramifications of this behavior is the fact that jobs must have a no-argument constructor.
        //Another ramification is that it does not make sense to have data-fields defined on the job class - as their values would not be preserved between job executions.
        public class HelloJob : IJob
        {
            /// <summary>
            /// datamap值自动注入属性
            /// </summary>
            public string JobSays { get; set; }
            public float MyFloatValue { get; set; }

            public HelloJob()
            {
                Console.WriteLine($"I AM A NO-ARGUMENT CONSTRUCTOR! {DateTime.Now}");
            }



            public async Task Execute(IJobExecutionContext context)
            {
                var data = context.JobDetail.JobDataMap;
                data["myFloatValue"] = MyFloatValue + 1;
                await Console.Out.WriteLineAsync($"JobDetail.Key: {context.JobDetail.Key}\n" +
                                                 $"JobDetail.Description: {context.JobDetail.Description}\n" +
                                                 $"job says1: {data.GetString("jobSays")}\n" +
                                                 $"jobSays2: {JobSays}\n" +
                                                 $"value: {MyFloatValue}\n");
            }


        }


    }
}
