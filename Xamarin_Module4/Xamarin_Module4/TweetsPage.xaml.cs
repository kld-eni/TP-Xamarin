using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Module4.Services;

namespace Xamarin_Module4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetsPage : ContentPage
    {
        private readonly ITwitterService twitterService = new TwitterService();

        public TweetsPage()
        {
            InitializeComponent();
            TweetsList.ItemsSource = twitterService.GetTweets();
        }
    }
}