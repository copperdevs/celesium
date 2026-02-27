namespace CopperDevs.Celesium;

public static class BoolExtensions
{
    /// <param name="value">Value to invert</param>
    extension(bool value)
    {
        public int ToInt()
        {
            return value ? 1 : 0;
        }

        /// <summary>
        /// Inverts a boolean value
        /// </summary>
        /// <returns>The inverted value</returns>
        public bool Inverted()
        {
            return !value;
        }
    }

    // 
    /// <summary>
    /// Inverts a boolean value
    /// </summary>
    /// <param name="value">Value to invert</param>
    /// <remarks>References the value and sets it directly, instead of returning it</remarks>
    public static void Invert(this ref bool value)
    {
        value = !value;
    }
}