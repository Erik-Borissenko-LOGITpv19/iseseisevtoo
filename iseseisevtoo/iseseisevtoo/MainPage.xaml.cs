using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Messaging;

namespace iseseisevtoo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BackgroundColor = Color.LightSkyBlue;
        }

        private void ButtonSend_Clicked(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail($"{EntryRecipients}", $"{EntrySubject}", $"{EntryBody}");
            }
            ButtonSend.Text = "Отправлено!";
        }
    }
}

