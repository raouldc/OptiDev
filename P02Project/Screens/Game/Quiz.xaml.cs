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

namespace P02Project.Screens.Game
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        private List<Question> chosenQuestions;
        private Question activeQuestion;
        public Quiz()
        {
            InitializeComponent();
            //create a new list of questions
            List<String> Options = new List<String>();
            String answer = "Answer";
            Options.Add(answer);
            Options.Add("Not Answer 1");
            Options.Add("Not Answer 2");
            Options.Add("Not Answer 3");
            List<Question> Questions = new List<Question>();
            Questions.Add(new Question("Random Qn 1", answer, Options, "nothing/image/path","hint 1"));
            Questions.Add(new Question("Random Qn 2", answer, Options, "nothing/image/path","hint 2"));
            Questions.Add(new Question("Random Qn 3", answer, Options, "nothing/image/path","hint 3"));
            Questions.Add(new Question("Random Qn 4", answer, Options, "nothing/image/path","hint 4"));
            Questions.Add(new Question("Random Qn 5", answer, Options, "nothing/image/path","hint 5"));
            Questions.Add(new Question("Random Qn 6", answer, Options, "nothing/image/path","hint 6"));
            ChooseQuestions(Questions);
            activeQuestion = chosenQuestions[0];
        }

        private void ChooseQuestions(List<Question>AllQuestions)
        {
            this.chosenQuestions = new List<Question>();
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                int index = r.Next(AllQuestions.Count);
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
        }

        private void hint_click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

        private void skip_click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
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
            if (activeQuestion.IsAnswered)
            {
                disableButtons();

            }
            else
            {
                enableButtons();
            }
        }

        private void option_A_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            if (activeQuestion.Answer((String)option_A.Content))
            {
                //deactivate the other buttons
                option_B.IsEnabled = false;
                option_c.IsEnabled = false;
                option_D.IsEnabled = false;
            }
        }

        private void option_B_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            if (activeQuestion.Answer((String)option_B.Content))
            {
                disableButtons();
            }
        }

        private void option_C_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            if (activeQuestion.Answer((String)option_c.Content))
            {
                disableButtons();
            }
        }

        private void option_D_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            if (activeQuestion.Answer((String)option_D.Content))
            {
                disableButtons();
                
            }
        }

        private void disableButtons()
        {
            option_B.IsEnabled = false;
            option_c.IsEnabled = false;
            option_A.IsEnabled = false;
            option_D.IsEnabled = false;
        }

        private void enableButtons()
        {
            option_B.IsEnabled = true;
            option_c.IsEnabled = true;
            option_A.IsEnabled = true;
            option_D.IsEnabled = true;
        }
    }
}
