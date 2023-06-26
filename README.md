## Text Normalization Utility

This GitHub project provides a text normalization utility that helps users process and clean up text data. The `NormalizeTextWithCustomArguments` method allows users to apply various transformations to input text based on their specific requirements.

### Features

The utility offers the following features:

1. **Normalization:** The utility can unify characters in the input text, removing any variations or special characters that may exist.

2. **Removal of Extra Strings:** Users can choose to remove any extra whitespace or repeated spaces from the text, ensuring a clean and consistent format.

3. **HTML Tag Removal:** If enabled, the utility removes HTML tags from the input text, ensuring that only the textual content remains.

4. **JavaScript Removal:** Users can opt to remove JavaScript code embedded within the text, ensuring that only the relevant textual information is retained.

5. **URL Replacement:** When enabled, URLs within the text are replaced with an empty string, effectively removing any URLs present.

6. **Stop Word Removal:** Stop words, such as common articles, conjunctions, and prepositions, can be eliminated from the text. The utility uses a predefined list of stop words for this purpose.

7. **Phone Number Replacement:** If desired, phone numbers can be removed from the text, ensuring privacy or removing irrelevant information.

8. **Symbol Removal:** Users can choose to remove various symbols, such as punctuation marks and special characters, from the text.

### Usage

The `NormalizeTextWithCustomArguments` method accepts multiple parameters that control the normalization process. Users can provide their own input text and select which transformations to apply by setting the corresponding boolean arguments. By calling this method, users can normalize their text according to their specific needs.

Additionally, the utility offers a simplified `NormalizeText` method that applies a predefined set of transformations, resulting in a normalized version of the input text.

Please note that if the input text is empty or null, an exception will be thrown to ensure that valid data is provided.

### Additional Information

This project utilizes the C# programming language and makes use of regular expressions (`Regex`) for pattern matching and replacement operations. The code is designed to be flexible, allowing users to customize the normalization process by selecting various options.

Feel free to explore the code and customize it according to your requirements. Contributions and feedback are welcome!

**Disclaimer**: This utility is provided as-is, without any guarantees or warranties. Users are responsible for testing and validating the results according to their specific use cases.
