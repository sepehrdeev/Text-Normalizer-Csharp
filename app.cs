using System.Text.RegularExpressions;
using System.Text;
using System.Dynamic;

public class TextNormalizer
{
    private static readonly HashSet<string> StopWords = new HashSet<string>
    {
        "a", "an", "the", "is", "are", "and", "or", "not", "to", "in", "for", "of", "on", "at"
    };

    public static string NormalizeTextWithCustomArguments(string inputText = "", bool unifyCharacters = false,
        bool removeExteraString = false, bool removeHtmlTags = false, bool removeStopWords = false,
        bool replaceUrl = false,
        bool replacePhoneNumbers = false, bool removeJavascript = false, bool removeSymbols = false)
    {
        if (string.IsNullOrEmpty(inputText))
            throw new ArgumentNullException(string.Format("{0} Can't Be Null", nameof(inputText)));
        string normalizedText = inputText;

        if (removeHtmlTags)
            // RemoveHtmlTags
            normalizedText = Regex.Replace(normalizedText, "<.*?>", string.Empty);
        if (unifyCharacters)
            //UnifyCharacters
            normalizedText = normalizedText.Normalize(NormalizationForm.FormKD);
        if (removeExteraString)
            //RemoveExtraSpace
            normalizedText = Regex.Replace(normalizedText, @"\s+", " ").Trim();

        if (removeJavascript)
            // RemoveJavaScript
            normalizedText = Regex.Replace(normalizedText, @"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>", string.Empty, RegexOptions.IgnoreCase);
        if (replaceUrl)
            // replaceUrl
            normalizedText = Regex.Replace(normalizedText, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", string.Empty);
        if (removeStopWords)
        {
            string[] words = normalizedText.Split(' ');

            IEnumerable<string> filteredWords = words.Where(w => !StopWords.Contains(w.ToLower()));

            normalizedText = string.Join(" ", filteredWords);
        }
        if (replacePhoneNumbers)
            // replcaePhoneNumbers
            normalizedText = Regex.Replace(normalizedText, @"\b(?:\+\d{1,3}\s?)?(?:\(\d{1,3}\)\s?)?(?:\d{1,4}[\s-]?)?\d{1,4}[\s-]?\d{1,9}\b", string.Empty);

        if (removeSymbols)
            normalizedText = Regex.Replace(normalizedText, @"[!@#$%^&*()\-=_+[\]{};':""\\|,.<>/?]", string.Empty);
        return normalizedText;
    }

    public static string NormalizeText(string textInput) => NormalizeTextWithCustomArguments(textInput, true, true, true, true, true, true, true, true);

}

public class Program
{
    private static void Main(string[] args)
    {
        // Example 
        string text = "This is an example text with HTML tags <b>and</b> JavaScript code. Visit https://example.com for more information. Contact us at 123-456-7890 or (987) 654-3210.";
        string result = TextNormalizer.NormalizeText(text);
        Console.WriteLine(result);

        Console.ReadLine();
    }
}