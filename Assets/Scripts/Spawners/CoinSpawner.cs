using UnityEngine;

[CreateAssetMenu(menuName = "Spawners/Coin Spawner")]
public class CoinSpawner : ObjectSpawner
{
    [SerializeField] private Coin _coinTemplate;
    
    public override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        var instantiate = Instantiate(_coinTemplate, position, rotation);
        _objectSpawned?.Invoke(instantiate.gameObject);
    }
}
