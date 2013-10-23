﻿using System;
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

        private String questionContent;
        private String answer;
        private List<String> allAvailableOptions;
        private String imagepath;
        private bool isAnswered;
        private String optionSelected;
        private String hintForQuestion;
        private bool isCorrect;

        //this is used to create a new Question that will be answered in teh quiz
        public Question(String QuestionContent, String answer, List<String> allOptions, String imagePath,String hint)
        {
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

        public bool Answer(String answer)
        {
            this.optionSelected = answer;
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
            Random r = new Random();
            //while there are still options in the alloptions list
            while (options.Count > 0)
            {
                //choose an index at random
                int index = r.Next(options.Count);
                //take the option chosen and add it to the randomisedOptions list
                allAvailableOptions.Add(options[index]);
                //remove the option from allOptions
                options.RemoveAt(index);
            }
        }

    }
}