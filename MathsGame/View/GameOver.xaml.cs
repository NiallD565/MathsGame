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
    public sealed partial class GameOver : Page
    {
        private String highScore, TempHighScore;
        public GameOver()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += GameOver_BackRequested;
            highScore = e.Parameter.ToString();
            TempHighScore = SimpleMaths.Maths.LoadSettings("highscore");
            if (int.Parse(highScore) > int.Parse(TempHighScore))
            {
                SimpleMaths.Maths.SaveSettings("highscore", highScore);
            }

            Score.Text = highScore;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= GameOver_BackRequested;

        }

        private async void GameOver_BackRequested(object sender, BackRequestedEventArgs e)
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

        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            if (SimpleMaths.Maths.mode == 1)
            {
                Frame.Navigate(typeof(Advanced));
            }
            else
                Frame.Navigate(typeof(PlaySingle));
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
