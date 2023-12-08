
namespace MyGame
{
    // Інтерфейс сервісу для ігор
    public interface GameInterfaceService
    {
        void PlayGame(Player player, Game game, string OpponentName, bool result);
        List<GameData> GetAllGames();
        List<GameData> GetPlayerGames(int playerId);
    }

    public class GameService : GameInterfaceService
    {
        private readonly GameInterface gameRepository;

        public GameService(GameInterface gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public void PlayGame(Player player, Game game, string OpponentName, bool result)
        {
            
            int gameRating = game.CountRating(result);
            int TypePlayer_Rating = 0;
            if (gameRating != 0) 
            {
                TypePlayer_Rating = player.changeRating.ChangedRating(result);
            } 

            if (result != true && result != false)
            {
                throw new ArgumentException("Result must be 'Win' or 'Lose'.");
            }

            player.CurrentRating += gameRating + TypePlayer_Rating;

            if (player.CurrentRating < 0)
            {
                throw new ArgumentException("Rating cannot be negative");
            }

            string finalresult = result ? "Win" : "Lose";
            var gameResult = new GameData(player.PlayerId, OpponentName, gameRating, finalresult);
            gameRepository.CreateGame(gameResult);
        }

        public List<GameData> GetAllGames()
        {
            return gameRepository.ReadGames();
        }

        public List<GameData> GetPlayerGames(int playerId)
        {
            return gameRepository.ReadPlayerGamesByPlayerId(playerId);
        }

    }
}