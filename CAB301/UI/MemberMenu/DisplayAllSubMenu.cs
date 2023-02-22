using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public class DisplayAllSubMenu : MemberSubMenuBase
    {
        public override void DoWork()
        {
            var movieCollection = MovieService.GetMovieCollection();
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine("The movie DVDs currently is empty!");
            }
            else
            {
                
                var movies = movieCollection.ToArray();
                Console.WriteLine("Currently there are {0} movie DVDs in the list!", movies.Length);
                for (int i = 0; i < movies.Length; i++)
                    Console.WriteLine(movies[i].ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Back to the member menu!");
            Console.WriteLine();
        }
    }
}
