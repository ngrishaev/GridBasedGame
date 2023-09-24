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
            var playerMover = new PlayerMover(level.Player, level.GameEntities);
            var playerAttacker = new PlayerAttacker(level.Player, level.GameEntities);
            _input.Construct(playerMover, playerAttacker);
            
            SpawnPlayer(level);
            SpawnObstacles(level);
            SpawnBoxes(level);
        }

        private void SpawnBoxes(Level level)
        {
            var boxPrefab = _entityToPrefab.Box;
            foreach (var box in level.Boxes)
            {
                var boxView = Instantiate(boxPrefab);
                boxView.Construct(box);
                boxView.Draw();
                box.Moved += boxView.Draw;
                box.Death += boxView.DeathHandler;
            }
        }

        private void SpawnObstacles(Level level)
        {
            var obstaclePrefab = _entityToPrefab.ObstaclePrefab;
            foreach (var obstacle in level.Obstacles)
            {
                var obstacleView = Instantiate(obstaclePrefab);
                obstacleView.Construct(obstacle);
                obstacleView.Draw();
            }
        }

        private void SpawnPlayer(Level level)
        {
            var playerPrefab = _entityToPrefab.PlayerPrefab;
            var playerView = Instantiate(playerPrefab);
            playerView.Construct(level.Player);
            playerView.Draw();
            level.Player.Moved += playerView.Draw;
        }
    }
}
