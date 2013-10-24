using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using P02Project.Utils;
using P02Project.Utils.xml;
using P02Project.Resources.xml;
using System.Windows.Media.Effects;

namespace P02Project.Screens.Game
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        private List<Question> chosenQuestions;
        private static readonly Brush SELECTED_COLOR = new SolidColorBrush(Util._pageColDict["pbSelected"]);
        private static readonly Brush UNSELECTED_COLOR = new SolidColorBrush(Util._pageColDict["pbUnSelected"]);
        //sea turtle green #438D80
        private static readonly Brush ENABLED_COLOR = new SolidColorBrush(Util._pageColDict["cuSelected"]);
        // teal #008080
        private static readonly Brush DISABLED_COLOR = new SolidColorBrush(Util._pageColDict["cuUnSelected"]);
        //red
        private static readonly Brush INCORRECT_COLOR = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000"));
        //green
        private static readonly Brush CORRECT_COLOR = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#008000"));
        private Question activeQuestion;
        private List<Button> buttonList;
        private List<Button> questionButtons;
        public Quiz()
        {
            InitializeComponent();
            buttonList = new List<Button>();
            //create a new list of questions
            buttonList.Add(option_A);
            buttonList.Add(option_B);
            buttonList.Add(option_c);
            buttonList.Add(option_D);

            questionButtons = new List<Button>();
            questionButtons.Add(QnOne);
            questionButtons.Add(QnTwo);
            questionButtons.Add(QnThree);
            questionButtons.Add(QnFour);
            questionButtons.Add(QnFive);
            questionButtons.Add(QnSix);

            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            fifty_fifty_button.Effect = dShdow;
            skip_button.Effect = dShdow;
            hint_button.Effect = dShdow;
            

            String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "Resources/xml/Questions.xml");
            PageModel model = XMLUtilities.GetContentFromFile(path);
            PageModelText[] textList = model.TextList;
            List<Question> Questions = new List<Question>();
            for (int i = 0; i < textList.Count(); i = i + 6)
            {
                List<String> options = new List<string>();
                for (int j = i+1; j < i+5; j++){
                    options.Add(textList[j].Value);
                }
                String hint = textList[i + 5].Value;

                Question q = new Question(textList[i].Value,options[0],options,"",hint);
                Questions.Add(q);
            }
                ChooseQuestions(Questions);
            activeQuestion = chosenQuestions[0];
            addButtonColours(0);
            
            closeButton.Background = SELECTED_COLOR;
            closeButton.Effect = dShdow;

        }

        private void ChooseQuestions(List<Question>AllQuestions)
        {
            this.chosenQuestions = new List<Question>();
            for (int i = 0; i < 6; i++)
            {
                int index = Question.rand.Next(AllQuestions.Count);
                this.chosenQuestions.Add(AllQuestions[index]);
                AllQuestions.RemoveAt(index);
                //choose 6 random questions

            }

        } 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setContent(activeQuestion);
        }

        private void question5_click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[4];
            questionNumber.Text = "Question 5";
            setContent(activeQuestion);
            addButtonColours(4);

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void question4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[3];
            questionNumber.Text = "Question 4";
            addButtonColours(3);
            setContent(activeQuestion);

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void question3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[2];
            questionNumber.Text = "Question 3";
            setContent(activeQuestion);
            addButtonColours(2);

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void question6_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[5];
            addButtonColours(5);
            setContent(activeQuestion);

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void question2_CLick(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[1];
            questionNumber.Text = "Question 2";
            setContent(activeQuestion);
            addButtonColours(1);

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void question1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[0];
            questionNumber.Text = "Question 1";
            setContent(activeQuestion);
            addButtonColours(0);

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void fifty_fifty_click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            // Take two random wrong answers away
            if (!activeQuestion.IsAnswered)
            {
                fifty_fifty_button.IsEnabled = false;
                activeQuestion.fifty_fifty();
                changeButtonState();
                fifty_fifty_button.Background = UNSELECTED_COLOR;
                fifty_fifty_button.Effect = null;
                //get two random items from the list that are incorrect
                
            }

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void hint_click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!activeQuestion.IsAnswered)
            {
                
                hint_button.IsEnabled = false;
                activeQuestion.HintUsed = true;
                setContent(activeQuestion);
                hint_button.Background = UNSELECTED_COLOR;
                hint_button.Effect = null;
            }

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void skip_click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.\
            if (!activeQuestion.IsAnswered)
            {
                skip_button.IsEnabled = false;
                activeQuestion.Answer(activeQuestion.CorrectAnswer);
                setContent(activeQuestion);
                skip_button.Background = UNSELECTED_COLOR;
                skip_button.Effect = null;
            }

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
            
        }

        private void setContent(Question qn)
        {
            content_title.Text = qn.QuestionContent;
            //option_A.Content = activeQuestion.AllAvailableOptions[0];
            //option_A.SetValue(Text,activeQuestion.AllAvailableOptions[0]);
            option_A.Content = qn.AllAvailableOptions[0];
            option_B.Content = qn.AllAvailableOptions[1];
            option_c.Content = qn.AllAvailableOptions[2];
            option_D.Content = qn.AllAvailableOptions[3];
            if (qn.IsAnswered)
            {
                changeButtonState();
                if (qn.IsCorrect)
                {
                    correctField.Foreground = CORRECT_COLOR;
                    correctField.Text = "Correct!";
                    StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer;
                }
                else
                {
                    correctField.Foreground = INCORRECT_COLOR;
                    correctField.Text = "Incorrect!";
                    StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer+"\nYou answered: "+activeQuestion.OptionSelected;
                }

            }
            else if (qn.HintUsed)
            {
                StatusBar.Text = "Hint: " + activeQuestion.Hint;
            }
            else
            {
                
                correctField.Text = "";
                changeButtonState();
                StatusBar.Text = "";
            }
            setScore();
        }

        private void setScore()
        {
            int score = 0;
            foreach (Question qun in chosenQuestions)
            {
                if (qun.IsCorrect == true)
                {
                    score++;
                }
            }
            scoreField.Text = score.ToString();
        }

        private void option_A_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            
            if (activeQuestion.Answer((String)option_A.Content))
            {
                //deactivate the other buttons
                correctField.Foreground = CORRECT_COLOR;
                correctField.Text = "Correct!";
                StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer;
            }
            else
            {
                correctField.Foreground = INCORRECT_COLOR;
                correctField.Text = "Incorrect!";
                StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " + activeQuestion.OptionSelected;
            }
            changeButtonState();
            setScore();

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void option_B_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            
            if (activeQuestion.Answer((String)option_B.Content))
            {
                correctField.Foreground = CORRECT_COLOR;
                correctField.Text = "Correct!";
                StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer;
            }
            else
            {
                correctField.Foreground = INCORRECT_COLOR;
                correctField.Text = "Incorrect!";
                StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " + activeQuestion.OptionSelected;
            }
            changeButtonState();
            setScore();

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void option_C_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            
            if (activeQuestion.Answer((String)option_c.Content))
            {
                correctField.Foreground = CORRECT_COLOR;
                correctField.Text = "Correct!";
                StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer;
            }
            else
            {
                correctField.Foreground = INCORRECT_COLOR;
                correctField.Text = "Incorrect!";
                StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " + activeQuestion.OptionSelected;
            }
            changeButtonState();
            setScore();

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void option_D_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            
            if (activeQuestion.Answer((String)option_D.Content))
            {
                correctField.Foreground = CORRECT_COLOR;
                correctField.Text = "Correct!";
                StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer;
                
            }
            else
            {
                correctField.Foreground = INCORRECT_COLOR;
                correctField.Text = "Incorrect!";
                StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " + activeQuestion.OptionSelected;
            }
            changeButtonState();
            setScore();

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void changeButtonState()
        {
            for (int i = 0; i < activeQuestion.IsEnabled.Count; i++)
            {
                buttonList[i].IsEnabled = activeQuestion.IsEnabled[i];
                if (buttonList[i].IsEnabled)
                {
                    buttonList[i].Background = ENABLED_COLOR;
                    DropShadowEffect dShdow = new DropShadowEffect();
                    dShdow.BlurRadius = 10;
                    dShdow.Opacity = 0.365;
                    buttonList[i].Effect = dShdow;
                }else
                {
                    buttonList[i].Background = DISABLED_COLOR;
                    buttonList[i].Effect = null;
                }
            }

        }

        private void close_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        	// TODO: Add event handler implementation here.

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }

        private void addButtonColours(int index)
        {
            for (int i = 0; i < questionButtons.Count; i++)
            {
                if (i == index)
                {
                    questionButtons[i].Background = SELECTED_COLOR;
                    DropShadowEffect dShdow = new DropShadowEffect();
                    dShdow.BlurRadius = 10;
                    dShdow.Opacity = 0.365;
                    questionButtons[i].Effect = dShdow;
                }
                else
                {
                    questionButtons[i].Background = UNSELECTED_COLOR;
                    questionButtons[i].Effect = null;
                }
            }
        }
    }
}
