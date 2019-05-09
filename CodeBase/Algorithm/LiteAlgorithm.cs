using System;

namespace Algorithm
{
    public static class LiteAlgorithm
    {
        /// <summary>
        /// 分解质因数
        /// </summary>
        /// <param name="x"></param>
        public static void F(ulong x)
        {
            var j = Math.Sqrt(x);
            for (ulong i = 2; i <= x; i++)
            {
                if (x % i == 0)
                {
                    Console.WriteLine("{0}", i);
                    F(x / i);
                    break;
                }
                if (i > j)
                {
                    Console.WriteLine("{0}", x);
                    break;
                }
            }
        }

        public static void F2(ulong x)
        {
            for (ulong i = 2; i <= x; i++)
            {
                if (x % i == 0)
                {
                    Console.WriteLine("{0}", i);
                    F(x / i);
                    break;
                }
            }
        }

        /// <summary>
        /// 小青蛙跳台阶
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int F3(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return F3(n - 1) + F3(n - 2);
        }

        /// <summary>
        /// 组合
        /// </summary>
        /// <param name="n"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static int C(int n, int total)
        {
            return A(n, total) / A(n, n);
        }

        /// <summary>
        /// 排列
        /// </summary>
        /// <param name="n"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static int A(int n, int total)
        {
            int result = 1;
            int times = 0;
            do
            {
                result *= total--;
                times++;
            }
            while (times < n);
            return result;
        }


        /// <summary>
        /// 快速幂
        /// </summary>
        /// <param name="n"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public static int F4(int n, int power)
        {
            if (power == 0)
            {
                return 1;
            }

            if (power == 1)
            {
                return n;
            }

            if (power % 2 == 0)//n是偶数
            {
                return F4(n * n, power / 2);
            }
            else
            {
                return n * F4(n * n, power / 2);
            }
        }
    }
}
