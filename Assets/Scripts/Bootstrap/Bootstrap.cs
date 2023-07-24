using DriverSide.Services;
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
            _input.Construct(game.Player);
            
            var playerPrefab = _entityToPrefab.PlayerPrefab;
            var playerView = Instantiate(playerPrefab);
            playerView.Construct(game.Player);
            playerView.Redraw();
            game.Player.Moved += playerView.Redraw;
        }
    }
}
