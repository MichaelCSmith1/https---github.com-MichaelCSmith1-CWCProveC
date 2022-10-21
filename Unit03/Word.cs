using System;
using System.Collections.Generic;
using System.IO;

namespace Unit03.Game
{
    public class Word
    {
        private string _word;
        private List<string> _hint = new List<string>();
        private string _guess;
        private TerminalService _terminalService = new TerminalService();

        public Word()
        {
            readFile();
            makeHint();
            displayHint();
            
        }

        public string readFile()
        {
            List<string> words = new List<string>(File.ReadLines("words.txt"));

            Random random = new Random();
            _word = words[random.Next(words.Count + 1)];
            return _word;
        }

        public void makeHint()
        {
            for(int i = 0; i < _word.Length; i++)
            {
                _hint.Add(" _ ");
            }
        }
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

        public string getWord()
        {
            return _word;
        }

        public string getGuess()
        {
            _guess = _terminalService.ReadText("Guess a letter [a-z]: ");
            return _guess;
        }

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