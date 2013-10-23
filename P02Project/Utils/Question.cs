using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02Project.Utils
{
    class Question
    {
        public String QuestionContent { get { return this.questionContent; } }
        public String ImagePath { get {return this.imagepath; } }
        public List<String> AllAvailableOptions { get { return allAvailableOptions; } }
        public bool IsAnswered { get { return isAnswered; } }
        public String Hint { get { return hintForQuestion; } }
        public bool IsCorrect { get { return isCorrect; } }
        public String OptionSelected { get { return this.optionSelected; } }
        public String CorrectAnswer { get { return answer; } }
        public bool HintUsed {get;set;}
        public List<bool> IsEnabled { get; set; }

        private String questionContent;
        private String answer;
        private List<String> allAvailableOptions;
        private String imagepath;
        private bool isAnswered;
        private String optionSelected;
        private String hintForQuestion;
        private bool isCorrect;
        private static Random rand = new Random();
        //this is used to create a new Question that will be answered in teh quiz
        public Question(String QuestionContent, String answer, List<String> allOptions, String imagePath,String hint)
        {
            //all options are enabled at the beginign;
            IsEnabled = new List<bool>();
            IsEnabled.Add(true);
            IsEnabled.Add(true);
            IsEnabled.Add(true);
            IsEnabled.Add(true);
            
            this.allAvailableOptions = new List<String>();
            this.questionContent = QuestionContent;
            this.answer = answer;
            List<String> allOptionsTemp = new List<string>();
            allOptionsTemp.AddRange(allOptions);
            randomizeOptions(allOptionsTemp);
            this.imagepath = imagePath;
            this.optionSelected = null;
            this.isAnswered = false;
            this.hintForQuestion = hint;
            this.isCorrect = false;
        }

        public void fifty_fifty()
        {
            //Random r = new Random();
            List<int> usedIndexes = new List<int>();
            //usedIndexes.Add(allAvailableOptions.IndexOf(answer));
            int rootindex = allAvailableOptions.IndexOf(answer);
            for (int i = 0; i < 2; i++)
            {
                //get the correct answer
                int index = 100;
                int randomlySelectedIndex = 0;
                while (index>=0)
                {
                    randomlySelectedIndex = rand.Next(4);
                    if (randomlySelectedIndex != rootindex)
                    {
                        //check if we have used this index before
                        index = usedIndexes.FindIndex(x => x == randomlySelectedIndex);
                    }
                }
                usedIndexes.Add(randomlySelectedIndex);
            }
            foreach (int indexUsed in usedIndexes)
            {
                IsEnabled[indexUsed] = false;
            }
        }

        public bool Answer(String answer)
        {
            this.optionSelected = answer;
            for (int i = 0; i < IsEnabled.Count; i++)
            {
                IsEnabled[i] = false;
            }
                this.isAnswered = true;
            if (this.OptionSelected == this.answer)
            {
                this.isCorrect = true;
                return true;
            }
            return false;
        }

        private void randomizeOptions (List<String> options)
        {
            allAvailableOptions.Clear();
            //pick a random element from options and add it to allOptions
            //create a random item
           
            //while there are still options in the alloptions list
            while (options.Count > 0)
            {
                //choose an index at random
                int index = rand.Next(options.Count);
                //take the option chosen and add it to the randomisedOptions list
                allAvailableOptions.Add(options[index]);
                //remove the option from allOptions
                options.RemoveAt(index);
            }
        }

    }
}
