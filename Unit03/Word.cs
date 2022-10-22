using System;
using System.Collections.Generic;
using System.IO;

namespace Unit03.Game
{
    public class Word
    {
        /// <summary>
        /// Declares class variables.
        /// </summary>
        private string _word;
        private List<string> _hint = new List<string>();
        private string _guess;
        private TerminalService _terminalService = new TerminalService();

        /// <summary>
        /// Word class constructor.
        /// </summary>
        public Word()
        {
            readFile();
            makeHint();
            displayHint();
            ///_terminalService.WriteLine(_word);
            
        }

        /// <summary>
        /// Reads file into a list of strings and sets _word equal to a random one.
        /// </summary>
        /// <returns> string _word</returns>
        public string readFile()
        {
            List<string> words = new List<string>(File.ReadLines("words.txt"));

            Random random = new Random();
            _word = words[random.Next(words.Count + 1)];
            return _word;
        }

        /// <summary>
        /// Creates the initial hint list based on length of word.
        /// </summary>
        public void makeHint()
        {
            for(int i = 0; i < _word.Length; i++)
            {
                _hint.Add(" _ ");
            }
        }
        
        /// <summary>
        /// Displays hint.
        /// </summary>
        public void displayHint()
        {
            /*string theWholeThing = String.Join(_hint);
            return theWholeThing;
            */

            foreach (string character in _hint)
            {
                _terminalService.WriteText(character);
            }
        }

        /// <summary>
        /// Returns word.
        /// </summary>
        /// <returns>_word</returns>
        public string getWord()
        {
            return _word;
        }

        /// <summary>
        /// Gets users input for guess variable.
        /// </summary>
        /// <returns> _guess </returns>
        public string getGuess()
        {
            _guess = _terminalService.ReadText("Guess a letter [a-z]: ");
            return _guess;
        }

        /// <summary>
        /// Updates hint index based on guess.
        /// </summary>
        public void updateHint()
        {
            int count = 0;
            foreach (char letter in _word)
            {
                if (_guess.ToLower() == letter.ToString())
                {
                    _hint[count] = " " + letter.ToString() + " ";
                }
                count++;
            }
        }

        /// <summary>
        /// Tests wheter _word contains _guess.
        /// </summary>
        /// <returns> true/false </returns>
        public bool testGuess()
        {
            if (_word.Contains(_guess))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks for lack of underscores to see if the word has been filled out.
        /// </summary>
        /// <returns> true/false </returns>
        public bool checkWin()
        {
            if (_hint.Contains(" _ "))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    
    }
}