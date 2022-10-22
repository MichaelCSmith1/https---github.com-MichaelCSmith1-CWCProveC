using System;
using System.Collections.Generic;

namespace Unit03.Game
{
    public class Jumper
    {
        /// <summary>
        /// Class Variables being defined.
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        private List<string> _jumper = new List<string>();
        private TerminalService _terminalService = new TerminalService();
        
        /// <summary>
        /// Jumper Constructor. Creates and displays jumper.
        /// </summary>
        public Jumper()
        {

            _jumper.Add(@" ___ ");
            _jumper.Add(@"/___\");
            _jumper.Add(@"\   /");
            _jumper.Add(@" \ / ");
            _jumper.Add(@"  0  ");
            _jumper.Add(@" /|\ ");
            _jumper.Add(@" / \ ");
            _jumper.Add(@"     ");
            _jumper.Add(@"     ");
            _jumper.Add(@"^^^^^");

            displayJumper();
        }

        /// <summary>
        /// Removes first index of jumper list and replaces head with x when game is over.
        /// </summary>
        public void updateJumper()
        {
            if (_jumper[0] == "  0  ")
            {
                _jumper[0] = ("  x  ");
            }
            else
            {
                _jumper.RemoveAt(0);
            }
        }

        /// <summary>
        /// Checks for loss through the state of jumper index 0.
        /// </summary>
        /// <returns> true/false </returns>
        public bool checkLoss()
        {
            if (_jumper[0] == "  x  ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Loops through jumper list and prints each line.
        /// </summary>
        public void displayJumper()
        {
            _terminalService.WriteLine("");
            _terminalService.WriteLine("");
            foreach (string line in _jumper)
            {
                _terminalService.WriteLine(line);
            }
        }
    
    }
}