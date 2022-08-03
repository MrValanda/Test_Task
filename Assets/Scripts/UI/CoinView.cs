using UnityEngine;
using UnityEngine.UI;

public class CoinView : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private Text _coinText;

    private void Start()
    {
        OnCoinCollected();
    }

    private void OnEnable()
    {
        _coinManager.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _coinManager.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        _coinText.text = $"{_coinManager.CountCollectedCoins} / {_coinManager.NumberCoinsToWin}";
    }
}
