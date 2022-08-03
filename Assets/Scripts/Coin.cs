using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent<Coin> _coinCollected;

    public event UnityAction<Coin> CoinCollected
    {
        add => _coinCollected.AddListener(value);
        remove => _coinCollected.RemoveListener(value);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Movement _))
        {
            _coinCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
