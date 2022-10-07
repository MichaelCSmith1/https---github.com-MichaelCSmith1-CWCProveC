using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        
        bool _isPlaying = true;
        int _score = 0;
        int _totalScore = 75;
        string guess;
        Card card = new Card();
        Card nextCard = new Card();
        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            
        }

        /// <summary>
        /// Starts the game by running the main game loop. We have also added a check for the game ending. Would be better in the future to do this in DoUpdates().
        /// </summary>
        public void StartGame()
        {
            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
                if(_totalScore > 0)
                {
                Console.WriteLine("Play again? [y/n] ");
                string playAgain = Console.ReadLine();
                _isPlaying = (playAgain == "y");
                }
                else
                {
                    _isPlaying = false;
                    Console.WriteLine("You Lost!");
                }
            }
        }

        /// <summary>
        /// Gets the required inputs from the player, the user guesses whether or not the card is higher/lower than the next card.
        /// </summary>
        public void GetInputs()
        {
            Console.WriteLine($"The card is: {card.value}");
            Console.Write("Higher or lower? [h/l] ");
            guess = Console.ReadLine();
        }

        /// <summary>
        /// Updates the player's score based on their higher/lower guess.
        /// </summary>
        public void DoUpdates()
        {
            string highLow;
            _score = 0;
            if (card.value > nextCard.value)
            {
                highLow = "l";
            }
            else if (card.value < nextCard.value)
            {
                highLow = "h";
            }
            else
            {
                highLow = "t";
            }
            if (guess == highLow)
            {
                _score += 100;
            }
            else
            {
                _score -= 75;
            }
            Console.WriteLine($"{highLow}, {card.value}, {nextCard.value}, {guess}");
            _totalScore += _score;
            card.value = nextCard.value;
            
            nextCard.Draw();
            
        }

        /// <summary>
        /// Outputs the next card's value and the player totals score
        /// </summary>
        public void DoOutputs()
        {
            Console.WriteLine($"Next card was: {card.value}");
            Console.WriteLine($"Your score is: {_totalScore}");
        }
    }
}


