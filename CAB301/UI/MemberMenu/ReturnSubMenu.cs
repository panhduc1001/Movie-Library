using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public class ReturnSubMenu : MemberSubMenuBase
    {
        public override void DoWork()
        {
            Console.Write("Enter DVD's movie name that you want to return: ");
            string title = Console.ReadLine();

            IMovieCollection movies = MovieService.GetMovieCollection();
            IMovie existedMovie = movies.Search(title);
            Console.WriteLine();
            if (existedMovie != null)
            {
                var currentMember = MemberService.GetCurrentMember();
                if (existedMovie.RemoveBorrower(currentMember))
                    Console.WriteLine("DVD movie returned successfully!");
                else
                    Console.WriteLine("Returning failed!");
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
