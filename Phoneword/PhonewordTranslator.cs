using System;
using System.Linq;
using System.Text;

namespace Phoneword
{
	internal class PhonewordTranslator
	{
		public static string ToNumber(string raw)
		{
			if (String.IsNullOrWhiteSpace(raw))
			{
				return "";
			}
			else
			{
				raw = raw.ToUpperInvariant();
			}

			var newNumber = new StringBuilder();
			var charsToSkip = " -0123456789";
			foreach (var c in raw)
			{
				if (charsToSkip.Contains(c))
				{
					newNumber.Append(c);
				}
				else
				{
					var result = TranslateToNumber(c);

					if (result != null)
					{
						newNumber.Append(result);
					}
				}

				// otherwise we got a non-numeric char. And skipped that.

				
			}
			return newNumber.ToString();
		}

		private static int? TranslateToNumber(char c)
		{
			if (char.IsLetter(c))
			{
				return c % 48 / 5;
			}
			else
			{
				return null;
			}
		}
	}
}