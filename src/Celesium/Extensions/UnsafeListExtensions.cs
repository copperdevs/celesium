using System.Runtime.InteropServices;

namespace CopperDevs.Celesium;

public static unsafe class UnsafeListExtensions
{
    public delegate void UnsafeAction<T>(T* ptr) where T : unmanaged;

    extension<TType>(List<TType> items) where TType : unmanaged
    {
        public void UseAsPointer(UnsafeAction<TType> usage)
        {
            ArgumentNullException.ThrowIfNull(items);
            ArgumentNullException.ThrowIfNull(usage);

            fixed (TType* ptr = CollectionsMarshal.AsSpan(items))
                usage(ptr);
        }

        public void UseAsPointer<TTarget>(Func<TType, TTarget> conversion, UnsafeAction<TTarget> usage) where TTarget : unmanaged
        {
            ArgumentNullException.ThrowIfNull(items);
            ArgumentNullException.ThrowIfNull(conversion);
            ArgumentNullException.ThrowIfNull(usage);

            var nativePoint = new TTarget[items.Count];

            for (var i = 0; i < items.Count; i++)
                nativePoint[i] = conversion.Invoke(items[i]);

            fixed (TTarget* pointsPtr = nativePoint)
                usage?.Invoke(pointsPtr);
        }
    }
}