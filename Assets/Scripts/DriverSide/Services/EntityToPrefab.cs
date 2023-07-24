using DriverSide.Views;
using UnityEngine;

namespace DriverSide.Services
{
    [CreateAssetMenu(fileName = "GamePrefabs", menuName = "Custom SO/Game Prefabs Dictionary")]
    public class EntityToPrefab : ScriptableObject
    {
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private GameObject _obstaclePrefab;


        public PlayerView PlayerPrefab => _playerPrefab;
        public GameObject ObstaclePrefab => _obstaclePrefab;
    }
}