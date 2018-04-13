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

    public sealed partial class Advanced : Page
    {
        private Random randomNum = new Random();
        private int Score = 0, highScore = 1, staticNumA, staticNumB, staticResult, state = 0;
        private DispatcherTimer dispatcherTimer;

        private void SetupProgressBar()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

            progreesBar.Value = 9999;
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            progreesBar.Value -= SimpleMaths.Maths.speed;
            if (progreesBar.Value <= 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Frame.Navigate(typeof(GameOver), Score.ToString());
            }

        }

        public Advanced()
        {
            this.InitializeComponent();
        }

        private int randomNumber()
        {
            return randomNum.Next(1, 9);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= PlayAdvanced_BackRequested;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += PlayAdvanced_BackRequested;
            highScore = int.Parse(SimpleMaths.Maths.LoadSettings("highscore"));
            txtHighScore.Text = String.Format("Highscore:(0)", highScore);
            dispatcherTimer = null;
            Playing();
        }

        private int randomValue()
        {
            // Generates a random number between  1 and 3 and uses it to select which operator will be used in the calculation
            return randomNum.Next(0, 4);
        }

        private void Playing()
        {
            int numberA = randomValue();
            int numberB = randomNum.Next(0, numberA - 1);
            int value = randomValue();
            int result = -1;

            if (value == 0)
                result = numberA + numberB;
            else if (value == 1)
                result = numberA - numberB;
            else if (value == 2)
                result = numberA * numberB;
            else
                result = numberA / numberB;

            // staticNums generate numbers between 1 and 9 to create simple maths problems
            staticNumA = numberA;
            staticNumB = numberB;
            staticResult = result;
            txtMath.Text = String.Format("{0} ... {1} = {2}", staticNumA, staticNumB, staticResult);

            SetupProgressBar();

        }

        private async void PlayAdvanced_BackRequested(object sender, BackRequestedEventArgs e)
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
                //Application.Current.Exit();
                Frame.Navigate(typeof(GameOver), Score.ToString()); // Navigate to game over screen and send score 
            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            // take the given numbers and check if the operator is correct
            if (staticNumA + staticNumB == staticResult)
            {
                txtHighScore.Text = String.Format("Score: (0)".ToUpper(), ++Score);
                txtState.Text = String.Format("{0}", ++state);
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Playing();
            }
            else
            {
                dispatcherTimer.Stop();// timer is stopped
                dispatcherTimer = null;// timer is set to 0
                // Navigate to game over page and pass the score to the OnNavigate constructor arguements to be set to the new highscore
                Frame.Navigate(typeof(GameOver), Score.ToString());
            }
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            // take the given numbers and check if the operator is correct
            if (staticNumA - staticNumB == staticResult)
            {
                txtHighScore.Text = String.Format("Score: (0)".ToUpper(), ++Score);
                txtState.Text = String.Format("{0}", ++state);
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Playing();
            }
            else
            {
                dispatcherTimer.Stop();// timer is stopped
                dispatcherTimer = null;// timer is set to 0
                // Navigate to game over page and pass the score to the OnNavigate constructor arguements to be set to the new highscore
                Frame.Navigate(typeof(GameOver), Score.ToString());
            }
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            // take the given numbers and check if the operator is correct
            if (staticNumA * staticNumB == staticResult)
            {
                txtHighScore.Text = String.Format("Score: (0)".ToUpper(), ++Score);
                txtState.Text = String.Format("{0}", ++state);
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                Playing();
            }
            else
            {
                dispatcherTimer.Stop();// timer is stopped
                dispatcherTimer = null;// timer is set to 0
                // Navigate to game over page and pass the score to the OnNavigate constructor arguements to be set to the new highscore
                Frame.Navigate(typeof(GameOver), Score.ToString());
            }
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // take the given numbers and check if the operator is correct
                if (staticNumA / staticNumB == staticResult)
                {
                    txtHighScore.Text = String.Format("Score: (0)".ToUpper(), ++Score);
                    txtState.Text = String.Format("{0}", ++state);
                    dispatcherTimer.Stop();
                    dispatcherTimer = null;
                    Playing();
                }
                else
                {
                    dispatcherTimer.Stop();// timer is stopped
                    dispatcherTimer = null;// timer is set to 0
                    // Navigate to game over page and pass the score to the OnNavigate constructor arguements to be set to the new highscore
                    Frame.Navigate(typeof(GameOver), Score.ToString());
                }
            }
            catch (DivideByZeroException)
            {
                Frame.Navigate(typeof(GameOver), Score.ToString());
            }
        }
    }
}
