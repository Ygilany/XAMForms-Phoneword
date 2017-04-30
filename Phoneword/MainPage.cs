using System;

using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;

        string translatedNumber;

        public MainPage()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.Padding = new Thickness(20, 40, 20, 20);
                    break;
                case Device.Android:
                    this.Padding = new Thickness(20, 20);
                    break;
                default:
                    this.Padding = new Thickness(20, 20);
                    break;
            }

            phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN"
            };

            translateButton = new Button
            {
                Text = "Translate"
            };
            translateButton.Clicked += OnTranslate;

            callButton = new Button
            {
                Text = "Call",
                IsEnabled = false
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Enter a phoneword: "
                    },
                    phoneNumberText,
                    translateButton,
                    callButton

                }
            };
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneNumberText.Text;
            translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);
            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callButton.Text = "Call " + translatedNumber;
                callButton.IsEnabled = true;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
    }
}


