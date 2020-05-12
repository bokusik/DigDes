using System;
using System.Reflection;
using System.ComponentModel.Design;

namespace TestApp
{
    abstract class Test
    {
        public void Print()
        {
            Console.WriteLine("\nDigDes!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type myType = typeof(TestApp.Test);

            MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            PrintArrayMethodInfo(myArrayMethodInfo);

            Type TypeHandleType = typeof(System.RuntimeTypeHandle);

            MethodInfo myAllocateMethodInfo = TypeHandleType.GetMethod("Allocate", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly);

            Type myAllocateParam = myType.UnderlyingSystemType;

            object[] myAllocateParams = new object[] { myAllocateParam };

            Test exampleTest = myAllocateMethodInfo.Invoke(null, myAllocateParams) as Test;

            exampleTest.Print();
        }

        static void PrintArrayMethodInfo(MethodInfo[] myArrayMethodInfo)
        {
            for (int i = 0; i < myArrayMethodInfo.Length; i++)
                Console.WriteLine("\nThe name of the method is {0}.", myArrayMethodInfo[i].Name);
        }
    }
}
