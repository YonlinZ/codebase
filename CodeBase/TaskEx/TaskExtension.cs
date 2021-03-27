using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskEx
{
    public static class TaskExtension
    {
        /// <summary>
        /// 取消执行超时的阻塞方法
        /// </summary>
        /// <typeparam name="T">返回值</typeparam>
        /// <param name="func">可能长时间运行的阻塞方法</param>
        /// <returns></returns>
        public static Task<T> TimeoutCancel<T>(Func<T> func, int millisecondsDelay)
        {
            try
            {
                var cts = new CancellationTokenSource(millisecondsDelay);
                var t = Task.Run(func);

                while (!cts.IsCancellationRequested)
                {
                    if (t.IsCompleted) return Task.FromResult(t.Result);
                }
                return Task.FromResult(default(T));
            }
            catch (Exception e)
            {
                throw new Exception("执行失败", e);
            }
        }
    }
}
