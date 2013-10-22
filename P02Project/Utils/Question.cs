using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02Project.Utils
{
    class Question
    {
        private String questionContent;
        private String answer;
        private List<String> otherAlternatives;

        //this is used to create a new Question that will be answered in teh quiz
        public Question(String QuestionContent, String answer, List<String> otherAlternatives)
        {
            this.questionContent = QuestionContent;
            this.answer = answer;
            if (otherAlternatives.Count != 3)
            {
                throw new ArgumentException();
            }
            this.otherAlternatives = otherAlternatives;
        }

        public bool checkAnswer(String answer)
        {
            if (answer == this.answer)
            {
                return true;
            }
            return false;
        }

        public List<String> getAllOptionsRandomized()
        {
            //randomised list
            List<String> randomisedOptions = new List<string>();
            //unrandom list
            List<String> allOptions = new List<string>();
            allOptions.Add(this.answer);
            allOptions.AddRange(this.otherAlternatives);
            //pick a random element from alloptions and add it to randomisedOptions
            //create a random item
            Random r = new Random();
            //while there are still options in the alloptions list
            while (allOptions.Count > 0)
            {
                //choose an index at random
                int index = r.Next(allOptions.Count);
                //take the option chosen and add it to the randomisedOptions list
                randomisedOptions.Add(allOptions[index]);
                //remove the option from allOptions
                allOptions.RemoveAt(index);
            }
            return randomisedOptions;
        }
    }
}
