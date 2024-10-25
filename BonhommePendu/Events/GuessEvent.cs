using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GameData GameData { get; set; }
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            this.Events = new List<GameEvent>();
            this.Events.Add(new GuessedLetterEvent(gameData, letter));
            if (!gameData.Word.Contains(letter))
            {
                this.Events.Add(new WrongGuessEvent(gameData));
                gameData.NbWrongGuesses++;


            }
            else
            {
                for (int i = 0; i < gameData.Word.Length; i++)
                {
                    if (gameData.HasSameLetterAtIndex(letter,i))
                    {
                        this.Events.Add(new RevealLetterEvent(gameData, letter,i));
                    }
                }

            }

            GameData = gameData;
        }
    }
}
