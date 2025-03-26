using EparchyDBB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EparchyDBB.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _name;
        private int _course;
        private ObservableCollection<Church> _students;
        private Church _selectedStudent;
        private Church _newStudent;

        public string Name
        {
            get => _name;
            set => SetPropertyChanged(ref _name, value, nameof(Name));
        }

        public int Course
        {
            get => _course;
            set => SetPropertyChanged(ref _course, value, nameof(Course));
        }

        public ObservableCollection<Church> Students
        {
            get => _students;
            set => SetPropertyChanged(ref _students, value, nameof(Students));
        }

        public Church SelectedStudent
        {
            get => _selectedStudent;
            set => SetPropertyChanged(ref _selectedStudent, value, nameof(SelectedStudent));
        }

        public Church NewStudent
        {
            get => _newStudent;
            set => SetPropertyChanged(ref _newStudent, value, nameof(NewStudent));
        }
        

        public MainWindowViewModel()
        {
            Students = new ObservableCollection<Church>();
            NewStudent = new Church();
        }

        public void LoadStudent()
        {
            Students.Clear();
            using(var context = new EparchyEntities())
            {
                var temp = context.Churches.ToList();

                foreach (var student in temp)
                {
                    Students.Add(student);
                }
            }
        }

        public void DeleteStudent()
        {
            try
            {
                using (var context = new EparchyEntities())
                {
                    var findEntity = context.Churches.FirstOrDefault(s => s.Id == SelectedStudent.Id);
                    if (findEntity == null)
                        return;
                    var result = context.Churches.Remove(findEntity);
                    context.SaveChanges();

                    LoadStudent();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        public bool AddNewStudent()
        {

                using(var context = new EparchyEntities())
                {
                    var newStudent = context.Churches.Add(NewStudent);
                    context.SaveChanges();
                    return true;
                }
            
        }
    }
}