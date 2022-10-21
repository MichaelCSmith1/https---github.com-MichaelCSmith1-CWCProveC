namespace Unit03.Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        
        private bool _isPlaying = true;
        private Word _word = new Word();
        private Jumper _jumper = new Jumper();
        private TerminalService _terminalService = new TerminalService();

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {

        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
            string word = _word.getWord();
            _terminalService.WriteLine($"Thanks for playing! \nThe word was {word}.");
        }

        /// <summary>
        /// Moves the seeker to a new location.
        /// </summary>
        private void GetInputs()
        {
           _word.getGuess();
        }

        /// <summary>
        /// Keeps watch on where the seeker is moving.
        /// </summary>
        private void DoUpdates()
        {
            _word.testGuess();
            if(_word.testGuess() == true)
            {
                _word.updateHint();
            }
            else
            {
                _jumper.updateJumper();
            }
            bool loss = _jumper.checkLoss();
            bool win = _word.checkWin();

            if (loss || win)
            {
                _isPlaying = false;

            }
        }

        /// <summary>
        /// Provides a hint for the seeker to use.
        /// </summary>
        private void DoOutputs()
        {
            _word.displayHint();
            _terminalService.WriteText("");
            _jumper.displayJumper();
            
        }
    }
}