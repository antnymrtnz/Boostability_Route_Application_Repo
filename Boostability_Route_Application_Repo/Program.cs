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
            Console.WriteLine("");
        }
    }
}
