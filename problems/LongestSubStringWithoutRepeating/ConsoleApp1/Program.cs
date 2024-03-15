public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {

        List<char> arr = new List<char> { };
        List<char> temp = new List<char>() { };

        Action<char> AddIfNotExisted = (item) =>
        {
            if (!temp.Contains(item))
            {
                temp.Add(item);
                return;
            }
            int ItemIndex = temp.IndexOf(item);
            temp = temp[(ItemIndex + 1)..];
            temp.Add(item);
        };
        //make a hash set
        //for every add we have to check length if it is changed or not
        //make a new List for checking weather it is bigger than the base or not

        int StrLen = s.Length;
        for (int i = 0; i < StrLen; i++)
        {
            AddIfNotExisted(s[i]);
            arr = arr.Count < temp.Count ? new List<char>(temp) : arr;

        }
        //for every iteration we need to 

        return arr.Count;
    }
}
