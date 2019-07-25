namespace Algorithm
{
    public class SortAlgorithm
    {
        //八大排序
        /// <summary>
        /// 快排
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuickSort(int[] arr, int low, int high)
        {
            int left = low;
            int right = high;
            if (right - left < 1)
            {
                return;
            }
            int key = arr[low];

            while (left < right)
            {
                while (left < right)
                {
                    if (arr[right] < key)
                    {
                        Swap(ref arr[left], ref arr[right]);
                        break;
                    }

                    right--;
                }

                while (left < right)
                {
                    if (arr[left] > key)
                    {
                        Swap(ref arr[left], ref arr[right]);
                        break;
                    }

                    left++;
                }
            }
            QuickSort(arr, low, left - 1);
            QuickSort(arr, right + 1, high);
            void Swap(ref int a, ref int b)
            {
                int t = a;
                a = b;
                b = t;
            }
        }
    }
}
