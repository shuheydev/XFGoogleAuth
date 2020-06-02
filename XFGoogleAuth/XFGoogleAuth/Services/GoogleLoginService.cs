using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XFGoogleAuth.Services;

[assembly: Xamarin.Forms.Dependency(typeof(GoogleLoginService))]
namespace XFGoogleAuth.Services
{
    public class GoogleLoginService
    {
        IGoogleClientManager _googleService = CrossGoogleClient.Current;

        public GoogleLoginService()
        {
            _googleService.OnLogin += (s, e) =>
            {
                switch (e.Status)
                {
                    case GoogleActionStatus.Completed:
#if DEBUG
                        var googleUserString = JsonSerializer.Serialize(e.Data);
                        Debug.WriteLine($"Google Logged in succesfully: {googleUserString}");
#endif
                        break;
                }
            };
        }

        public async Task LoginAsync()
        {
            if (!string.IsNullOrEmpty(_googleService.AccessToken))
            {
                _googleService.Logout();
            }
            var loginUser = await _googleService.LoginAsync();



            //            try
            //            {
            //                if (!string.IsNullOrEmpty(_googleService.AccessToken))
            //                {
            //                    //常にユーザー認証を必要とする
            //                    _googleService.Logout();
            //                }

            //                EventHandler<GoogleClientResultEventArgs<GoogleUser>> userLoginDelegate = null;
            //                userLoginDelegate = async (object sender, GoogleClientResultEventArgs<GoogleUser> e) =>
            //                      {
            //                          switch (e.Status)
            //                          {
            //                              case GoogleActionStatus.Completed:
            //#if DEBUG
            //                                  var googleUserString = JsonSerializer.Serialize(e.Data);
            //                                  Debug.WriteLine($"Google Logged in succesfully: {googleUserString}");
            //#endif
            //                                  var socialLoginData=new NetworkAuthData
            //                          }
            //                      };
            //            }
            //            catch
            //            {

            //            }
        }
    }
}
