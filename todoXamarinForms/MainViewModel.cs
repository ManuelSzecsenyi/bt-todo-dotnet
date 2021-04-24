using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using todoXamarinForms.Models;
using Xamarin.Forms;

namespace todoXamarinForms
{
    public class MainViewModel : BindableObject, INotifyPropertyChanged
    {

        public string CurrentDate { get; set; }  
        public ObservableCollection<TodoItem> TodoList { get; set; }


        public MainViewModel()
        {
            this.CurrentDate = DateTime.Now.ToString("ddd dd.MM.yy");

            this.TodoList = new ObservableCollection<TodoItem>();

            this.TodoList.Add(new TodoItem("Sauber machen", false));
        }
    }
}
