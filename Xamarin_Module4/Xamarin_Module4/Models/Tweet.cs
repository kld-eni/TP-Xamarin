using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_Module4.Models
{
    class Tweet
    {
        public string Id { get; set; }
        public string CreationDate { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
    }
}