using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TaskT6.ViewModels
{
    public class PageUserViewModel : BindableBase
    {
     
        private string _username;
        private string _uriavatar;
     
      
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public string Uriimage
        {
            get { return _uriavatar; }
            set { SetProperty(ref _uriavatar, value); }
        }

      
      
      
        INavigationService _navigationservice;
    
       

        public PageUserViewModel(INavigationService navigationservice)
        {
            _navigationservice = navigationservice;

            GetUserApiAsync();

        }
        
      
        public async void GetUserApiAsync()
        {
            
            var apiResponse = RestService.For<IGetDataApi>("https://jsonplaceholder.typicode.com");
            var apiuser = await apiResponse.GetUserEmail(UserInfo.Email);
            var usertemp = apiuser[0].Username;
            var id = apiuser[0].Id;
            Username = usertemp;
            UserInfo.Userid = "" + id;
            UserInfo.Name = Username;
            Email = UserInfo.Email;
            Username = UserInfo.Name;
            Uriimage = "iconlogin.jpg";


        }
        
    }
}
