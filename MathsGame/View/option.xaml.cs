using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MathsGame.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class option : Page
    {
        public option()
        {
            this.InitializeComponent();
        }

        private void chkMode1_checked(object sender, RoutedEventArgs e)
        {
            chkMode1.IsChecked = false;
            SimpleMaths.Maths.SaveSettings("mode", "0");
        }

        private void chkMode2_checked(object sender, RoutedEventArgs e)
        {
            chkMode2.IsChecked = false;
            SimpleMaths.Maths.SaveSettings("mode", "1");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += option_BackRequested;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= option_BackRequested;
            if (SimpleMaths.Maths.mode == 0)
            {
                chkMode1.IsChecked = true;
                chkMode2.IsChecked = false;
            }
            else
            {
                chkMode1.IsChecked = false;
                chkMode2.IsChecked = true;
            }

            int sliderValue = SimpleMaths.Maths.speed;
            slider.Value = sliderValue / 10;
        }

        private void option_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
            {
                // navigates to the most recent frame in the history
                Frame.GoBack();
            }
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SimpleMaths.Maths.speed = int.Parse(slider.Value.ToString()) * 10;
            SimpleMaths.Maths.SaveSettings("speed", SimpleMaths.Maths.speed.ToString());
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
