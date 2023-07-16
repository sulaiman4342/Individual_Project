using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Microsoft.Win32;

namespace GUI
{
    public partial class AddUserViewModel : ObservableObject

    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;

        public AddUserViewModel(Users u)
        {
            Student = u;

            firstname = Student.FirstName;
            lastname = Student.LastName;
            age = Student.Age;
            gpa = Student.GPA;
            dateofbirth = Student.DateOfBirth;
            selectedImage = Student.Image;

        }

        public AddUserViewModel()
        {

        }

        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Image Successfuly Uploded!", "Done!");
            }
        }

        public Users Student { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {

            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4!", "Error!");
                return;
            }
            if (Student == null)
            {

                Student = new Users()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    DateOfBirth = dateofbirth,
                    Image = selectedImage,
                    GPA = gpa
                };
            }

            else
            {
                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.Age = age;
                Student.GPA = gpa;
                Student.Image = selectedImage;
                Student.DateOfBirth = dateofbirth;
            }

            if (Student.FirstName != null)
            {
                CloseAction();
            }
            Application.Current.MainWindow.Show();
        }
    }
}
