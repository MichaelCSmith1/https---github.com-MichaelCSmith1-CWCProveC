using System;

    
namespace Unit02.Game
{    
    
    public class Card
    {
        public int value;
        /// <summary>
        /// Constructor for the card class. Calls the Draw function.
        /// </summary>
        public Card()
        {
            Draw();
        }

        /// <summary>
        /// Assigns a value between 1 and 13 to the card calling the draw function. Value represents the cards number.
        /// </summary>
        public void Draw()
        {
            Random random = new Random();
            value = random.Next(1, 14);
        }
    }
}