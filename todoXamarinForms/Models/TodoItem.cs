using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace todoXamarinForms.Models
{
    public class TodoItem : BindableObject, INotifyPropertyChanged
    {
        private string id;
        private bool done;
        private string text;
        private DateTime createdAt;
        private ICommand tapCommand;

        public ICommand TapCommand
        {
            get { return tapCommand; }
            set { tapCommand = value; }
        }

        public string Text
        {
            get => text; set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public bool Done
        {
            get => done; set
            {
                done = value;
                OnPropertyChanged(nameof(Done));
            }
        }

        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; OnPropertyChanged(nameof(CreatedAt)); }
        }

        public TodoItem(string text, bool done, string id, DateTime createdAt)
        {
            Text = text;
            Done = done;
            Id = id;
            CreatedAt = createdAt;
            this.TapCommand = new Command(ToggleDone);
        }

        public async void ToggleDone()
        {
            this.Done = !this.Done;

            // TODO put this into a service
            string serializedItem = JsonConvert.SerializeObject(this);

            HttpClient client = new HttpClient();
            var result = await client.PutAsync("https://radiant-spire-08360.herokuapp.com/", new StringContent(serializedItem, Encoding.UTF8));

            string content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}
