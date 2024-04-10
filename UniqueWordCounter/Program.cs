using System.Globalization;

var text = await File.ReadAllTextAsync(@"..\..\..\text.txt");
var charSeparators = new char[] { ' ', '.', ',', '"', ':', ';', '!', '?', '-' };
var textSplit = text.ToLower().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

var wordDic = new SortedDictionary<string, int>();

foreach (var word in textSplit)
{
    if (!wordDic.ContainsKey(word))
    {
        wordDic.Add(word, 1);
    }
    else
    {
        wordDic[word]++;
    }
}

var top10UsedWords = wordDic.OrderBy(w=>w.Value).Reverse().Take(10).ToList();

Console.WriteLine($"Total word count: {textSplit.Count()}");
Console.WriteLine($"Unique word count: {wordDic.Count}\n");

Console.WriteLine("Top 10 used words:");
var placement = 1;
foreach (var word in top10UsedWords)
{
    Console.WriteLine($"{placement}. '{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.Key)}': {word.Value}");
    placement++;
}