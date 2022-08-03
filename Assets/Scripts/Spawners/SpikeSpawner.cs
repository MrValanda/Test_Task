using UnityEngine;

[CreateAssetMenu(menuName = "Spawners/Spike Spawner")]
public class SpikeSpawner : ObjectSpawner
{
    [SerializeField] private Spike _spikeTemplate;
    
    public override void SpawnObject(Vector3 position, Quaternion rotation)
    {
        var instantiate = Instantiate(_spikeTemplate, position, rotation);
        _objectSpawned?.Invoke(instantiate.gameObject);
    }
}
