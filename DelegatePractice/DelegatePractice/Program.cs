using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractice
{
    class Program
    {

        // steps declare a delegate with a return type 


        delegate void onlyString(string someString);

        static void MyName(string name)
        {
            Console.WriteLine($"My Name is {name}");
        }
        static void MyMidName(string midName)
        {
            Console.WriteLine($"My Middle Name is {midName}");
        }
        static void MyLastName(string lastName)
        {
            Console.WriteLine($"My Last Name is {lastName}");
        }



        static bool IsEven(int data)
        {
            return data % 2 == 0;
        }

        static bool IsOdd(int data)
        {
            return data % 2 != 0;
        }


        static void DisplayName(onlyString name, List<string> fullName)
        {
            name(fullName[0]);
        }

        static void CheckEven(MyDelegates.CheckEvenOdd checkMethod, int data)
        {
            Console.WriteLine(checkMethod(data));   
        }


        static void CheckOdd(MyDelegates.CheckEvenOdd checkMethod, int data)
        {
            Console.WriteLine(checkMethod(data));
        }


        static void Main(string[] args)
        {
            List<string> abhi = new List<string>{ "Abhishek", "Anil", "Bhovar" };
            onlyString fullName = MyName;
            fullName += MyMidName;
            fullName += MyLastName;

            DisplayName(fullName, abhi);

            MyDelegates.CheckEvenOdd check = IsEven;
            CheckEven(check, 2);

            check = IsOdd;
            CheckOdd(check, 2);



        }
    }
}
