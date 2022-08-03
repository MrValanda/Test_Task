using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    private void Update()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
