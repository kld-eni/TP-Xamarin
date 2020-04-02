using System;
using System.Collections.Generic;
using System.Text;
using Xamarin_Module4.Models;

namespace Xamarin_Module4.Services
{
    class TwitterService : ITwitterService
    {
        private static readonly User u1 = new User { Login = "login", Name = "Kévin Le Devéhat", Alias = "Bortnak", Password = "password" };

        public bool Authenticate(string login, string password)
        {

            return login == u1.Login && password == u1.Password; 
        }

        public List<Tweet> GetTweets(string filter = null)
        {
            return new List<Tweet>
            {
                new Tweet {Author = u1, CreationDate = "30/03/2020", Id = "1", TweetText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." },
                new Tweet {Author = u1, CreationDate = "01/04/2020", Id = "2", TweetText = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."}
            };
        }
    }
}
