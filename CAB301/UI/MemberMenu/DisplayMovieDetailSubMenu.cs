using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public class DisplayMovieDetailSubMenu : MemberSubMenuBase
    {
        public override void DoWork()
        {
            Console.Write("Enter DVD's movie name: ");
            string title = Console.ReadLine();

            IMovieCollection movies = MovieService.GetMovieCollection();
            IMovie existedMovie = movies.Search(title);
            Console.WriteLine();
            if (existedMovie != null)
            {
                Console.WriteLine(existedMovie.ToString());
                var borrowers = existedMovie.Borrowers;
                if (borrowers.IsEmpty())
                    Console.WriteLine("There are no borrowers currently!");
                else
                {
                    Console.WriteLine("There are {0} borrowers currently!", borrowers.Number);
                    Console.WriteLine(borrowers.ToString());
                }
            }
            else
            {
                Console.WriteLine("Movie not found!");
            }
            Console.WriteLine();
            Console.WriteLine("Back to the member menu!");
            Console.WriteLine();
        }
    }
}
