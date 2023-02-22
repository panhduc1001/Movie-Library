using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI.StaffMenu
{
    public class StaffLoginSubMenu : BaseMenu
    {
        private readonly string _staffUserName = "staff";
        private readonly string _password = "today123";

        public override void DoWork()
        {
            bool valid = false;
            while (!valid)
            {
                Console.Write("Staff Username: ");
                string user = Console.ReadLine();
                Console.Write("Staff Password: ");
                string password = Console.ReadLine();
                if (user.Equals(_staffUserName) && password.Equals(_password))
                    valid = true;
                else
                {
                    Console.WriteLine("Wrong username/password!");
                    Console.WriteLine();
                }
            }
        }

        public override IMenu GetNextMenu()
        {
            return MenuHelper.GetNextMenu("Staff Login", clearScreen : true);
        }
    }
}
