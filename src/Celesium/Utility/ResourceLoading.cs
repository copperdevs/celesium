using System.Reflection;
using System.Text;

namespace CopperDevs.Celesium;

// TODO: add an option to load an arbitrary full path and it auto gets the correct assembly
/// <summary>
/// Utility class for loading manifest resources from an assembly
/// </summary>
public class ResourceLoading
{
    private readonly Assembly targetAssembly;

    /// <summary>
    /// Create a new loader with a specified assembly
    /// </summary>
    /// <param name="targetAssembly">Assembly to load the resource from</param>
    public ResourceLoading(Assembly targetAssembly)
    {
        this.targetAssembly = targetAssembly;
    }

    /// <summary>
    /// Load a resource from an assembly as a byte array
    /// </summary>
    /// <param name="fullPath">Full path of the resource</param>
    /// <returns>Target resource as a byte array</returns>
    public byte[] LoadAsset(string fullPath)
    {
        var stream = targetAssembly.GetManifestResourceStream(fullPath);

        using var ms = new MemoryStream();

        stream?.CopyTo(ms);

        return ms.ToArray();
    }

    /// <summary>
    /// Load a resource from an assembly as a string
    /// </summary>
    /// <param name="fullPath">Full path of the resource</param>
    /// <returns>Target resource as a string</returns>
    public string LoadTextAsset(string fullPath)
    {
        var bytes = LoadAsset(fullPath);

        return Encoding.Default.GetString(bytes, 0, bytes.Length);
    }
}