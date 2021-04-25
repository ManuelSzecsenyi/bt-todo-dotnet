using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using todoXamarinForms.Models;
using Xamarin.Forms;

namespace todoXamarinForms
{
    public class MainViewModel : BindableObject, INotifyPropertyChanged
    {
        private string URL = "https://radiant-spire-08360.herokuapp.com/";
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

        private TodoItem selectedTodoItem;

        public TodoItem SelectedTodoItem
        {
            get { return selectedTodoItem; }
            set { 
                
                if(selectedTodoItem != value)
                {
                    selectedTodoItem = value;
                    OnPropertyChanged(nameof(SelectedTodoItem));
                    updateTodo(selectedTodoItem);
                }
            }
        }

        

        public MainViewModel()
        {
            this.CurrentDate = DateTime.Now.ToString("ddd dd.MM.yy");
            this.TapCommand = new Command(OnButtonClicked);

            this.TodoList = new ObservableCollection<TodoItem>();
            this.GetItems();
        }

        public void OnButtonClicked()
        {
            string todoText = this.Entry;
            if(todoText == "") { return; }

            TodoItem newItem = new TodoItem(todoText, false, Guid.NewGuid().ToString(), DateTime.Now);
            this.TodoList.Add(newItem);
            this.PutItem(newItem);
            this.Entry = "";
        }

        private async void GetItems()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(this.URL);
            string content = await result.Content.ReadAsStringAsync();

            List<TodoItem> todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(content);

            foreach(TodoItem item in todoItems){
                this.TodoList.Add(item);
            }
        }

        private async void PutItem(TodoItem item)
        {
            string serializedItem = JsonConvert.SerializeObject(item);

            HttpClient client = new HttpClient();
            var result = await client.PostAsync(this.URL, new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            string content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);

        }

        private void updateTodo(TodoItem selectedTodoItem)
        {
            Console.WriteLine(selectedTodoItem);
        }
    }
}
