namespace Bolt.Common.Extensions;

public static class StreamExtensions
{
    public static async Task<string> ReadAsString(this Stream ms, CancellationToken ct)
    {
        using var sr = new StreamReader(ms);
#if NET8_0_OR_GREATER
        return await sr.ReadToEndAsync(ct);
#else
        return await sr.ReadToEndAsync();
#endif
    }

    public static MemoryStream ToMemoryStream(this string source)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(source);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}