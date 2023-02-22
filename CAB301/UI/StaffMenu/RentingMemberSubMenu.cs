using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public class RentingMemberSubMenu : StaffSubMenuBase
    {
        public override void DoWork()
        {
            Console.Write("Enter DVD's movie name: ");
            string title = Console.ReadLine();

            var movies = MovieService.GetMovieCollection();
            var movie = movies.Search(title);
            Console.WriteLine();
            if (movie == null)
            {
                Console.WriteLine("DVD's movie not found! ");
                Console.WriteLine("Back to Staff Menu!");
                Console.WriteLine();
                return;
            }
            else
            {
                if (movie.Borrowers.IsEmpty())
                {
                    Console.WriteLine("No members borrow this movie!");
                }
                else
                {
                    Console.WriteLine(movie.Borrowers.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
