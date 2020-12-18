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
        Label lbl;
        Picker pick;
        TimePicker time1;
        public MainPage()
        {
            InitializeComponent();
            BackgroundColor = Color.LightSkyBlue;
            //Time----------------------------------------------
            time1 = new TimePicker
            {
                Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };
            time1.PropertyChanged += Time_PropertyChanged;
            //Picker--------------------------------------------
            pick.Title = "Выбери поздравления другу!";
            pick.Items.Add("C Новым годом");
            pick.Items.Add("С НГ");
            pick.Items.Add("Ну братан... С новым годом!");
            pick.Items.Add("А тут у нас НГ");
            pick.Items.Add("Ну подруга... С новым годом!");
        }

        private void ButtonSend_Clicked(object sender, EventArgs e)
        {
            //Email---------------------------------------------
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail($"{EntryRecipients}", $"{EntrySubject}", $"{pick}");
            }
            ButtonSend.Text = "Отправлено!";
        }
            //Time Method---------------------------------------
        private void Time_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                var time = time1.Time.Hours;
                if (time == 0)
                {
                    lbl.Text = "С НОВЫМ ГОДОМ!!!";
                    lbl.TextColor = Color.Black;
                }
            }
        }
    }
}