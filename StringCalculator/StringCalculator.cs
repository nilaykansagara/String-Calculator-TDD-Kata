namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            // check null or empty string
            if (String.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            // list of the delimiters
            var delimiters = new List<string> { ",", "\n" };

            // check for different delimiter
            if (numbers.StartsWith("//"))
            {
                int newLineDelimiterIndex = numbers.IndexOf('\n');
                var delimiterString = numbers.Substring(2, newLineDelimiterIndex - 2);

                // check if delimiter is longer than one character
                if (delimiterString.Length > 1)
                {
                    // split delimiter string to remove brackets
                    var differentDelimiters = delimiterString.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
                    delimiters.AddRange(differentDelimiters.ToList());
                }
                else
                {
                    delimiters.Add(numbers[2].ToString());
                }
                numbers = numbers.Substring(newLineDelimiterIndex + 1);
            }

            // convert all numbers from string to integers
            var values = numbers.Split(delimiters.ToArray(), StringSplitOptions.None)
                .Select(x => Convert.ToInt32(x))
                .Where(x => x <= 1000);

            // check for negative number
            var negativeNumbers = values.Where(x => x < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negative numbers not allowed: {string.Join(",", negativeNumbers)}");
            }

            // sum up all numbers
            return values.Sum();
        }
    }
}
