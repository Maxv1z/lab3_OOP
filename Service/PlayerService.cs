
namespace MyGame
{
    // Інтерфейс сервісу для гравців
    public interface PlayerInterfaceService
    {
        void CreatePlayer(string playerName, int initialRating, PlayerType playerType);
        List<Player> GetPlayers();
        Player GetPlayerById(int playerId);
    }


    public class PlayerService : PlayerInterfaceService
    {
        private readonly PlayerRepository playerRepository;

        public PlayerService(PlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public void CreatePlayer(string playerName, int initialRating, PlayerType playerType)
        {
            var player = new Player { PlayerName = playerName, CurrentRating = initialRating, changeRating = playerType };
            playerRepository.CreatePlayer(player);
        }

        public List<Player> GetPlayers()
        {
            return playerRepository.ReadPlayers();
        }

        public Player GetPlayerById(int playerId)
        {
            return playerRepository.ReadPlayerById(playerId);
        }

    }


}