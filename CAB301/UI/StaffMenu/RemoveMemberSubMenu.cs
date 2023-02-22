using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public class RemoveMemberSubMenu : StaffSubMenuBase
    {
        public override void DoWork()
        {
            Console.Write("Enter member's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter member's last name: ");
            string lastName = Console.ReadLine();
            IMember member = new Member(firstName, lastName);
            bool onLoan = false;
            var movieCollection = MovieService.GetMovieCollection();
            if (movieCollection.Number > 0)
            {
                var movies = movieCollection.ToArray();
                for (int i = 0; i < movies.Length; i++)
                {
                    if (movies[i].Borrowers.Search(member))
                    {
                        onLoan = true;
                        break;
                    }
                }
            }
            if (onLoan)
            {
                Console.WriteLine("Member has movie DVD on loan! Member removal failed!");
            }
            else
            {
                IMemberCollection members = MemberService.GetMemberCollection();
                members.Delete(member);
            }
            Console.WriteLine();
            Console.WriteLine("Back to the staff menu!");
            Console.WriteLine();
        }
    }
}
