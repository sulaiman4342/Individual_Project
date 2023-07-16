
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;


namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Users> users;
        [ObservableProperty]
        public Users selectedUser = null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4!", "Error!");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserViewModel();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted Successfuly!", "DELETED! \a ");
            }
            else
            {
                MessageBox.Show("Please Select User!", "Error!");
            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserViewModel(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);

                window.ShowDialog();

                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);

            }

            else
            {
                MessageBox.Show("Please Select the User!", "Error!");
            }
        }

        public MainWindowVM()
        {
            users = new ObservableCollection<Users>();
            BitmapImage image1 = new BitmapImage(new Uri("/Image/1.png", UriKind.Relative));
            users.Add(new Users(23, "Joe", "silver", "12/1/2000", 3.5, image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Image/2.png", UriKind.Relative));
            users.Add(new Users(24, "Jhon", "Amber", "12/1/2000", 2.8, image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Image/3.png", UriKind.Relative));
            users.Add(new Users(24, "Nick", "Heisenberg", "12/1/2000", 3.0, image3));
            BitmapImage image4 = new BitmapImage(new Uri("/Image/4.png", UriKind.Relative));
            users.Add(new Users(21, "Nataliya", "Dias", "12/1/2000", 3.7, image4));

        }
    }
}
