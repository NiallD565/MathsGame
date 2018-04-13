# Recreation of a project located in 
https://github.com/NiallD565/SimpleMaths
# Simple Maths 
Project for mobile application development year 3 in Galway Mayo Istitute of Technology.

# Download and instillation
## Prerequisites
To successfully run this application you will need visual studio 2017 you can find it here https://www.visualstudio.com/downloads/

To clone this project to your machine navigate to where you want the project saves and run the following command 
`git clone https://github.com/NiallD565/MathsGame`

## Run the application
* Open visual studio 2017
* Go to the tool bar and press the green arrow with "Local Machine" writen beside it
![localmachine](https://user-images.githubusercontent.com/36037121/38736792-13ca2e6e-3f25-11e8-9f4d-55f9e32b5042.PNG)

## Using the program
* When you start up the project you will be brought to a mainpage and you will be given the choice of to play or to change the settings
![mainpage](https://user-images.githubusercontent.com/36037121/38737028-ce82c392-3f25-11e8-8fac-335a72bae1bf.PNG)

* If you click play you will be brought to this page
![playsingle](https://user-images.githubusercontent.com/36037121/38737058-e59a3ab0-3f25-11e8-9765-322a51b08d45.PNG)
* Random numbers between 0 and 9 will be generated along with operators it is up to the user to pick whether the answer given is correct or not
* If the user answers wrong they will be directed to a Game Over screen as shown here
![gameover](https://user-images.githubusercontent.com/36037121/38737214-6f479794-3f26-11e8-9555-9feb19d8e535.PNG)
* From there they can chose to try again or go to the home screen

* On the options page there is a slider to increrase or decrease the time in which the user will have to answer the questions
![speed](https://user-images.githubusercontent.com/36037121/38737471-3b2a6814-3f27-11e8-92a1-96451604a25a.PNG)

## Design
The purpose I had in mind for this app was to use it as an education tool for young kids learning maths tables and simple operators like +, -, ÷ and X. My thoughts were that it could be used on a tablet by a child and they can use it to learn basic maths.

## Resources
For this project I had orginially intended to do blackjack game but after some research I deemed that was beyond my abilities soI decide to still do a game so after more research I decided to do a simply calculation game. Using some of the labs I had previosly done through the model found here: https://learnonline.gmit.ie/course/view.php?id=4195 I started building my project. I had previoulsy implemented a slider in an old project and have used the code here. For the calculation performed in the app I researched the microsoftdocs here: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/. By researching XAML I came across the documentation for the for it here: https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.grid using these snipets of code I learned how to use the `<RowDefinition Height="Auto" />`, `<RowDefinition Height="*" />` tags appropriately to fill the space in the pages.

## Known bugs and Limitations
While there are no build errors or runtime errors in the current project, I've had to comment certain pieces of code to have a working version. When the application is first started if the user does not enter the options page first the progress bar will not decrement. Another know bug is if a number is divisable by another number and does leave a remainder the answer will still be true. I have tried to use the % operator to fix this issue. When the game over page is loaded the score the user has gotten is passed to the OnNavigated to function as a parameter and I have tried to set it to a local variable and convert it to an int using int.Parse method but I keep getting a "input string is not int the correct format error". The advanced page throws the same error.

## Conclusion
Although I found it challenging at points I enjoyed making this app. I feel I've learned more about C# and XAML and furthered my understanding by doing this project specifically about the grid format within the XAML and how it works as well as in C# how the naviation is different to other languages I have developed in. When debugging the app I learned more so how the information is handled when passing the values more so with the XAML and how to represent it through C#. If I could do this project again I would put more time into planning the app and making the transition of information more fluid through variable names and methods.
