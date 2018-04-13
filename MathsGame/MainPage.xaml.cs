using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MathsGame.View;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MathsGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            var mode = SimpleMaths.Maths.LoadSettings("mode").ToString();

            txtHighscore.Text = "High Score: " + SimpleMaths.Maths.LoadSettings("highscore").ToString();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= MainPage_BackRequested;
        }

        private async void MainPage_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            e.Handled = true;
            var msg = new MessageDialog("Are you handsome?");
            var okBtn = new UICommand("Yes");
            var kindaBtn = new UICommand("Kinda");
            msg.Commands.Add(okBtn);
            msg.Commands.Add(kindaBtn);
            IUICommand result = await msg.ShowAsync();

            if (result != null && result.Label.Equals("Yes"))
            {
                Application.Current.Exit();
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(View.Advanced));// for testing 
            //Frame.Navigate(typeof(PlaySingle));// for testing 

            if (SimpleMaths.Maths.mode == 0)// depending on which mode is selected the user will be directed to the appropriate playing page
                Frame.Navigate(typeof(View.PlaySingle));
            else
                Frame.Navigate(typeof(View.Advanced));
               
        }

        private void btnOption_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(option));// brings the player to the options page
        }
    }
}
