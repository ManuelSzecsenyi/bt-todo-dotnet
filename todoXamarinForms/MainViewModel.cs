using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using todoXamarinForms.Models;
using Xamarin.Forms;

namespace todoXamarinForms
{
    public class MainViewModel : BindableObject, INotifyPropertyChanged
    {

        public string CurrentDate { get; set; }
        public string Entry { get => entry; set
            {
                entry = value;
                OnPropertyChanged(nameof(Entry));
            } 
        }
        private string entry;
        public ObservableCollection<TodoItem> TodoList { get; set; }

        private ICommand tapCommand;

        public ICommand TapCommand
        {
            get { return tapCommand; }
            set { tapCommand = value; }
        }



        public MainViewModel()
        {
            this.CurrentDate = DateTime.Now.ToString("ddd dd.MM.yy");
            this.TapCommand = new Command(onButtonClicked);

            this.TodoList = new ObservableCollection<TodoItem>();

            this.TodoList.Add(new TodoItem("Sauber machen", false));
            this.TodoList.Add(new TodoItem("Sauber Nummer zwei", false));
        }

        public void onButtonClicked()
        {
            string todoText = this.Entry;
            if(todoText == "") { return; }
            this.TodoList.Add(new TodoItem(
                todoText,
                false
            ));

            this.Entry = "";
        }
    }
}
