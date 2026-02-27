using System.Numerics;

namespace CopperDevs.Celesium;

/// <summary>
/// Common math methods not included in <see cref="MathF"/>
/// </summary>
[Obsolete("Mainly included for better backwards compatibility with CopperDevs.Core. Most methods have been remade as extensions.")]
public static class MathUtil
{
    /// <summary>
    /// Convert degrees to radians
    /// </summary>
    /// <param name="degrees">Degrees</param>
    /// <returns>The input degrees value in radians</returns>
    public static float DegreesToRadians(float degrees) => Math.DegreesToRadians(degrees);

    /// <summary>
    /// Convert radians to degrees
    /// </summary>
    /// <param name="radians">Radians</param>
    /// <returns>The input radians value in degrees</returns>
    public static float RadiansToDegrees(float radians) => Math.RadiansToDegrees(radians);

    /// <remarks>
    /// https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
    /// </remarks>
    [Obsolete] // deprecating with no alternative mainly because im like 90% sure my math is wrong
    public static Vector3 ToEulerAngles(Quaternion quaternion)
    {
        Vector3 angles;

        // roll (x-axis rotation)
        var sinrCosp = 2 * (quaternion.W * quaternion.X + quaternion.Y * quaternion.Z);
        var cosrCosp = 1 - 2 * (quaternion.X * quaternion.X + quaternion.Y * quaternion.Y);
        angles.X = MathF.Atan2(sinrCosp, cosrCosp);

        // pitch (y-axis rotation)
        var sinp = 2 * (quaternion.W * quaternion.Y - quaternion.Z * quaternion.X);
        angles.Y = MathF.Abs(sinp) >= 1 ? MathF.CopySign(MathF.PI / 2, sinp) : MathF.Asin(sinp);

        // yaw (z-axis rotation)
        var sinyCosp = 2 * (quaternion.W * quaternion.Z + quaternion.X * quaternion.Y);
        var cosyCosp = 1 - 2 * (quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z);
        angles.Z = MathF.Atan2(sinyCosp, cosyCosp);

        return angles;
    }
    
    /// <remarks>
    /// https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
    /// </remarks>
    [Obsolete] // deprecating with no alternative mainly because im like 90% sure my math is wrong
    public static Quaternion FromEulerAngles(Vector3 euler)
    {
        var cr = MathF.Cos(euler.X * 0.5f);
        var sr = MathF.Sin(euler.X * 0.5f);
        var cp = MathF.Cos(euler.Y * 0.5f);
        var sp = MathF.Sin(euler.Y * 0.5f);
        var cy = MathF.Cos(euler.Z * 0.5f);
        var sy = MathF.Sin(euler.Z * 0.5f);

        var quaternion = Quaternion.Identity;
        quaternion.W = cr * cp * cy + sr * sp * sy;
        quaternion.X = sr * cp * cy - cr * sp * sy;
        quaternion.Y = cr * sp * cy + sr * cp * sy;
        quaternion.Z = cr * cp * sy - sr * sp * cy;

        return quaternion;
    }

    /// <summary>
    /// Clamp a value between a range
    /// </summary>
    /// <param name="value">Value to clamp</param>
    /// <param name="min">Minimum value of the clamp range</param>
    /// <param name="max">Maximum value of the clamp range</param>
    /// <returns>The clamped value</returns>
    public static float Clamp(float value, float min, float max) => Math.Clamp(value, min, max);


    /// <summary>
    /// Clamp a value between a range
    /// </summary>
    /// <param name="value">Value to clamp</param>
    /// <param name="min">Minimum value of the clamp range</param>
    /// <param name="max">Maximum value of the clamp range</param>
    /// <returns>The clamped value</returns>
    public static int Clamp(int value, int min, int max) => Math.Clamp(value, min, max);

    /// <summary>
    /// Clamp a value between a range
    /// </summary>
    /// <param name="value">Value to clamp</param>
    /// <param name="range">Range of the values to clamp</param>
    /// <returns>The clamped value</returns>
    public static float Clamp(float value, Vector2 range) => Math.Clamp(value, range.X, range.Y);

    /// <summary>
    /// Clamp a value between a range
    /// </summary>
    /// <param name="value">Value to clamp</param>
    /// <param name="range">Range of the values to clamp</param>
    /// <returns>The clamped value</returns>
    public static int Clamp(int value, Vector2 range) => Math.Clamp(value, (int)range.X, (int)range.Y);

    /// <summary>
    /// Clamp a value between a range
    /// </summary>
    /// <param name="value">Value to clamp</param>
    /// <param name="range">Range of the values to clamp</param>
    /// <returns>The clamped value</returns>
    public static int Clamp(int value, Vector2Int range) => Math.Clamp(value, range.X, range.Y);

