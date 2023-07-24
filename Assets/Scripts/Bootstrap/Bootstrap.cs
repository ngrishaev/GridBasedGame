using DriverSide.Services;
using Game;
using UnityEngine;
using Input = DriverSide.Input;

namespace Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Input _input;
        [SerializeField] private EntityToPrefab _entityToPrefab;
        
        private void Start()
        {
            var game = new Game.Game();
            var playerMover = new PlayerMoveProcessor(game.Player, game.GameEntities);
            _input.Construct(playerMover);
            
            var playerPrefab = _entityToPrefab.PlayerPrefab;
            var playerView = Instantiate(playerPrefab);
            playerView.Construct(game.Player);
            playerView.Redraw();
            
            game.Player.Moved += playerView.Redraw;
        }
    }
}
