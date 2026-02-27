namespace CopperDevs.Celesium;

public static class StreamExtensions
{
    extension(Stream stream)
    {
        public MemoryStream Clone()
        {
            if (stream.CanSeek)
                stream.Position = 0;

            MemoryStream clonedStream = new();
            stream.CopyTo(clonedStream);
            clonedStream.Position = 0;
            return clonedStream;
        }
    }
}