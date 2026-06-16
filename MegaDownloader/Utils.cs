using System.Globalization;
using System.Text;

namespace MegaDownloader;

public class Utils
{
	internal static string RemoveDiacritics(string stIn)
	{
		if (string.IsNullOrEmpty(stIn))
		{
			return stIn;
		}
		string text = stIn.Normalize(NormalizationForm.FormD);
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			int num = text.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				if (CharUnicodeInfo.GetUnicodeCategory(text[i]) != UnicodeCategory.NonSpacingMark)
				{
					stringBuilder.Append(text[i]);
				}
			}
			return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
		}
	}
}
