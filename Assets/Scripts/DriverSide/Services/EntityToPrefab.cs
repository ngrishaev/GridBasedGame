using DriverSide.Views;
using UnityEngine;

namespace DriverSide.Services
{
    [CreateAssetMenu(fileName = "GamePrefabs", menuName = "Custom SO/Game Prefabs Dictionary")]
    public class EntityToPrefab : ScriptableObject
    {
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private ObstacleView _obstaclePrefab;
        [SerializeField] private BoxView _box;


        public PlayerView PlayerPrefab => _playerPrefab;
        public ObstacleView ObstaclePrefab => _obstaclePrefab;
        public BoxView Box => _box;
        
        
    }
}