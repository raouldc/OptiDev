#region

using System;
using System.Collections.Generic;

#endregion

namespace P02Project.Utils
{
    internal class Question
    {
        public static Random rand = new Random();
        private readonly List<String> allAvailableOptions;
        private readonly String answer;
        private readonly String hintForQuestion;
        private readonly String imagepath;
        private readonly String questionContent;
        private bool isAnswered;
        private bool isCorrect;
        private String optionSelected;

        public Question(String QuestionContent, String answer, List<String> allOptions, String imagePath, String hint)
        {
            //all options are enabled at the beginign;
            IsEnabled = new List<bool>();
            IsEnabled.Add(true);
            IsEnabled.Add(true);
            IsEnabled.Add(true);
            IsEnabled.Add(true);

            allAvailableOptions = new List<String>();
            questionContent = QuestionContent;
            this.answer = answer;
            List<String> allOptionsTemp = new List<string>();
            allOptionsTemp.AddRange(allOptions);
            randomizeOptions(allOptionsTemp);
            imagepath = imagePath;
            optionSelected = null;
            isAnswered = false;
            hintForQuestion = hint;
            isCorrect = false;
        }
        //properties
        public String QuestionContent
        {
            get { return questionContent; }
        }

        public String ImagePath
        {
            get { return imagepath; }
        }

        public List<String> AllAvailableOptions
        {
            get { return allAvailableOptions; }
        }

        public bool IsAnswered
        {
            get { return isAnswered; }
        }

        public String Hint
        {
            get { return hintForQuestion; }
        }

        public bool IsCorrect
        {
            get { return isCorrect; }
        }

        public String OptionSelected
        {
            get { return optionSelected; }
        }

        public String CorrectAnswer
        {
            get { return answer; }
        }

        public bool HintUsed { get; set; }
        public List<bool> IsEnabled { get; set; }

        //fifty_fifty the question
        public void fifty_fifty()
        {

            List<int> usedIndexes = new List<int>();
            //get index of answer
            int rootindex = allAvailableOptions.IndexOf(answer);
            //for 2 options
            for (int i = 0; i < 2; i++)
            {
               
                int index = 100;
                int randomlySelectedIndex = 0;
                while (index >= 0)
                {
                    //choose a random index
                    randomlySelectedIndex = rand.Next(4);
                    //if it is not the root index
                    if (randomlySelectedIndex != rootindex)
                    {
                        //check if we have used this index before
                        index = usedIndexes.FindIndex(x => x == randomlySelectedIndex);
                        //if we have, re-check for an index
                    }
                }
                //add to used indexes
                usedIndexes.Add(randomlySelectedIndex);
            }
            //disable the two used indexes
            foreach (int indexUsed in usedIndexes)
            {
                IsEnabled[indexUsed] = false;
            }
        }

        //answer this question with an answer
        public bool Answer(String answer)
        {
            //set option selected
            optionSelected = answer;
            //disable all options
            for (int i = 0; i < IsEnabled.Count; i++)
            {
                IsEnabled[i] = false;
            }
            //set isAnswered
            isAnswered = true;
            //if correct, set iscorrect
            if (OptionSelected == this.answer)
            {
                isCorrect = true;
                return true;
            }
            return false;
        }

        //jumble up the answers to the questions randomly
        private void randomizeOptions(List<String> options)
        {
            allAvailableOptions.Clear();
            //pick a random element from options and add it to allOptions

            //while there are still options in the options list
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