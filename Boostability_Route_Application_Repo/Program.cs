//Written and Tested by Anthony R. Martinez
//Started 3/30/2022
//First Commited to GitHub 3/31/2022
//This is an application that takes a list of routes and prints out the paths the application without any duplicats, throwing an error when there is a circular reference
using System;
using System.Collections.Generic;
using System.Linq;


namespace Boostability_Route_Application_Repo
{
    class Program
    {
        //simple argument that will simply allow us to call the array and the print the original route list
        static void DisplayArray(string[] arr)
        {
            Console.WriteLine("Original List of Routes:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        //Main code that will takin in the array and either give out successfull route list or runn error becuase of circular reference
        static void createRoutes(string[] arrRoute)
        {
            Console.WriteLine("Final List of Routes:");
            List<string> originalList = new List<string>(arrRoute);
            List<string> finalList = new List<string>();

            for (int i = 0; i < originalList.Count; i++)
            {
                if (originalList[i] == originalList.Last())
                {
                    finalList.Add(originalList[i]);
                }
                else
                {
                    string listString = string.Join(",", originalList[i]);
                    string listString2 = string.Join(",", originalList[i + 1]);
                    List<string> tempList = new List<string>();
                    List<string> tempList2 = new List<string>();
                    string[] splittedStringArray = listString.Split(" -> ");
                    foreach (string stringInArray in splittedStringArray)
                    {
                        tempList.Add(stringInArray);
                    }
                    string[] splittedStringArray2 = listString2.Split(" -> ");
                    foreach (string stringInArray1 in splittedStringArray2)
                    {
                        tempList2.Add(stringInArray1);
                    }

                    if (tempList.First() == tempList2.Last())
                    {
                        Console.WriteLine("exception Thrown " + listString + " is the same route as " + listString2);
                        originalList.Remove(originalList[i + 1]);
                    }

                    else if (tempList.Last() == tempList2.First())
                    {
                        tempList2.RemoveAt(0);
                        tempList.AddRange(tempList2);
                        string finalString = string.Join(" -> ", tempList);
                        finalList.Add(finalString);
                        tempList.Clear();
                        tempList2.Clear();
                        Array.Clear(splittedStringArray, 0, splittedStringArray.Length);
                        Array.Clear(splittedStringArray2, 0, splittedStringArray2.Length);
                        originalList.Remove(originalList[i + 1]);
                    }
                    else
                    {
                        finalList.Add(listString);
                    }
                }
            }

            foreach (var month in finalList)
            {
                Console.WriteLine(month);
            }
        }



        static void Main(string[] args)
        {
            //simply create two array's that will give us the two possible scenario's that are listed in the pdf file. Allow's us test before unit tests.
            string[] listOfRoutes = {
                 "/about-us.html -> /about",
                 "/about -> /about-us.html"
            };

            string[] listOfRoutes2 = {
                 "/home",
                "/our-ceo.html -> /about-us.html",
                "/about-us.html -> /about",
                "/product-1.html -> /seo"
            };

            DisplayArray(listOfRoutes);
            DisplayArray(listOfRoutes2);
            createRoutes(listOfRoutes);
            createRoutes(listOfRoutes2);
        }
    }
}
