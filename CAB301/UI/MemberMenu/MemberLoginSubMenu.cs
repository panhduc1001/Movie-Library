using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.MemberMenu
{
    public class MemberLoginSubMenu : BaseMenu
    {
        public override void DoWork()
        {
            bool valid = false;
            while (!valid)
            {
                Console.Write("Member first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Member last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Member Password: ");
                string password = Console.ReadLine();
                MemberCollection members = (MemberCollection)MemberService.GetMemberCollection();
                IMember member = members.Find(new Member(firstName, lastName));

                if (member != null && password.Equals(member.Pin))
                {
                    valid = true;
                    MemberService.SetCurrentMember(member);
                }
                else
                {
                    Console.WriteLine("Wrong username/password!");
                    Console.WriteLine();
                }
            }
        }
        public override IMenu GetNextMenu()
        {
            return MenuHelper.GetNextMenu("Member Login", clearScreen: true);
        }
    }
}
