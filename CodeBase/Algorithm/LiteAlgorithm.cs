using System;

namespace Algorithm
{
    public static class LiteAlgorithm
    {
        /// <summary>
        /// 分解质因数，略作优化
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
        /// <summary>
        /// 分解质因数
        /// </summary>
        /// <param name="x"></param>
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
        /// 小青蛙跳台阶，递归算法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FrogJump(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return FrogJump(n - 1) + FrogJump(n - 2);
        }
        /// <summary>
        /// 小青蛙跳台阶，组合算法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FrogJump2(int n)
        {
            var result = 0; 
            for (int i = 0; i <= n / 2; i++)
            {
                result += C(i, n - i);
            }

            return result;
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
            if (n == 0)
            {
                return 1;
            }
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
