
namespace Validators
{
	class IntValidators
	{
		public static int? GreaterThanZero(string? str)
		{
			int number;
			if (int.TryParse(str, out number) == false)
				return null;

			if (number <= 0)
				return null;

			return (number);
		}

		public static bool TryGreaterThanZero(string? number)
		{
			int val;

			if ((number == null) || (int.TryParse(number, out val) == false))
				return false;

			return (val > 0);
		}
	}

	class StringValidators
	{
		public static bool IsUpperCase(char letter)
			=> (letter >= 'A' && letter <= 'Z');
		public static bool IsLowerCase(char letter)
			=> (letter >= 'a' && letter <= 'z');
		public static bool IsLetter(char letter)
			=> (IsUpperCase(letter) || IsLowerCase(letter));
		public static bool IsNumber(char letter)
			=> (letter >= '0' && letter <= '9');

		public static string? IsTitle(string? str)
		{
			if (str == null)
				return null;
			char[] characters = str.ToCharArray();
			if (StringValidators.IsUpperCase(characters[0]) == false)
				return null;
			return (string)str;
		}

		public static bool TryTitle(string? title)
			=> (StringValidators.IsTitle(title) != null);

		public static string? IsTransactionNumber(string? str)
		{
			// JJ-232-HH/78

			if (str == null)
				return null;

			if (str.Count() != 12)
				return null;

			if ((str[2] != '-') || (str[6] != '-') || (str[9] != '/'))
				return null;

			for (int i = 0; i < 2; ++i)
			{
				if (IsLetter(str[i]) == false)
				{
					return null;
				}
			}
			for (int i = 7; i < 9; ++i)
			{
				if (IsLetter(str[i]) == false)
				{
					return null;
				}
			}

			for (int i = 3; i < 6; ++i)
			{
				if (IsNumber(str[i]) == false)
				{
					return null;
				}
			}
			for (int i = 10; i < 12; ++i)
			{
				if (IsNumber(str[i]) == false)
				{
					return null;
				}
			}


			return (string)str;
		}

		public static bool TryTransactionNumber(string? number)
			=> (StringValidators.IsTransactionNumber(number) != null);

		public static string? IsUrl(string? str)
		{
			if (str == null)
				return null;

			return (string)str;
		}

		public static bool TryUrl(string? url)
			=> (StringValidators.IsUrl(url) != null);
	}

	class DateValidators
	{
		public static DateOnly? IsDate(string? str)
		{
			if (str == null)
				return null;


			return DateOnly.Parse(str);
		}
	}
}
