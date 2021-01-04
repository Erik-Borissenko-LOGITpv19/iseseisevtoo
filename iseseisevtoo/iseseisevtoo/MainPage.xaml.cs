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
        Random rnd;
        Button rndbutton;
        public MainPage()
        {
            InitializeComponent();
            BackgroundColor = Color.LightSkyBlue;
            //Кнопка Рандома
            rndbutton = new Button { Text = "Разукрась или верни" };
            rndbutton.Clicked += Rndbutton_Clicked;
            //Time----------------------------------------------
            time1 = new TimePicker
            {
                Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };
            time1.PropertyChanged += Time_PropertyChanged;
            //Picker--------------------------------------------
            pick = new Picker();
            pick.Items.Add("tytpo4ta@mail.ru");
            pick.Items.Add("tytpo4tadryga@mail.ru");
            pick.Items.Add("tytpo4tapodrygi@mail.ru");
            pick.Items.Add("tytpo4taznakomogo@mail.ru");
            pick.Items.Add("tytpo4taznakomoi@mail.ru");
        }
        //Random
        private void Rndbutton_Clicked(object sender, EventArgs e)
        {
            rnd = new Random();
            int r = rnd.Next(0, 4);
        }

        private void ButtonSend_Clicked(object sender, EventArgs e)
        {
            //Email---------------------------------------------
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail($"{pick}", $"{EntrySubject}", $"{EntryRecipients}");
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
        //Рандомно сгенерированое число--------------------------
        private void randombutton_Clicked(object sender, EventArgs e)
        {
                
        }
    }
}