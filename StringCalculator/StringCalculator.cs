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
                // check if delimiter is longer than one character
                int newLineDelimiterIndex = numbers.IndexOf('\n');
                if (newLineDelimiterIndex >= 5)
                {
                    delimiters.Add(numbers.Substring(3, newLineDelimiterIndex - 4));
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
