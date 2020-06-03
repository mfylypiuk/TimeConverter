using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeConverter.Enums;

namespace TimeConverter.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ConverterPage : ContentPage
    {
        private TimeType from;
        private TimeType to;

        public ConverterPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public ConverterPage(TimeType from, TimeType to) 
            : this()
        {
            this.from = from;
            this.to = to;

            FromType.Text = from.ToString();
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void NumberOfTimesEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                decimal input = decimal.Parse(e.NewTextValue);
                decimal result = 0;

                // convert any unit to seconds
                switch (from)
                {
                    case TimeType.Nanosecond:
                        input *= 0.000000001M;
                        break;
                    case TimeType.Microsecond:
                        input *= 0.000001M;
                        break;
                    case TimeType.Second:
                        input *= 1M;
                        break;
                    case TimeType.Minute:
                        input *= 60.0M;
                        break;
                    case TimeType.Hour:
                        input *= 60.0M * 60.0M;
                        break;
                    case TimeType.Day:
                        input *= 60.0M * 60.0M * 24.0M;
                        break;
                    case TimeType.Week:
                        input *= 60.0M * 60.0M * 24.0M * 7.0M;
                        break;
                    case TimeType.Year:
                        input *= 60.0M * 60.0M * 24.0M * 365.2425M;
                        break;
                    default:
                        break;
                }

                switch (to)
                {
                    case TimeType.Nanosecond:
                        result = input * 1000000000.0M;
                        break;
                    case TimeType.Microsecond:
                        result = input * 1000000.0M;
                        break;
                    case TimeType.Second:
                        result = input;
                        break;
                    case TimeType.Minute:
                        result = input / 60.0M;
                        break;
                    case TimeType.Hour:
                        result = input / 60.0M / 60.0M;
                        break;
                    case TimeType.Day:
                        result = input / 60.0M / 60.0M / 24.0M;
                        break;
                    case TimeType.Week:
                        result = input / 60.0M / 60.0M / 24.0M / 7.0M;
                        break;
                    case TimeType.Year:
                        result = input / 60.0M / 60.0M / 24.0M / 365.2425M;
                        break;
                }

                Result.Text = ValueFormat(result) + " " + to.ToString() + "(s)";
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
                return;
            }
        }

        public string ValueFormat(decimal value)
        {
            try
            {
                if (value == (long)value)
                {
                    return string.Format("{0}", (long)value);
                }
                else
                {
                    return string.Format("{0}", value);
                }
            }
            catch (Exception)
            {
                return value.ToString();
            }
        }
    }
}