namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            // check null or empty string
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            // get delimiters
            var delimiters = ExtractDelimiters(ref numbers);

            // convert all numbers from string to integers
            var values = numbers.Split(delimiters.ToArray(), StringSplitOptions.None)
                .Select(x => Convert.ToInt32(x));

            // check for negative numbers
            CheckNegativeNumbers(values.ToList());

            // sum up all numbers less than or equals to 1000
            return values.Where(x => x <= 1000).Sum();
        }

        private static List<string> ExtractDelimiters(ref string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };

            // check for different delimiter
            if (numbers.StartsWith("//"))
            {
                int newLineDelimiterIndex = numbers.IndexOf('\n');
                var delimiterString = numbers.Substring(2, newLineDelimiterIndex - 2);

                // if delimiter string is longer than one character, split it to remove brackets
                delimiters.AddRange(delimiterString.Length > 1
                    ? delimiterString.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries)
                    : new[] { delimiterString });

                numbers = numbers.Substring(newLineDelimiterIndex + 1);
            }

            return delimiters;
        }

        private static void CheckNegativeNumbers(List<int> numbers)
        {
            var negativeNumbers = numbers.Where(x => x < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negative numbers not allowed: {string.Join(",", negativeNumbers)}");
            }
        }
    }
}
