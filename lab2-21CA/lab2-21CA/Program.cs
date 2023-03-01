namespace MyApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			String filename = Console.ReadLine();
			String file = ReadFile(filename);

			file = EraseExtraChar(file);

			string[] words = file.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
			Dictionary<int, int> dictLettersCount = new Dictionary<int, int>();

			String text = "";

			foreach (string word in words)
			{
				int lettersCount = word.Length;
				if (dictLettersCount.ContainsKey(lettersCount))
				{
					dictLettersCount[lettersCount]++;
				}
				else
				{
					dictLettersCount.Add(lettersCount, 1);
				}

				
			}

			WriteResults(text, dictLettersCount);
		}

		private static String EraseExtraChar(String text)
		{
			text = text.Replace("\t", " ");
			text = text.Replace("\n", " ");
			text = text.Replace("\r", " ");
			return text;
		}

		private static String ReadFile(String filename)
		{
			return File.ReadAllText("D:\\Coding\\Programming\\C#\\lab2\\lab2-21CA\\lab2-21CA\\resources\\" + filename + ".txt");
		}

		private static void WriteResults(String text, Dictionary<int, int> dictLettersCount)
		{
			String path = "D:\\Coding\\Programming\\C#\\lab2\\lab2-21CA\\lab2-21CA\\resources\\result.txt";
			File.Create(path).Close();

			foreach (var item in dictLettersCount.OrderBy(item => item.Key))
			{
				text += item.Key.ToString() + " букв - " + item.Value.ToString() + "\n";
			}

			File.WriteAllText(Path.Combine(path), text);
		}
	}
}