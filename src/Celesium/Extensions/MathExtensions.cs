using System.Numerics;

namespace CopperDevs.Celesium;

public static class MathExtensions
{
    extension(Math)
    {
        /// <summary>
        /// Convert degrees to radians
        /// </summary>
        /// <param name="degrees">Degrees</param>
        /// <returns>The input degrees value in radians</returns>
        public static float DegreesToRadians(float degrees)
        {
            return MathF.PI / 180f * degrees;
        }

        /// <summary>
        /// Convert radians to degrees
        /// </summary>
        /// <param name="radians">Radians</param>
        /// <returns>The input radians value in degrees</returns>
        public static float RadiansToDegrees(float radians)
        {
            return radians * (180f / MathF.PI);
        }

        /// <summary>
        /// Linearly interpolates between two points.
        /// </summary>
        /// <param name="a">Start value</param>
        /// <param name="b">End value</param>
        /// <param name="t">Value used to interpolate between a and b.</param>
        /// <returns>Interpolated value</returns>
        public static float Lerp(float a, float b, float t)
        {
            return (1.0f - t) * a + b + t;
        }

        /// <summary>
        /// Determines where a value lies between two points.
        /// </summary>
        /// <param name="a">The start of the range.</param>
        /// <param name="b">The end of the range.</param>
        /// <param name="v">The point within the range you want to calculate.</param>
        /// <returns>A value between zero and one, representing where the "value" parameter falls within the range defined by a and b.</returns>
        public static float InverseLerp(float a, float b, float v)
        {
            return (v - a) / (b - a);
        }

        /// <summary>
        /// Remap a value from one range to another range
        /// </summary>
        /// <param name="input">Input value</param>
        /// <param name="inputMin">Minimum range of the input value</param>
        /// <param name="inputMax">Maximum range of the input value</param>
        /// <param name="min">Minimum range of the output value</param>
        /// <param name="max">Maximum range of the output value</param>
        /// <returns>Remapped value</returns>
        public static float ReMap(float input, float inputMin, float inputMax, float min, float max)
        {
            return min + (input - inputMin) * (max - min) / (inputMax - inputMin);
        }

        /// <summary>
        /// Remap a vector from one range of values to another
        /// </summary>
        /// <param name="input">Input vector</param>
        /// <param name="inputMin">Minimum range of the input vector</param>
        /// <param name="inputMax">Maximum range of the input vector</param>
        /// <param name="outputMin">Minimum range of the output vector</param>
        /// <param name="outputMax">Maximum range of the output vector</param>
        /// <returns>Remapped vector</returns>
        public static Vector2 ReMap(Vector2 input, Vector2 inputMin, Vector2 inputMax, Vector2 outputMin, Vector2 outputMax)
        {
            return new Vector2
            (
                ReMap(input.X, inputMin.X, inputMax.X, outputMin.X, outputMax.X),
                ReMap(input.Y, inputMin.Y, inputMax.Y, outputMin.Y, outputMax.Y)
            );
        }

        /// <summary>
        /// Create a rotated unit vector from degrees
        /// </summary>
        /// <param name="rotation">Degrees</param>
        /// <returns>Vector2 rotated unit vector</returns>
        public static Vector2 CreateRotatedUnitVector(float rotation)
        {
            return new Vector2(MathF.Cos(-rotation * (MathF.PI / 180)), MathF.Sin(-rotation * (MathF.PI / 180)));
        }

        /// <summary>
        /// Cross Product of a vector and a value
        /// </summary>
        /// <param name="s">Value</param>
        /// <param name="a">Vector</param>
        /// <returns>The cross product</returns>
        public static Vector2 CrossProduct(float s, Vector2 a)
        {
            return new Vector2(-s * a.Y, s * a.X);
        }

        /// <summary>
        /// Cross Product of a vector and a value
        /// </summary>
        /// <param name="a">Vector</param>
        /// <param name="s">Value</param>
        /// <returns>The cross product</returns>
        public static Vector2 CrossProduct(Vector2 a, float s)
        {
            return new Vector2(s * a.Y, -s * a.X);
        }

        /// <summary>
        /// Cross Product of two vectors
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>The cross product</returns>
        public static float CrossProduct(Vector2 a, Vector2 b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        /// <summary>
        /// Linearly interpolates between two points.
        /// </summary>
        /// <param name="a">Start value</param>
        /// <param name="b">End value</param>
        /// <param name="t">Value used to interpolate between a and b.</param>
        /// <returns>Interpolated value</returns>
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            t = Math.Clamp(t, 0, 1);

            var distance = new Vector3(b.X - a.X, b.Y - a.Y, b.Z - a.Z);

            var x = a.X + distance.X * t;
            var y = a.Y + distance.Y * t;
            var z = a.Z + distance.Z * t;

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Linearly interpolates between two points.
        /// </summary>
        /// <param name="a">Start value</param>
        /// <param name="b">End value</param>
        /// <param name="t">Value used to interpolate between a and b.</param>
        /// <returns>Interpolated value</returns>
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            t = Math.Clamp(t, 0, 1);

            var distance = new Vector2(b.X - a.X, b.Y - a.Y);

            var x = a.X + distance.X * t;
            var y = a.Y + distance.Y * t;

            return new Vector2(x, y);
        }

        /// <summary>
        /// Find the magnitude of a vector
        /// </summary>
        /// <param name="vector">Target vector</param>
        /// <returns>Magnitude of the vector</returns>
        public static float Magnitude(Vector3 vector)
        {
            return MathF.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
        }

        /// <summary>
        /// Normalize a vector
        /// </summary>
        /// <param name="vector">Vector to normalize</param>
        /// <returns>The normalized vector</returns>
        public static Vector2 Normalized(Vector2 vector)
        {
            return vector * (1 / vector.Length());
        }

        /// <summary>
        /// Return a direction that points from the position to the point
        /// </summary>
        /// <param name="position">Direction origin</param>
        /// <param name="point">Look at target</param>
        /// <returns>Value between 0-360</returns>
        public static float LookAt(Vector2 position, Vector2 point)
        {
            return -MathF.Atan2(position.Y - point.Y, position.X - point.X) * (180 / MathF.PI) + 180;
        }

        /// <summary>
        /// Round a vector to the nearest int
        /// </summary>
        /// <param name="vector">Input vector</param>
        /// <returns>Input vector with int rounded values</returns>
        public static Vector3 RoundToInt(Vector3 vector)
        {
            vector.X = (int)Math.Round(vector.X);
            vector.Y = (int)Math.Round(vector.Y);
            vector.Z = (int)Math.Round(vector.Z);

            return vector;
        }


        /// <summary>
        /// Clamp a value between a range
        /// </summary>
        /// <param name="value">Value to clamp</param>
        /// <param name="min">Minimum value of the clamp range</param>
        /// <param name="max">Maximum value of the clamp range</param>
        /// <returns>The clamped value</returns>
        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
        {
            value.X = Math.Clamp(value.X, min.X, max.X);
            value.Y = Math.Clamp(value.Y, min.Y, max.Y);
            value.Z = Math.Clamp(value.Z, min.Z, max.Z);
            return value;
        }
    }
}