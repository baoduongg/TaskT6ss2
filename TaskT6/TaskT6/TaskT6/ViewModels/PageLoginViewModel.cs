using Android.Content;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TaskT6.ViewModels
{
   public  class PageLoginViewModel : BindableBase
    {
        private string etremail;
        private string etrpass;
        private string uriimage;
        private DelegateCommand _btnlogincommand;
        private INavigationService _navigationService;  
        IPageDialogService dialogService;
      
        private List<string> _list;
        public List<string> List
        {
            get { return _list; }
            set { SetProperty(ref _list, value); }
        }


      

        public string Etrpass { get => etrpass; set => etrpass = value; }
        public DelegateCommand Btnlogincommand => _btnlogincommand ??            
          (_btnlogincommand = new DelegateCommand(ActionLogin));

        public string Uriimage { get => uriimage; set => uriimage = value; }
        public string EtrEmail { get => etremail; set => etremail = value; }

        private void ActionLogin()
        {
           if(EtrEmail.Length>= 8 && Etrpass.Length>= 8 )
            {
                var naviparams = new NavigationParameters
                {
                    { "Email", EtrEmail },
                    { "Uriimage", Uriimage },
                    {"PassWord", Etrpass }
                };

                UserInfo.Email = EtrEmail;
                UserInfo.Pass = Etrpass;
                _navigationService.NavigateAsync("PageMaster", naviparams, useModalNavigation: true);
             


            }
           else
            {
                dialogService.DisplayAlertAsync("Alert", "You Login Fail", "OK");
            }
        }

        public PageLoginViewModel(IPageDialogService _dialogService, INavigationService navigationService)
        {
            dialogService = _dialogService;
            _navigationService = navigationService;
            Uriimage = "iconlogin2.jpg";
            EtrEmail = "Shanna@melissa.tv";
            Etrpass = "12345678";
           // GetusernameAsync();
        }
        public PageLoginViewModel()
        {
           
        }
     
    }
}
