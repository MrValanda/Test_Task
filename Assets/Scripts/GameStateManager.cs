using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private UnityEvent _playerWin;
    [SerializeField] private UnityEvent _playerLose;

    private void OnEnable()
    {
        _coinManager.CoinCollected += OnCoinCollected;
        _playerHealth.PlayerDie += OnPlayerDie;
    }

    private void OnDisable()
    {
        _coinManager.CoinCollected -= OnCoinCollected;
        _playerHealth.PlayerDie -= OnPlayerDie;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnCoinCollected()
    {
        if (_coinManager.CanWin) _playerWin?.Invoke();
    }

    private void OnPlayerDie()
    {
        _playerLose?.Invoke();
    }
}
