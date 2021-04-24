using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace todoXamarinForms
{
    public class MainViewModel : BindableObject
    {

        public string CurrentDate { get; set; }  //DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss");


        public MainViewModel()
        {
            this.CurrentDate = DateTime.Now.ToString("ddd dd.MM.yy");
        }
    }
}
