using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace todoXamarinForms.Models
{
    public class TodoItem
    {
        public string Text { get; set; }
        public bool Done { get; set; }

        public TodoItem(string text, bool done)
        {
            this.Text = text;
            this.Done = done;
        }

    }
}
