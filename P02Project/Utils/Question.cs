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
                while (index >= 0)
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
            optionSelected = answer;
            for (int i = 0; i < IsEnabled.Count; i++)
            {
                IsEnabled[i] = false;
            }
            isAnswered = true;
            if (OptionSelected == this.answer)
            {
                isCorrect = true;
                return true;
            }
            return false;
        }

        private void randomizeOptions(List<String> options)
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