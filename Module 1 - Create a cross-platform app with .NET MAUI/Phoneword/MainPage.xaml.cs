﻿namespace Phoneword;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    string? translatedNumber;

    private void OnTranslate(object sender, EventArgs e)
    {
        string enteredNumber = PhoneNumberText.Text;
        translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

        if (!string.IsNullOrEmpty(translatedNumber))
        {
            CallButton.IsEnabled = true;
            CallButton.Text = "Call " + translatedNumber;
        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";
        }
    }

    async void OnCall(object sender, EventArgs e)
    {
        if (await this.DisplayAlert("Dial a number", $"Would you like to call {translatedNumber}?", "Yes", "No"))
        {
            // TODO: dial the phone
        }
    }
}