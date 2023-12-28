namespace Bolt.Common.Extensions;

public static class StreamExtensions
{
    public static async Task<string> ReadAsString(this Stream ms, CancellationToken ct)
    {
        using var sr = new StreamReader(ms);
        return await sr.ReadToEndAsync(ct);
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