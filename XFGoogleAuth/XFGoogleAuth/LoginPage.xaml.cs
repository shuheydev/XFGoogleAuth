using Plugin.GoogleClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFGoogleAuth
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //ログイン成功した後はAccessTokenに値が入る.
            //それを使って初回のみログインを求めるか,毎回求めるかを選択できる
            //今回は毎回ログインを求めるようにしている
            if (!string.IsNullOrEmpty(CrossGoogleClient.Current.AccessToken))
            {
                //認証済みの場合の処理
                //例えば他のページに遷移するなど.
                //App.Current.MainPage=new MainPage();

                CrossGoogleClient.Current.Logout();
            }

            var loginUser = await CrossGoogleClient.Current.LoginAsync();

            //認証後の処理.
            //例えば,他のページに遷移するなど.
            App.Current.MainPage = new MainPage();
        }
    }
}
