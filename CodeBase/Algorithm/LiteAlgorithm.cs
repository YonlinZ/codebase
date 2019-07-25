using System;

namespace Algorithm
{
    public static class LiteAlgorithm
    {
        #region 分解质因数

        /// <summary>
        /// 分解质因数，略作优化
        /// </summary>
        /// <param name="x"></param>
        public static void PrimeFactorization(ulong x)
        {
            var j = Math.Sqrt(x);
            for (ulong i = 2; i <= x; i++)
            {
                if (x % i == 0)
                {
                    Console.WriteLine("{0}", i);
                    PrimeFactorization(x / i);
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
        public static void PrimeFactorization2(ulong x)
        {
            for (ulong i = 2; i <= x; i++)
            {
                if (x % i == 0)
                {
                    Console.WriteLine("{0}", i);
                    PrimeFactorization2(x / i);
                    break;
                }
            }
        }

        #endregion

        #region 小青蛙跳台阶

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


        #endregion

        #region 计算指数幂

        /// <summary>
        /// 二分幂1
        /// </summary>
        /// <param name="n">底数，需要与返回类型一致，否则递归处会随着迭代溢出</param>
        /// <param name="power">指数</param>
        /// <returns></returns>
        public static long Pow1(long n, int power)
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
                return Pow1(n * n, power / 2);
            }
            return n * Pow1(n * n, power / 2);
        }

        /// <summary>
        /// 二分幂2
        /// </summary>
        /// <param name="n">底数</param>
        /// <param name="power">指数</param>
        /// <returns></returns>
        public static long Pow2(int n, int power)
        {
            if (power == 0)
            {
                return 1;
            }

            if (power == 1)
            {
                return n;
            }

            var re = Pow2(n, power >> 1);
            re *= re;
            if (power % 2 == 1)
            {
                re *= n;
            }

            return re;
        }

        /// <summary>
        /// 快速幂
        /// </summary>
        /// <param name="n">底数，需要与返回类型一致，否则递归处会随着迭代溢出</param>
        /// <param name="power">指数</param>
        /// <returns></returns>
        public static long Pow3(long n, int power)
        {
            long res = 1;
            while (power != 0)
            {
                if (power % 2 != 0)//如果是奇数
                {
                    res *= n;
                }
                n *= n;
                power >>= 1;
            }

            return res;
        }
        /// <summary>
        /// 快速幂
        /// </summary>
        /// <param name="n">底数，需要与返回类型一致，否则递归处会随着迭代溢出</param>
        /// <param name="power">指数</param>
        /// <returns></returns>
        public static double Pow4(double x, int n)
        {
            bool isNegative = n < 0;
            double res = 1d;
            while (n != 0)
            {
                if (n % 2 != 0)//如果是奇数
                {
                    res *= x;
                }
                x *= x;
                n /= 2;
            }
            return isNegative ? 1 / res : res;
        }
        #endregion

        /// <summary>
        /// 幂模
        /// </summary>
        /// <param name="n">底数（正整数）</param>
        /// <param name="power">指数（正整数）</param>
        /// <param name="mod">对mod求模（正整数）</param>
        /// <returns>模</returns>
        public static int PowMod(int n, long power, int mod)
        {
            int res = 1;
            while (power != 0)
            {
                if (power % 2 == 1)//如果是奇数
                {
                    res = (res * n) % mod;
                }
                n = (n % mod) * (n % mod) % mod;
                power >>= 1;
            }

            return res;
        }

        public static bool F(string input, string rule)
        {
            var left = -1;//左指针
            var right = -1;//右指针
            var isMatch = true;
            var cusOperator = '/';//初始化操作符
            var formatICD = rule + " ";//用“ ”作为结束标志
            for (int i = 0; i < formatICD.Length; i++)
            {
                right = i;
                if (formatICD[right] == '/' || formatICD[right] == '-' || formatICD[right] == ' ')
                {
                    var keyword = formatICD.Substring(left + 1, right - left - 1);
                    switch (cusOperator)
                    {
                        case '/':
                            if (!input.Contains(keyword))
                            {
                                isMatch = false;
                                i = formatICD.Length;
                            }
                            cusOperator = formatICD[right];
                            break;
                        case '-':
                            if (input.Contains(keyword))
                            {
                                isMatch = false;
                                i = formatICD.Length;
                            }
                            cusOperator = formatICD[right];
                            break;
                        default:
                            break;
                    }
                    left = right;
                }
            }
            return isMatch;

        }
    }
}
