namespace Bolt.Common.Extensions
{
    public static class NullHelperExtensions
    {
        public static TStruct NullSafe<TStruct>(this TStruct? source) where TStruct : struct
        {
            return source ?? default(TStruct);
        }
    }
}