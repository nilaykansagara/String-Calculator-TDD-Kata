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

            // convert string number to int
            return Convert.ToInt32(numbers);
        }
    }
}
