#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using P02Project.Resources.xml;
using P02Project.Utils;

#endregion

namespace P02Project.Screens.Game
{
    /// <summary>
    ///     Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        /// <summary>
        /// The selected color
        /// </summary>
        private static readonly Brush SELECTED_COLOR = new SolidColorBrush(Util._pageColDict["pbSelected"]);
        /// <summary>
        /// The unselected color
        /// </summary>
        private static readonly Brush UNSELECTED_COLOR = new SolidColorBrush(Util._pageColDict["pbUnSelected"]);
        //sea turtle green #438D80
        /// <summary>
        /// The enabled color
        /// </summary>
        private static readonly Brush ENABLED_COLOR = new SolidColorBrush(Util._pageColDict["cuSelected"]);
        // teal #008080
        /// <summary>
        /// The disabled color
        /// </summary>
        private static readonly Brush DISABLED_COLOR = new SolidColorBrush(Util._pageColDict["cuUnSelected"]);
        //red
        /// <summary>
        /// The incorrect color
        /// </summary>
        private static readonly Brush INCORRECT_COLOR =
            new SolidColorBrush((Color) ColorConverter.ConvertFromString("#FF0000"));

        //green
        /// <summary>
        /// The correct color
        /// </summary>
        private static readonly Brush CORRECT_COLOR =
            new SolidColorBrush((Color) ColorConverter.ConvertFromString("#008000"));

        /// <summary>
        /// The button list
        /// </summary>
        private readonly List<Button> buttonList;
        /// <summary>
        /// The question buttons
        /// </summary>
        private readonly List<Button> questionButtons;
        /// <summary>
        /// The active question
        /// </summary>
        private Question activeQuestion;
        /// <summary>
        /// The chosen questions
        /// </summary>
        private List<Question> chosenQuestions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Quiz"/> class.
        /// </summary>
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


            String path = Path.Combine(Path.GetFullPath("."), "Resources/xml/Questions.xml");
            PageModel model = XMLUtilities.GetContentFromFile(path);
            PageModelText[] textList = model.TextList;
            List<Question> Questions = new List<Question>();
            for (int i = 0; i < textList.Count(); i = i + 6)
            {
                List<String> options = new List<string>();
                for (int j = i + 1; j < i + 5; j++)
                {
                    options.Add(textList[j].Value);
                }
                String hint = textList[i + 5].Value;

                Question q = new Question(textList[i].Value, options[0], options, "", hint);
                Questions.Add(q);
            }
            ChooseQuestions(Questions);
            activeQuestion = chosenQuestions[0];
            addButtonColours(0);

