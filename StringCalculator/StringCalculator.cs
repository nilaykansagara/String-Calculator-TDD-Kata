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
            var delimiters = new List<char> { ',', '\n' };

            // check for different delimiter
            if (numbers.StartsWith("//"))
            {
                delimiters.Add(numbers[2]);
                numbers = numbers.Substring(4);
            }

            // convert all numbers to int and sum up them
            return numbers.Split(delimiters.ToArray())
                    .Select(x => Convert.ToInt32(x))
                    .Sum();
        }
    }
}
