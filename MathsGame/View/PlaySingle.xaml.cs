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
    public sealed partial class PlaySingle : Page
    {
        public PlaySingle()
        {
            this.InitializeComponent();
        }

        private int staticNumA, staticNumB, staticResult, staticRandomResult, Score = 0, State = 1, mode;
        private DispatcherTimer dispatcherTimer;

        private void setupProgressBar()
        {
            // initialise the timer to begin the countdown
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

            progressBar.Value = 9999;// set the value to max
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += PlaySingle_BackRequested;
            dispatcherTimer = null;

            Playing();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= PlaySingle_BackRequested;
           
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            // subtracts the value of the speed set in the options from the progress every tick
            progressBar.Value -= SimpleMaths.Maths.speed;
            if (progressBar.Value <= 0)
            {
                dispatcherTimer.Stop();// timer is stopped
                dispatcherTimer = null;// timer is set to 0
                // Navigate to game over page and pass the score to the OnNavigate constructor arguements to be set to the new highscore
                Frame.Navigate(typeof(GameOver), Score.ToString());
            }
        }

        private async void PlaySingle_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            e.Handled = true;
            dispatcherTimer.Stop();// timer is stopped
            dispatcherTimer = null;// timer is set to 0

            var msg = new MessageDialog("Would you like to go back?");// when the user hits the back button they'll be ask would they like to go back
            var okBtn = new UICommand("Yes");
            var kindaBtn = new UICommand("No");
            msg.Commands.Add(okBtn);
            msg.Commands.Add(kindaBtn);
            IUICommand result = await msg.ShowAsync();

            if (result != null && result.Label.Equals("Yes"))
            {
                //Application.Current.Exit();
                Frame.Navigate(typeof(GameOver), Score.ToString()); // Navigate to game over screen and send score 
            }
        }

        private void btnTrue_Click(object sender, RoutedEventArgs e)
        {
            if (mode == 1) // mode = 1 so correct answer is True
            {
                txtScore.Text = String.Format("Score: {0}".ToUpper(), ++Score);
                txtState.Text = String.Format("{0}", ++State);
                dispatcherTimer.Stop();// timer is stopped
                dispatcherTimer = null;// timer set to 0
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

        private void Playing()
        {
            // Generates a random number between  1 and 4 and uses it to select which operator will be used in the calculation
            Random rnd = new Random();
            int value = rnd.Next(1, 5);
           // int value = 1; // for testing
            if (value == 1)// +
            {
                // staticNums generate numbers between 1 and 9 to create simple maths problems
                staticNumA = rnd.Next(1, 10);
                staticNumB = rnd.Next(0, staticNumA - 1);
                staticResult = staticNumA + staticNumB;// calculation to determine the true answer from the generated numbers 
                staticRandomResult = rnd.Next(0, 81);// random result is used when the answer is false 
               // TextBlock myBlock = new TextBlock();
                mode = rnd.Next(0, 2);// Random Mode show answer if mode = 0 show incorrect answer

                if (mode == 0)
                {
                    // if mode is equal to 0 the answer will be false using the random result
                    //txtMath.Text = "Hello world"; // for testing
                    txtMath.Text = String.Format("{0} + {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                    
                }
                else
                    //txtMath.Text = "Hello world"; // for testing
                    txtMath.Text = String.Format("{0} + {1} = {2}", staticNumA, staticNumB, staticResult);
            }
            if (value == 2)// -
            {
                // staticNums generate numbers between 1 and 9 to create simple maths problems
                staticNumA = rnd.Next(1, 10);
                staticNumB = rnd.Next(0, staticNumA - 1);
                staticResult = staticNumA - staticNumB;
                staticRandomResult = rnd.Next(0, 81);

                mode = rnd.Next(0, 2);// Random Mode show answer if mode = 0 show incorrect answer

                if (mode == 0)
                {
                    txtMath.Text = String.Format("{0} - {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                }
                else
                    txtMath.Text = String.Format("{0} - {1} = {2}", staticNumA, staticNumB, staticResult);
            }
            if (value == 3)// *
            {

                staticNumA = rnd.Next(1, 10);
                staticNumB = rnd.Next(0, staticNumA - 1);
                staticResult = staticNumA * staticNumB;
                staticRandomResult = rnd.Next(0, 81);

                mode = rnd.Next(0, 2);// Random Mode show answer if mode = 0 show incorrect answer

                if (mode == 0)
                {
                    txtMath.Text = String.Format("{0} X {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                }
                else
                    txtMath.Text = String.Format("{0} X {1} = {2}", staticNumA, staticNumB, staticResult);
            }
            if (value == 4)// /
            {
                staticNumA = rnd.Next(1, 10);
                staticNumB = rnd.Next(1, staticNumA); // cant divide by 0
                staticResult = staticNumA / staticNumB;
                staticRandomResult = rnd.Next(0, 81);

                mode = rnd.Next(0, 2);// Random Mode show answer if mode = 0 show incorrect answer
                if (staticNumA % staticNumB != 0)// if modulous is not = 0 then random answer is selected 
                {
                    mode = 0;
                }
                if (mode == 0)
                {
                    txtMath.Text = String.Format("{0} ÷ {1} = {2}", staticNumA, staticNumB, staticRandomResult);
                }
                else
                    txtMath.Text = String.Format("{0} ÷ {1} = {2}", staticNumA, staticNumB, staticResult);
            }
            setupProgressBar(); // restarts the progress bar for the next question
        }

        private void btnFalse_Click(object sender, RoutedEventArgs e)
        {
            if (mode == 0) // mode = 0 so correct answer is false
            {
                txtScore.Text = String.Format("Score: {0}".ToUpper(), ++Score);
                txtState.Text = String.Format("{0}", ++State);
                dispatcherTimer.Stop();// timer is stopped
                dispatcherTimer = null;/// timer is set to 0
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
    }
}