            closeButton.Background = SELECTED_COLOR;
            closeButton.Effect = dShdow;
        }

        /// <summary>
        /// Chooses the questions.
        /// </summary>
        /// <param name="AllQuestions">All questions.</param>
        private void ChooseQuestions(List<Question> AllQuestions)
        {
            chosenQuestions = new List<Question>();
            for (int i = 0; i < 6; i++)
            {
                int index = Question.rand.Next(AllQuestions.Count);
                chosenQuestions.Add(AllQuestions[index]);
                AllQuestions.RemoveAt(index);
                //choose 6 random questions
            }
        }

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setContent(activeQuestion);
        }

        /// <summary>
        /// Handles the click event of the question5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void question5_click(object sender, RoutedEventArgs e)
        {
            activeQuestion = chosenQuestions[4];
            questionNumber.Text = "Question 5";
            setContent(activeQuestion);
            addButtonColours(4);

            ResetTimer();
        }

        /// <summary>
        ///     Resets the timer.
        /// </summary>
        private void ResetTimer()
        {
            try
            {
                var topWindow = GetWindow(this) as TopWindow;
                if (topWindow != null) topWindow.ResetTimer();
            }
            catch (NullReferenceException)
            {
            }
        }

        /// <summary>
        ///     Handles the Click event of the question4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void question4_Click(object sender, RoutedEventArgs e)
        {
            activeQuestion = chosenQuestions[3];
            questionNumber.Text = "Question 4";
            addButtonColours(3);
            setContent(activeQuestion);

            ResetTimer();
        }

        /// <summary>
        ///     Handles the Click event of the question3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void question3_Click(object sender, RoutedEventArgs e)
        {
            activeQuestion = chosenQuestions[2];
            questionNumber.Text = "Question 3";
            setContent(activeQuestion);
            addButtonColours(2);

            ResetTimer();
        }

        /// <summary>
        ///     Handles the Click event of the question6 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void question6_Click(object sender, RoutedEventArgs e)
        {
            activeQuestion = chosenQuestions[5];
            addButtonColours(5);
            setContent(activeQuestion);

            ResetTimer();
        }

        /// <summary>
        ///     Handles the Click event of the question2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void question2_CLick(object sender, RoutedEventArgs e)
        {
            activeQuestion = chosenQuestions[1];
            questionNumber.Text = "Question 2";
            setContent(activeQuestion);
            addButtonColours(1);

            ResetTimer();
        }

        /// <summary>
        ///     Handles the Click event of the question1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void question1_Click(object sender, RoutedEventArgs e)
        {
            activeQuestion = chosenQuestions[0];
            questionNumber.Text = "Question 1";
            setContent(activeQuestion);
            addButtonColours(0);
            ResetTimer();
        }

        /// <summary>
        ///     Handles the click event of the fifty_fifty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void fifty_fifty_click(object sender, RoutedEventArgs e)
        {
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

            ResetTimer();
        }

        /// <summary>
        ///     Handles the click event of the hint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void hint_click(object sender, RoutedEventArgs e)
        {
            if (!activeQuestion.IsAnswered)
            {
                hint_button.IsEnabled = false;
                activeQuestion.HintUsed = true;
                setContent(activeQuestion);
                hint_button.Background = UNSELECTED_COLOR;
                hint_button.Effect = null;
            }

            ResetTimer();
        }

        /// <summary>
        ///     Handles the click event of the skip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void skip_click(object sender, RoutedEventArgs e)
        {
            if (!activeQuestion.IsAnswered)
            {
                skip_button.IsEnabled = false;
                activeQuestion.Answer(activeQuestion.CorrectAnswer);
                setContent(activeQuestion);
                skip_button.Background = UNSELECTED_COLOR;
                skip_button.Effect = null;
            }

            ResetTimer();
        }

        /// <summary>
        ///     Sets the content.
        /// </summary>
        /// <param name="qn">The qn.</param>
        private void setContent(Question qn)
        {
            content_title.Text = qn.QuestionContent;
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
                    StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " +
                                     activeQuestion.OptionSelected;
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

        /// <summary>
        ///     Sets the score.
        /// </summary>
        private void setScore()
        {
            int score = chosenQuestions.Count(qun => qun.IsCorrect);
            scoreField.Text = score.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Handles the Clicked event of the option_A control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void option_A_Clicked(object sender, RoutedEventArgs e)
        {
            answerQuestion((String)option_A.Content);

            ResetTimer();
        }

        /// <summary>
        ///     Handles the Clicked event of the option_B control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void option_B_Clicked(object sender, RoutedEventArgs e)
        {
            answerQuestion((String)option_B.Content);

            ResetTimer();
        }

        /// <summary>
        ///     Handles the Clicked event of the option_C control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void option_C_Clicked(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.

            answerQuestion((String)option_c.Content);

            ResetTimer();
        }

        /// <summary>
        ///     Handles the Clicked event of the option_D control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void option_D_Clicked(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.

            answerQuestion((String)option_D.Content);

            ResetTimer();
        }

        /// <summary>
        ///     Changes the state of the button.
        /// </summary>
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
                }
                else
                {
                    buttonList[i].Background = DISABLED_COLOR;
                    buttonList[i].Effect = null;
                }
            }
        }

        private void close_Clicked(object sender, RoutedEventArgs e)
        {
            ResetTimer();
            Close();
        }

        /// <summary>
        ///     Adds the button colours.
        /// </summary>
        /// <param name="index">The index.</param>
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

        private void answerQuestion(String content)
        {
            if (activeQuestion != null && activeQuestion.Answer(content))
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
                StatusBar.Text = "Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " +
                                 activeQuestion.OptionSelected;
            }
            changeButtonState();
            setScore();
        }
    }
}