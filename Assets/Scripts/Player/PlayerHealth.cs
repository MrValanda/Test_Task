using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private UnityEvent _playerDie;
    
    public event UnityAction PlayerDie
    {
        add => _playerDie.AddListener(value);
        remove => _playerDie.RemoveListener(value);
    }
    
    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void ApplyDamage(uint damage)
    {
        _health = Mathf.Max(0, _health - damage);
        if (_health == 0)
            _playerDie?.Invoke();
    }
}
