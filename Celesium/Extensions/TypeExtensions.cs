using System.Reflection;

namespace CopperDevs.Celesium;

public static class TypeExtensions
{
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
    }
}