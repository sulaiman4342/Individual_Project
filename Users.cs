using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GUI
{
    public class Users
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BitmapImage Image { get; set; }

        public string DateOfBirth { get; set; }
        public Double GPA { get; set; }

        public String ImagePath
        {
            get { return $"/Image/{Image}"; }
        }

        public Users(int age, string firstName, string lastName, string dateOfBirth, double gpa, BitmapImage image)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Image = image;
            GPA = gpa;
        }

        public Users()
        {
        }
    }
}
