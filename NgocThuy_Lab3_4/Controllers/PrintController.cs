using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgocThuy_Lab3_4.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PrintPrimeNumber()
        {
            ViewData["message1"] = "In ra các số nguyên tố từ 1 - 100";

            List<int> primeNumbers = new List<int>();

            
            bool IsPrime(int number)
            {
                if (number < 2) return false;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            
            for (int i = 1; i <= 100; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }

           
            string[] primeNumberArray = primeNumbers.Select(p => p.ToString()).ToArray();

            
            ViewData["prinumber"] = primeNumberArray;

            return View();
        }

        public ActionResult PrintFactorial()
        {
            ViewData["message1"] = "In ra giai thừa từ 1-10";

            List<int> factorials = new List<int>();

         
            int CalculateFactorial(int number)
            {
                int result = 1;
                for (int i = 1; i <= number; i++)
                {
                    result *= i;
                }
                return result;
            }

           
            for (int i = 1; i <= 10; i++)
            {
                factorials.Add(CalculateFactorial(i));
            }

            ViewData["factorials"] = factorials; 

            return View();
        }


        public ActionResult MultiplicationTable()
        {
            ViewData["message1"] = "Bảng cửu chương từ 2 đến 9";

            
            Dictionary<int, List<string>> multiplicationTable = new Dictionary<int, List<string>>();

            for (int i = 2; i <= 9; i++)
            {
                List<string> table = new List<string>();
                for (int j = 1; j <= 10; j++)
                {
                    table.Add($"{i} x {j} = {i * j}");
                }
                multiplicationTable[i] = table;
            }

            ViewData["multiplicationTable"] = multiplicationTable;

            return View();
        }



    }
}