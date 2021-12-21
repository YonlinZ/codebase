using System.Collections;

namespace ConsoleApp
{
    public static class IEnumrableEx
    {
        public static bool HasOne(this IEnumerable source)
        {
            if (source == null)
            {
                return false;
            }
            var i = source.GetEnumerator();

            return i.MoveNext() && !i.MoveNext();
        }
    }
}
