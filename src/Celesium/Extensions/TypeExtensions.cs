using System.Reflection;

namespace CopperDevs.Celesium;

public static class TypeExtensions
{
    /// <param name="source">Type of the class to get the values from</param>
    extension(Type source)
    {
        public bool Implements<TI>() where TI : class
        {
            return typeof(TI).IsAssignableFrom(source);
        }

        /// <summary>
        /// Checks if a type contains any fields or properties matching the specified criteria.
        /// </summary>
        /// <param name="predicate">Optional predicate to filter members. Defaults to no filter.</param>
        /// <param name="bindingFlags">Optional binding flags to filter members. Defaults to all fields and properties.</param>
        /// <returns>True if any fields or properties match the criteria; otherwise, false.</returns>
        public bool HasAnyValues(
            Func<MemberInfo, bool>? predicate = null,
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
        {
            ArgumentNullException.ThrowIfNull(source);

            // Get all fields and properties
            var fields = source.GetFields(bindingFlags).Cast<MemberInfo>();
            var properties = source.GetProperties(bindingFlags).Cast<MemberInfo>();

            // Combine fields and properties
            var members = fields.Concat(properties);

            // Apply the predicate if provided, otherwise check if any member exists
            return predicate == null
                ? members.Any()
                : members.Any(predicate);
        }

        /// <summary>
        /// Retrieves all fields or properties of a type that match the specified criteria.
        /// </summary>
        /// <param name="predicate">Optional predicate to filter members. Defaults to no filter.</param>
        /// <param name="bindingFlags">Optional binding flags to filter members. Defaults to all fields and properties.</param>
        /// <returns>A collection of matching fields or properties.</returns>
        public IEnumerable<MemberInfo> GetValues(
            Func<MemberInfo, bool>? predicate = null,
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
        {
            ArgumentNullException.ThrowIfNull(source);

            // Get all fields and properties
            var fields = source.GetFields(bindingFlags).Cast<MemberInfo>();
            var properties = source.GetProperties(bindingFlags).Cast<MemberInfo>();

            // Combine fields and properties
            var members = fields.Concat(properties);

            // Apply the predicate if provided
            return predicate == null ? members : members.Where(predicate);
        }

        /// <summary>
        /// Get all public static values from a certain value
        /// </summary>
        /// <typeparam name="T">Field type</typeparam>
        /// <returns>List of found types</returns>
        public List<T> GetAllPublicConstantValues<T>()
        {
            return source
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi is { IsLiteral: true, IsInitOnly: false } && fi.FieldType == typeof(T))
                .Select(x => (T)x.GetRawConstantValue()!)
                .ToList();
        }

        public bool HasAttribute<T>() where T : Attribute
        {
            return source.IsDefined(typeof(T), false);
        }

        public bool IsSameOrSubclass(Type potentialDescendant)
        {
            return potentialDescendant.IsSubclassOf(source) || potentialDescendant == source;
        }
    }
}