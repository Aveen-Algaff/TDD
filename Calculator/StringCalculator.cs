using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator
    {
        private char[] delimiters = new[] { ',', '\n' };
        List<int> _numbersList = new List<int>();
        //private string input = @"[^0-9]$";

        public int AddNum(string numbers)
        {

            var sum = 0;
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else if (!string.IsNullOrEmpty(numbers))
            {

                var test2 = numbers.Contains("-");
                if (test2)
                {
                    //List<int> r = new List<int> { Convert.ToInt32(numbers) };
                    //if (r.Count > 0)
                    //{
                    throw new ArgumentException("Negatives not allowed ");
                    //}
                }
                //var test = numbers.Split(delimiters).ToList();

                var output = numbers.ToCharArray().Where(c => char.IsDigit(c)).Select(c =>
                {
                    return int.Parse(c.ToString());
                }).ToArray();

                //if (test.Count > 0)
                //{
                //    throw new ArgumentException("Negatives not allowed ");
                //}

                for (int i = 0; i < output.Length; i++)
                {

                    _numbersList.Add(output[i]);
                }
                sum = _numbersList.Sum(x => x);
            }
            return sum;
        }

    }
}
