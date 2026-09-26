namespace CopperDevs.Celesium;

public static class CollectionsExtensions
{
    extension<T>(IList<T> list)
    {
        public T[] AddFirstItem(T item)
        {
            var newArray = new T[list.Count + 1];
            newArray[0] = item;

            switch (list)
            {
                case T[] array:
                    Array.Copy(array, 0, newArray, 1, array.Length);
                    break;
                case ICollection<T> collection:
                    collection.CopyTo(newArray, 1);
                    break;
                default:
                {
                    for (var i = 0; i < list.Count; i++)
                        newArray[i + 1] = list[i];
                    break;
                }
            }

            return newArray;
        }

        public bool IsLast(T item)
        {
            if (list.Count == 0)
                return false;
            
            return list.IndexOf(item) == list.Count - 1;
        }

        public bool IsFirst(T item)
        {
            if (list.Count == 0)
                return false;
            
            return list.IndexOf(item) == 0;
        }
    }
}