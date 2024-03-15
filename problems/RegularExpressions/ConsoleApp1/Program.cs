public class Solution
{
    
    public static void Main(string[] args)
    {
        var a = new List<int>();
        a.Max()
    }
    public static  bool IsMatch(string s, string p)
    {
        //recursion
        int s_len = s.Length; int p_len = p.Length;
        if (p_len == 0)
            return s_len == 0;

        bool FirstMatch = s[0] == p[0] || s[0] == '.';
        if (p_len >= 2 && p[1] == '*')
            return IsMatch(s, p.Substring(2)) ||
            (FirstMatch && IsMatch(s.Substring(1), p));
        else
        {
            return FirstMatch && IsMatch(s.Substring(1), p.Substring(1));
        }
    }
}