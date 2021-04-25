using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace todoXamarinForms.Models
{
    public class TodoItem : BindableObject, INotifyPropertyChanged
    {
        private string id;
        private bool done;
        private string text;
        private DateTime createdAt;

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
        }
    }
}
