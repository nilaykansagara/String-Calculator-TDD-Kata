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

            // convert all numbers to int and sum up them
            return numbers.Split(',')
                    .Select(x => Convert.ToInt32(x))
                    .Sum();
        }
    }
}
