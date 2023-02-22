using CAB301.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public class PhoneNumberSubMenu : StaffSubMenuBase
    {
        public override void DoWork()
        {
            Console.Write("Enter member's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter member's last name: ");
            string lastName = Console.ReadLine();
            
            IMemberCollection members = MemberService.GetMemberCollection();
            IMember member = ((MemberCollection)members).Find(new Member(firstName, lastName));
            Console.WriteLine("Member's phone number is: {0}", member.ContactNumber);
            Console.WriteLine();
            Console.WriteLine("Back to the staff menu!");
            Console.WriteLine();
        }
    }
}
