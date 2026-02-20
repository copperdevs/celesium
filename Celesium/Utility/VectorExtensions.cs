using System.Numerics;

namespace CopperDevs.Celesium;

public static class VectorExtensions
{
    extension(Vector2 vector)
    {
        public Vector2 WithX(float x) => vector with { X = x };
        public Vector2 WithY(float y) => vector with { Y = y };

        public Vector2 InvertX() => vector.WithX(-vector.X);
        public Vector2 InvertY() => vector.WithY(-vector.Y);

        public Vector3 ToVector3(float z = 0) => new(vector.X, vector.Y, z);
        public Vector4 ToVector4(float z = 0, float w = 0) => new(vector.X, vector.Y, z, w);
    }

    extension(Vector3 vector)
    {
        public Vector3 WithX(float x) => vector with { X = x };
        public Vector3 WithY(float y) => vector with { Y = y };
        public Vector3 WithZ(float z) => vector with { Z = z };

        public Vector2 WithoutX() => new(vector.Y, vector.Z);
        public Vector2 WithoutY() => new(vector.X, vector.Z);
        public Vector2 WithoutZ() => new(vector.X, vector.Y);

        public Vector3 InvertX() => vector.WithX(-vector.X);
        public Vector3 InvertY() => vector.WithY(-vector.Y);
        public Vector3 InvertZ() => vector.WithZ(-vector.Z);

        public Vector4 ToVector4(float w = 0) => new(vector.X, vector.Y, vector.Z, w);
    }

    extension(Vector4 vector)
    {
        public Vector4 WithX(float x) => vector with { X = x };
        public Vector4 WithY(float y) => vector with { Y = y };
        public Vector4 WithZ(float z) => vector with { Z = z };
        public Vector4 WithW(float w) => vector with { W = w };

        public Vector3 WithoutX() => new(vector.Y, vector.Z, vector.W);
        public Vector3 WithoutY() => new(vector.X, vector.Z, vector.W);
        public Vector3 WithoutZ() => new(vector.X, vector.Y, vector.W);
        public Vector3 WithoutW() => new(vector.X, vector.Y, vector.Z);

        public Vector4 InvertX() => vector.WithX(-vector.X);
        public Vector4 InvertY() => vector.WithY(-vector.Y);
        public Vector4 InvertZ() => vector.WithZ(-vector.Z);
        public Vector4 InvertW() => vector.WithW(-vector.W);
    }
}