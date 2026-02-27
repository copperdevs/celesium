namespace CopperDevs.Celesium;

public static class FuzzySearch
{
    public static string? FindClosest(string input, IEnumerable<string> options)
    {
        var enumerable = options as string[] ?? options.ToArray();

        if (string.IsNullOrWhiteSpace(input) || enumerable.Length == 0)
            return null;

        return enumerable
            .OrderBy(option => GetLevenshteinDistance(input, option))
            .First();
    }

    private static int GetLevenshteinDistance(string s, string t)
    {
        if (s == t) return 0;
        if (string.IsNullOrEmpty(s)) return t.Length;
        if (string.IsNullOrEmpty(t)) return s.Length;

        var d = new int[s.Length + 1, t.Length + 1];

        for (var i = 0; i <= s.Length; i++) d[i, 0] = i;
        for (var j = 0; j <= t.Length; j++) d[0, j] = j;

        for (var i = 1; i <= s.Length; i++)
        {
            for (var j = 1; j <= t.Length; j++)
            {
                var cost = s[i - 1] == t[j - 1] ? 0 : 1;

                d[i, j] = Math.Min(
                    Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                    d[i - 1, j - 1] + cost
                );
            }
        }

        return d[s.Length, t.Length];
    }
}