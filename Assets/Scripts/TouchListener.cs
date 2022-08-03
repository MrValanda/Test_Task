using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class TouchListener : MonoBehaviour
{
    [SerializeField] private float _delayAfterTouch;
    [SerializeField] private float _timeBetweenClicks;
    [SerializeField] private List<TouchPhase> _touchPhases;
    [SerializeField] private UnityEvent<Vector3> _sequentialClick;
    [SerializeField] private UnityEvent<Vector3> _singleClick;
    
    public event UnityAction<Vector3> SequentialClick
    {
        add => _sequentialClick.AddListener(value);
        remove => _sequentialClick.RemoveListener(value);
    }
    
    public event UnityAction<Vector3> SingleClick
    {
        add => _singleClick.AddListener(value);
        remove => _singleClick.RemoveListener(value);
    }

    private float _timeLastClick;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (_touchPhases.Contains(touch.phase) == false) return;
            
            float timeSinceLastClick = Time.time - _timeLastClick;
            if (timeSinceLastClick > _timeBetweenClicks)
            {

                if (timeSinceLastClick <= _delayAfterTouch)
                {
                    _sequentialClick?.Invoke(touch.position);
                }
                else
                {
                    _singleClick?.Invoke(touch.position);
                }

                _timeLastClick = Time.time;
            }
        }
    }
}
