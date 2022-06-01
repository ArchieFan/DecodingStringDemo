using System.Text;

public class Solution
{
    
    public string DecodeString(string s)
    {
        StringBuilder finalstr = new StringBuilder();
        StringBuilder multiplier = new StringBuilder();
        StringBuilder multiplicand = new StringBuilder();
        StringBuilder Getmultiplicand = new StringBuilder();
        bool start_getting_multiplicand = false;
        int count_parentheses = 0;
        
        int index = 1;
        foreach (char c in s)
        {
            if (!start_getting_multiplicand)
            {
                if (char.IsDigit(c))
                {
                    multiplier.Append(c);
                }
                else if (c.ToString() == "[")
                {
                    start_getting_multiplicand = true;
                    count_parentheses++;
                }
                else if (c.ToString() != "]")
                {
                    finalstr.Append(c);
                }
            } else
            {
                if (c.ToString() == "]" && count_parentheses==1)
                {
                    Getmultiplicand.Append("]");
                    Solution sol = new Solution();
                    multiplicand.Append(sol.DecodeString(Getmultiplicand.ToString()));
                    if (multiplier.ToString() != "")
                    {
                        for (int i = 0; i < int.Parse(multiplier.ToString()); i++)
                        {
                            finalstr.Append(multiplicand);
                        }
                    }
                    else
                    {
                        finalstr.Append(multiplicand);
                    }
                    multiplier.Clear();
                    multiplicand.Clear();
                    Getmultiplicand.Clear();
                    start_getting_multiplicand = false;
                    count_parentheses = 0;
                }
                else {
                    if (c.ToString() == "[")
                    {
                        count_parentheses++;
                    } else if (c.ToString() == "]")
                    {
                        count_parentheses--;
                    }
                    Getmultiplicand.Append(c);
                }
            }
            index++;
        }
        return finalstr.ToString();
    }

    static void Main()
    {
        // 3[a]2[bc]
        // 3[a2[c]]
        // 2[abc]3[cd]ef
        // 3[z]2[2[y]pq4[2[jk]e1[f]]]ef

        Solution sol = new Solution();
        string s1 = "3[z]2[2[y]pq4[2[jk]e1[f]]]ef";
        Console.WriteLine(sol.DecodeString(s1));

        string s2 = "3[a2[c2[d]]]";
        Console.WriteLine(sol.DecodeString(s2));

        string s3 = "2[abc]3[cd]ef";
        Console.WriteLine(sol.DecodeString(s3));
    }
}
