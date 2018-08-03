using System.Threading.Tasks;

namespace Bolt.Common.Extensions
{
    public static class TaskExtensions
    {
        public static Task<T> WrapInTask<T>(this T source)
        {
            return Task.FromResult(source);
        }
    }
}
