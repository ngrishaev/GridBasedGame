using DriverSide.Views;
using UnityEngine;

namespace DriverSide.Services
{
    [CreateAssetMenu(fileName = "GamePrefabs", menuName = "Custom SO/Game Prefabs Dictionary")]
    public class EntityToPrefab : ScriptableObject
    {
        [SerializeField] private PlayerView _playerPrefab;


        public PlayerView PlayerPrefab => _playerPrefab;
    }
}