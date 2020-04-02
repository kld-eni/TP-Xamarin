using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin_Module4.Models
{
    class Tweet
    {
        public string Id { get; set; }
        public string CreationDate { get; set; }
        public string TweetText { get; set; }
        public ImageSource TweetPicture { get; } = ImageSource.FromUri(new Uri("https://picsum.photos/50/50/?random"));
        public User Author { get; set; }
    }
}