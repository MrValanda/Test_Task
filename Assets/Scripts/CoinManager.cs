using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    [field: SerializeField] public int NumberCoinsToWin { get; private set; }

    [SerializeField] private UnityEvent _coinCollected;
    
    public event UnityAction CoinCollected
    {
        add => _coinCollected.AddListener(value);
        remove => _coinCollected.RemoveListener(value);
    }
    public int CountCollectedCoins { get; private set; }

    public bool CanWin => CountCollectedCoins >= NumberCoinsToWin;
    
    private void OnValidate()
    {
        NumberCoinsToWin = Mathf.Clamp(NumberCoinsToWin, 0, _coinSpawner.NumberSpawnObject);
    }
    private void OnEnable()
    {
        _coinSpawner.ObjectSpawned += OnObjectSpawned;
    }

    private void OnDisable()
    {
        _coinSpawner.ObjectSpawned -= OnObjectSpawned;
    }

    private void OnObjectSpawned(GameObject spawnedObject)
    {
        var coin = spawnedObject.GetComponent<Coin>();
        coin.CoinCollected += OnCoinCollected;
    }

    private void OnCoinCollected(Coin coin)
    {
        CountCollectedCoins++;
        _coinCollected?.Invoke();
    }
}