    /// <summary>
    /// Clamp a value between a range
    /// </summary>
    /// <param name="value">Value to clamp</param>
    /// <param name="min">Minimum value of the clamp range</param>
    /// <param name="max">Maximum value of the clamp range</param>
    /// <returns>The clamped value</returns>
    public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max) => Math.Clamp(value, min, max);

    /// <summary>
    /// Linearly interpolates between two points.
    /// </summary>
    /// <param name="a">Start value</param>
    /// <param name="b">End value</param>
    /// <param name="t">Value used to interpolate between a and b.</param>
    /// <returns>Interpolated value</returns>
    public static float Lerp(float a, float b, float t) => Math.Lerp(a, b, t);

    /// <summary>
    /// Determines where a value lies between two points.
    /// </summary>
    /// <param name="a">The start of the range.</param>
    /// <param name="b">The end of the range.</param>
    /// <param name="v">The point within the range you want to calculate.</param>
    /// <returns>A value between zero and one, representing where the "value" parameter falls within the range defined by a and b.</returns>
    public static float InverseLerp(float a, float b, float v) => Math.InverseLerp(a, b, v);

    /// <summary>
    /// Remap a value from one range to another range
    /// </summary>
    /// <param name="input">Input value</param>
    /// <param name="inputMin">Minimum range of the input value</param>
    /// <param name="inputMax">Maximum range of the input value</param>
    /// <param name="min">Minimum range of the output value</param>
    /// <param name="max">Maximum range of the output value</param>
    /// <returns>Remapped value</returns>
    public static float ReMap(float input, float inputMin, float inputMax, float min, float max) => Math.ReMap(input, inputMin, inputMax, min, max);

    /// <summary>
    /// Linearly interpolates between two points.
    /// </summary>
    /// <param name="a">Start value</param>
    /// <param name="b">End value</param>
    /// <param name="t">Value used to interpolate between a and b.</param>
    /// <returns>Interpolated value</returns>
    public static Vector3 Lerp(Vector3 a, Vector3 b, float t) => Math.Lerp(a, b, t);

    /// <summary>
    /// Linearly interpolates between two points.
    /// </summary>
    /// <param name="a">Start value</param>
    /// <param name="b">End value</param>
    /// <param name="t">Value used to interpolate between a and b.</param>
    /// <returns>Interpolated value</returns>
    public static Vector2 Lerp(Vector2 a, Vector2 b, float t) => Math.Lerp(a, b, t);

    /// <summary>
    /// Remap a vector from one range of values to another
    /// </summary>
    /// <param name="input">Input vector</param>
    /// <param name="inputMin">Minimum range of the input vector</param>
    /// <param name="inputMax">Maximum range of the input vector</param>
    /// <param name="outputMin">Minimum range of the output vector</param>
    /// <param name="outputMax">Maximum range of the output vector</param>
    /// <returns>Remapped vector</returns>
    public static Vector2 ReMap(Vector2 input, Vector2 inputMin, Vector2 inputMax, Vector2 outputMin, Vector2 outputMax) => Math.ReMap(input, inputMin, inputMax, outputMin, outputMax);

    /// <summary>
    /// Create a rotated unit vector from degrees
    /// </summary>
    /// <param name="rotation">Degrees</param>
    /// <returns>Vector2 rotated unit vector</returns>
    public static Vector2 CreateRotatedUnitVector(float rotation) => Math.CreateRotatedUnitVector(rotation);

    /// <summary>
    /// Cross Product of two vectors
    /// </summary>
    /// <param name="a">First vector</param>
    /// <param name="b">Second vector</param>
    /// <returns>The cross product</returns>
    public static float CrossProduct(Vector2 a, Vector2 b) => Math.CrossProduct(a, b);

    /// <summary>
    /// Cross Product of a vector and a value
    /// </summary>
    /// <param name="a">Vector</param>
    /// <param name="s">Value</param>
    /// <returns>The cross product</returns>
    public static Vector2 CrossProduct(Vector2 a, float s) => Math.CrossProduct(a, s);

    /// <summary>
    /// Cross Product of a vector and a value
    /// </summary>
    /// <param name="s">Value</param>
    /// <param name="a">Vector</param>
    /// <returns>The cross product</returns>
    public static Vector2 CrossProduct(float s, Vector2 a) => Math.CrossProduct(s, a);

    /// <summary>
    /// Get the length of a vector
    /// </summary>
    /// <param name="vector">Target vector</param>
    /// <returns>The length</returns>
    public static float Length(Vector2 vector) => vector.Length();

    /// <summary>
    /// Find the magnitude of a vector
    /// </summary>
    /// <param name="vector">Target vector</param>
    /// <returns>Magnitude of the vector</returns>
    public static float Magnitude(Vector3 vector) => Math.Magnitude(vector);

    /// <summary>
    /// Get the square length of a vector
    /// </summary>
    /// <param name="vector">Target vector</param>
    /// <returns>The square length of the vector</returns>
    public static float SqrLength(Vector2 vector) => vector.LengthSquared();

    /// <summary>
    /// Normalize a vector
    /// </summary>
    /// <param name="vector">Vector to normalize</param>
    /// <returns>The normalized vector</returns>
    public static Vector2 Normalized(Vector2 vector) => Math.Normalized(vector);

    /// <summary>
    /// Return a direction that points from the position to the point
    /// </summary>
    /// <param name="position">Direction origin</param>
    /// <param name="point">Look at target</param>
    /// <returns>Value between 0-360</returns>
    public static float LookAt(Vector2 position, Vector2 point) => Math.LookAt(position, point);

    /// <summary>
    /// Round a vector to the nearest int
    /// </summary>
    /// <param name="vector">Input vector</param>
    /// <returns>Input vector with int rounded values</returns>
    public static Vector3 RoundToInt(Vector3 vector) => Math.RoundToInt(vector);
}