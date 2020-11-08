using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace theRealLab10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> myListOfMovies = new List<Movie>();
            var iceAge = new Movie("Ice Age", "Animated");
            var spidy = new Movie("Spider-Man into the Spider-Verse", "Animated");
            var sloane = new Movie("Miss Sloane", "Drama");
            var saw = new Movie("Saw", "Horror");
            var star = new Movie("Star Wars", "Sci-Fi");
            var escape = new Movie("Escape", "Horror");
            var dun = new Movie("Dunkirk", "Drama");
            var toy = new Movie("Toy Story", "Animated");
            var stick = new Movie("Stick It", "Drama");
            var cred = new Movie("The Incredibles", "Animated");

            myListOfMovies.Add(iceAge);
            myListOfMovies.Add(spidy);
            myListOfMovies.Add(sloane);
            myListOfMovies.Add(saw);
            myListOfMovies.Add(star);
            myListOfMovies.Add(escape);
            myListOfMovies.Add(dun);
            myListOfMovies.Add(toy);
            myListOfMovies.Add(stick);
            myListOfMovies.Add(cred);

            var categories = new Dictionary<string, string>();
            categories.Add("1", "Animated");
            categories.Add("2", "Drama");
            categories.Add("3", "Horror");
            categories.Add("4", "Sci-Fi");


            Console.WriteLine("Welcome to the Movie List Generator!");
            bool keepGoing = true;

            try
            {

                do
                {
                    if (CheckCategoryEntry(categories, myListOfMovies))
                    {
                        keepGoing = MoreLists();
                    }
                    else
                    {
                        Console.WriteLine("Please provide valid inputs for the category");
                    }

                } while (keepGoing);
            }
            catch (InvalidOperationException ex) //because my sort method wasn't working - due to not being able to sort on Movie "type"
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            
        }


        static bool CheckCategoryEntry(Dictionary<string, string> categories, List<Movie> theMovies)
        {
            Console.WriteLine();
            Console.WriteLine("What category of movies would you like to see from our list? Select a number or category name below: \n" +
                   "1. Animated\n2. Drama\n3. Horror\n4. Sci-fi ");
            Console.WriteLine();
            string userChoice = Console.ReadLine();
            Console.WriteLine();

            //realized I didn't need the below....
            //var keys = categories.Keys;
            //var values = categories.Values;

            if(categories.ContainsKey(userChoice) || categories.ContainsValue(userChoice))
            {
                if (categories.ContainsKey(userChoice))
                {
                    categories.TryGetValue(userChoice, out string userCat);

                    DisplayByCategory(userCat, theMovies);
                    return true;
                }
                else
                {
                    DisplayByCategory(userChoice, theMovies);
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        static void DisplayByCategory(string userChoice, List<Movie> movies)
        {
            List<string> toDisplay = new List<string>();

            foreach (Movie movie in movies)
            {
                if (userChoice == movie.Category)
                {
                    string movieToDisplay = movie.Title.ToString();
                    toDisplay.Add(movieToDisplay);
                }
            }

            toDisplay.Sort();

            foreach (string movie in toDisplay)
            {
                Console.WriteLine($"{movie}");
            }


        }


        static bool MoreLists()
        {
            Console.WriteLine("\nWould you like to make another Movie List?");

            do
            {
                string userChoice = Console.ReadLine();

                if (userChoice.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("GOODBYE!");
                    return false;
                }
                else if (userChoice.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("that's not a valid input. please enter y or n");
                }

            } while (true);
        }
    }
}
