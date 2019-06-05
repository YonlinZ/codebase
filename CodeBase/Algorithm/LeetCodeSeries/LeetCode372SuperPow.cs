using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Algorithm.LeetCodeSeries
{
    internal class LeetCode372SuperPow
    {
        private const int Mod0 = 1337;
        public static int SuperPow(int a, int[] b)
        {
            if (b.Length == 0)
            {
                return 1;
            }

            var res = 1;
            for (int i = b.Length - 1; i >= 0; i--)
            {
                res = powMod(a, b[i]) * res % Mod0;
                a = powMod(a, 10);
            }
            return res;
        }
        private static int powMod(int a, int m)
        {
            a %= Mod0;
            int result = 1;
            for (int i = 0; i < m; i++)
            {
                result = result * a % Mod0;
            }

            return result;
        }


        public static int SuperPow2(int a, int[] b)
        {
            if (a == 0)
            {
                return 0;
            }

            if (b == null || b.Length == 0)
            {
                return 1;
            }

            long res = 1;
            for (int i = 0; i < b.Length; ++i)
            {
                res = Pow(res, 10) * Pow(a, b[i]) % 1337;
            }
            return (int)res;
        }

        private static long Pow(long x, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n == 1)
            {
                return x % 1337;
            }

            return Pow(x % 1337, n / 2) * Pow(x % 1337, n - n / 2) % 1337;
        }

        /// <summary>
        /// 提交答案
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int MySuperPow(int a, int[] b)
        {
            int MOD_NUM = 1337;
            var res = 1;
            for (int i = 0; i < b.Length; i++)
            {
                var inner = PowMod(a, b[i], MOD_NUM);


                for (int j = b.Length - i; ; j = j - 18)
                {
                    if (j <= 19)
                    {
                        inner = PowMod(inner, Pow3(10, j - 1) % 1140, MOD_NUM);
                        break;
                    }
                    else
                    {
                        inner = PowMod(inner, 1000000000000000000L % 1140, MOD_NUM);
                    }
                }
                res = res * inner % MOD_NUM;
            }

            return res;

            int PowMod(int n, long power, int mod)
            {
                int re = 1;
                while (power != 0)
                {
                    if (power % 2 == 1)//如果是奇数
                    {
                        re = (re * n) % mod;
                    }
                    n = (n * n) % mod;
                    power >>= 1;
                }

                return re;
            }

            long Pow3(long n, int power)
            {
                long r = 1;
                while (power != 0)
                {
                    if (power % 2 != 0)//如果是奇数
                    {
                        r *= n;
                    }
                    n *= n;
                    power >>= 1;
                }

                return r;
            }
        }

        public static int SuperPow3(int a, int[] b)
        {
            Console.WriteLine("-".PadRight(100, '-'));
            a = a % 1337;

            var r = new int[10];

            r[0] = 1;

            for (var i = 1; i < 10; i++)
                r[i] = (r[i - 1] * a) % 1337;

            r.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("-".PadRight(50, '-'));
            var ans = 1;

            foreach (var i in b)
            {
                var t = ans;

                for (var j = 1; j < 10; j++) t = (t * ans) % 1337;

                ans = (t * r[i]) % 1337;
                //Console.WriteLine(ans);
            }

            return ans;
            Console.WriteLine("-".PadRight(100, '-'));
        }
    }
}
