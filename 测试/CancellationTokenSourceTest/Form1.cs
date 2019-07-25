using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CancellationTokenSourceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 长耗时任务，允许传参CancellationToken
        /// </summary>
        /// <param name="loop"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private Task<decimal> LongRunningCancellableOperation(int loop, CancellationToken token)
        {
            return Task.Run(() =>
            {
                decimal result = 0;
                for (int i = 0; i < loop; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        //throw new TaskCanceledException();
                        Console.WriteLine(@"Task is Cancelled");
                        return result;
                    }

                    Thread.Sleep(400);
                    result += i;
                    Console.WriteLine(i);
                }

                return result;
            }, token);
        }
        /// <summary>
        /// 长耗时任务
        /// </summary>
        /// <param name="loop"></param>
        /// <returns></returns>
        private Task<decimal> LongRunningTask(int loop)
        {
            return Task.Run(() =>
            {
                decimal result = 0;
                for (int i = 0; i < loop; i++)
                {
                    Thread.Sleep(400);
                    result += i;
                    Console.WriteLine(i);
                }
                return result;
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await ExecuteTaskWithTimeoutAsync(TimeSpan.FromSeconds(5));
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            await ExecuteManuallyCancellableTaskAsync();
        }
        /// <summary>
        /// 超时取消Task
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        private async Task ExecuteTaskWithTimeoutAsync(TimeSpan timeSpan)
        {
            Console.WriteLine(nameof(ExecuteTaskWithTimeoutAsync));
            using (var cts = new CancellationTokenSource(timeSpan))
            {
                try
                {
                    var result = await LongRunningCancellableOperation(2000, cts.Token);
                    Console.WriteLine(@"***********Timeout**********");
                    Console.WriteLine($@"Final result is {result}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
       
        /// <summary>
        /// 手动取消Task
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteManuallyCancellableTaskAsync()
        {
            Console.WriteLine(nameof(ExecuteTaskWithTimeoutAsync));

            using (var cts = new CancellationTokenSource())
            {
               var keyBoardTask  = Task.Run(() =>
                 {
                     Console.WriteLine(@"Press any key to stop task");
                     Console.ReadKey();
                     cts.Cancel();
                 });
                try
                {
                    var result = await LongRunningCancellableOperation(2000, cts.Token);
                    Console.WriteLine($@"Final result is {result}");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                await keyBoardTask;
            }
        }

        
        private async void button1_Click(object sender, EventArgs e)
        {
            await CancelANonCancellableTaskAsync();
        }
        /// <summary>
        /// 手动取消Task，升级版。这种取消方式其实并没有使长耗时任务终止，而是一直在运行，只是忽略它了，
        /// </summary>
        /// <returns></returns>
        async Task CancelANonCancellableTaskAsync()
        {
            Console.WriteLine(nameof(CancelANonCancellableTaskAsync));

            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                // Listening to key press to cancel
                var keyBoardTask = Task.Run(() =>
                {
                    Console.WriteLine(@"Press enter to cancel");
                    Console.ReadKey();

                    // Sending the cancellation message
                    cancellationTokenSource.Cancel();
                });

                try
                {
                    // Running the long running task
                    var longRunningTask = LongRunningOperationWithCancellationTokenWrapperAsync(100, cancellationTokenSource.Token);
                    var result = await longRunningTask;

                    Console.WriteLine("Result {0}", result);
                    Console.WriteLine("Press enter to continue");
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("Task was cancelled");
                }

                await keyBoardTask;
            }
        }
        async Task<decimal> LongRunningOperationWithCancellationTokenWrapperAsync(int loop, CancellationToken token)
        {
            var taskCompletionSource = new TaskCompletionSource<decimal>();
            token.Register(() =>
            {
                taskCompletionSource.TrySetCanceled();
                //taskCompletionSource.SetResult(-1);
            });
            var task = LongRunningTask(loop);//长时任务
            // Wait for the first task to finish among the two
            var completedTask = await Task.WhenAny(task, taskCompletionSource.Task);

            return await completedTask;
        }

       
    }
}
