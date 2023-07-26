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
            var level = game.Level;
            var playerMover = new PlayerMoveProcessor(level.Player, level.GameEntities);
            _input.Construct(playerMover);
            
            var playerPrefab = _entityToPrefab.PlayerPrefab;
            var playerView = Instantiate(playerPrefab);
            playerView.Construct(level.Player);
            playerView.Draw();
            
            var obstaclePrefab = _entityToPrefab.ObstaclePrefab;
            foreach (var obstacle in level.Obstacles)
            {
                var obstacleView = Instantiate(obstaclePrefab);
                obstacleView.Construct(obstacle);
                obstacleView.Draw();
            }
            
            level.Player.Moved += playerView.Draw;
        }
    }
}
