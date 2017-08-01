using System;
using System.Collections.Generic;

namespace DelActionFucDemo
{
    public delegate void PrintMessageDel(string message);
    public delegate T GenericDelegate<T>(T arg);
    public delegate bool IsPromotableDel(Employee employee);

    public class Program
    {
        static void Main(string[] args)
        {

            var del = new PrintMessageDel(PrintMessage);
            del("Hello Delegate");

           
            //generic delegate 
            var genericDelForString = new GenericDelegate<string>(GetMessage);
            Console.WriteLine(genericDelForString("String of Generic Del"));


            var genericDelForInt = new GenericDelegate<int>(GetSquare);
            Console.WriteLine("Square: " + genericDelForInt(5));

            var employees = new List<Employee>
            {
                new Employee { ID = 1, Name = "A", Designation = "Software Engineer", YearOfExperienc = 4},
                new Employee { ID = 2, Name = "B", Designation = "Junoir Software Analyst", YearOfExperienc = 3},
                new Employee { ID = 3, Name = "C", Designation = "Software Analyst", YearOfExperienc = 5},
                new Employee { ID = 4, Name = "D", Designation = "Software Archecict", YearOfExperienc = 6}
            };

            var isPromotable = new IsPromotableDel(IsPromotableMethod);

            var employee = new Employee();
            employee.PromoteEmpoyee(employees, isPromotable);
            //const int input = 5;
            //var action = new Action<int>(ActionIsEven);
            //action(input);
            //action.Invoke(input);

            //var func = new Func<int, int>(FuncSquare);
            //Console.WriteLine(func(input));
            //Console.WriteLine(func.Invoke(input));

            Console.ReadLine();
        }

       
        private static void PrintMessage(string msg)
        {
            Console.WriteLine("Print for deligate : " + msg);
        }
        

        private static string GetMessage(string msg)
        {
            return "From delegate call: " + msg;
        }

        private static int GetSquare(int input)
        {
            return input * input;
        }
        public static bool IsPromotableMethod(Employee employee)
        {
            return employee.YearOfExperienc >= 5;
        }


        private static void ActionIsEven(int input)
        {
            Console.WriteLine("Is Even = " + (input % 2 == 0));
        }

        private static int FuncSquare(int input)
        {
            return input * input;
        }
    }


    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int YearOfExperienc { get; set; }
        public string Designation { get; set; }

        public void PromoteEmpoyee(List<Employee> employees, IsPromotableDel isEligibleToPromote)
        {
            foreach (var employee in employees)
            {
                if (isEligibleToPromote(employee))
                {
                    employee.Designation += " Promoted";
                    Console.WriteLine(employee.Designation);
                }
            }
        }
    }
}
