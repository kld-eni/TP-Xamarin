using System;
using System.Collections.Generic;
using System.Text;
using Xamarin_Module4.Models;

namespace Xamarin_Module4.Services
{
    interface ITwitterService
    {
        bool Authenticate(string login, string password);

        List<Tweet> GetTweets(string filter);
    }
}
