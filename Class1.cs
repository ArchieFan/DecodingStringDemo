using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodingStringDemo
{
    internal class Class1
    {
		int[] brackets = new int[30];
		public string DecodeString(string s)
		{
			Stack<int> stack = new Stack<int>();
			for (int i = 0; i < s.Length; i++)
			{
				var c = s[i];
				if (c == '[')
					stack.Push(i);
				else if (c == ']')
					brackets[stack.Pop()] = i;
			}

			return Helper(s, 0, s.Length - 1);
		}

		private string Helper(string s, int start, int end)
		{
			string res = "";
			while (start <= end)
			{
				var c = s[start++];
				if (Char.IsLetter(c))
					res += c;
				else if (Char.IsDigit(c))
				{
					int num = int.Parse(c.ToString());
					while (s[start] != '[')
					{
						int n;
						if (int.TryParse(s[start++].ToString(), out n))
						{
							num *= 10;
							num += n;
						}
					}
					var inner = Helper(s, start + 1, brackets[start] - 1);
					for (int i = 0; i < num; i++)
						res += inner;
					start = brackets[start] + 1;
				}
			}

			return res;
		}

		static void Main()
		{
			Class1 sol = new Class1();
			string s1 = "3[z]2[2[y]pq4[2[jk]e1[f]]]ef";
			Console.WriteLine(sol.DecodeString(s1));
		}

	}


}
