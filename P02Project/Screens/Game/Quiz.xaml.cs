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

namespace P02Project.Screens.Game
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        private List<Question> chosenQuestions;
        private Question activeQuestion;
        private List<Button> buttonList;
        public Quiz()
        {
            InitializeComponent();
            buttonList = new List<Button>();
            //create a new list of questions
            buttonList.Add(option_A);
            buttonList.Add(option_B);
            buttonList.Add(option_c);
            buttonList.Add(option_D);

            String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "Resources/xml/Questions.xml");
            PageModel model = XMLUtilities.GetContentFromFile(path);
            PageModelText[] textList = model.TextList;
            List<Question> Questions = new List<Question>();
            for (int i = 0; i < textList.Count(); i = i + 5)
            {
                List<String> options = new List<string>();
                for (int j = i+1; j < i+5; j++){
                    options.Add(textList[j].Value);
                }

                Question q = new Question(textList[i].Value,options[0],options,"","Add hint here");
                Questions.Add(q);
            }
                //String answer = "Answer";
                //Options.Add(answer);
                //Options.Add("Not Answer 1");
                //Options.Add("Not Answer 2");
                //Options.Add("Not Answer 3");
                //List<Question> Questions = new List<Question>();
                //Questions.Add(new Question("Random Qn 1", answer, Options.ToList(), "nothing/image/path","hint 1"));
                //Questions.Add(new Question("Random Qn 2", answer, Options.ToList(), "nothing/image/path","hint 2"));
                //Questions.Add(new Question("Random Qn 3", answer, Options.ToList(), "nothing/image/path","hint 3"));
                //Questions.Add(new Question("Random Qn 4", answer, Options.ToList(), "nothing/image/path","hint 4"));
                //Questions.Add(new Question("Random Qn 5", answer, Options.ToList(), "nothing/image/path","hint 5"));
                //Questions.Add(new Question("Random Qn 6", answer, Options.ToList(), "nothing/image/path","hint 6"));
                ChooseQuestions(Questions);
            activeQuestion = chosenQuestions[0];
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
            setContent(activeQuestion);
        }

        private void question4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[3];
            setContent(activeQuestion);
        }

        private void question3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[2];
            setContent(activeQuestion);
        }

        private void question6_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[5];
            setContent(activeQuestion);
        }

        private void question2_CLick(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[1];
            setContent(activeQuestion);
        }

        private void question1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            activeQuestion = chosenQuestions[0];
            setContent(activeQuestion);
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
                //get two random items from the list that are incorrect
                
            }
        }

        private void hint_click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!activeQuestion.IsAnswered)
            {
                
                hint_button.IsEnabled = false;
                activeQuestion.HintUsed = true;
                setContent(activeQuestion);
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
                    StatusBar.Text = "Correct! Answer was: " + activeQuestion.CorrectAnswer;
                }
                else
                {
                    StatusBar.Text = "Incorrect! Answer was: " + activeQuestion.CorrectAnswer+"\nYou answered: "+activeQuestion.OptionSelected;
                }

            }
            else if (qn.HintUsed)
            {
                StatusBar.Text = "Hint: " + activeQuestion.Hint;
            }
            else
            {
                changeButtonState();
                StatusBar.Text = "";
            }
        }

        private void option_A_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            
            if (activeQuestion.Answer((String)option_A.Content))
            {
                //deactivate the other buttons
                
                StatusBar.Text = "Correct! Answer was: " + activeQuestion.CorrectAnswer;
            }
            else
            {
                StatusBar.Text = "Incorrect! Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " + activeQuestion.OptionSelected;
            }
            changeButtonState();
        }

        private void option_B_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            
            if (activeQuestion.Answer((String)option_B.Content))
            {
                StatusBar.Text = "Correct! Answer was: " + activeQuestion.CorrectAnswer;
            }
            else
            {
                StatusBar.Text = "Incorrect! Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " + activeQuestion.OptionSelected;
            }
            changeButtonState();
        }

        private void option_C_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            
            if (activeQuestion.Answer((String)option_c.Content))
            {
                StatusBar.Text = "Correct! Answer was: " + activeQuestion.CorrectAnswer;
            }
            else
            {
                StatusBar.Text = "Incorrect! Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " + activeQuestion.OptionSelected;
            }
            changeButtonState();
        }

        private void option_D_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            
            if (activeQuestion.Answer((String)option_D.Content))
            {
                StatusBar.Text = "Correct! Answer was: " + activeQuestion.CorrectAnswer;
                
            }
            else
            {
                StatusBar.Text = "Incorrect! Answer was: " + activeQuestion.CorrectAnswer + "\nYou answered: " + activeQuestion.OptionSelected;
            }
            changeButtonState();
        }

        private void changeButtonState()
        {
            for (int i = 0; i < activeQuestion.IsEnabled.Count; i++)
            {
                buttonList[i].IsEnabled = activeQuestion.IsEnabled[i];
            }

        }

    }
}
