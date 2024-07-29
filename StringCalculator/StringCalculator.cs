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

            // two numbers in a string
            var numbersList = numbers.Split(',').ToList();

            var sum = 0;

            // convert string number to int and add
            numbersList.ForEach(x => sum += Convert.ToInt32(x));

            return sum;
        }
    }
}
