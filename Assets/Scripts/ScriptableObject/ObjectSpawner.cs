using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectSpawner : ScriptableObject
{
   [SerializeField] protected UnityEvent<GameObject> _objectSpawned;
   
   [SerializeField] protected Vector3 _maxOffset;
   [SerializeField] protected Vector3 _minOffset;
   
   [field: SerializeField] public int NumberSpawnObject;


   public event UnityAction<GameObject> ObjectSpawned
   {
      add => _objectSpawned.AddListener(value);
      remove => _objectSpawned.RemoveListener(value);
   }

   public virtual void SpawnObjects(Vector3 startPosition, Quaternion rotation)
   {
      for (int i = 0; i < NumberSpawnObject; i++)
      {
         SpawnObject(startPosition+GenerateRandomSpawnPointOffset(), rotation);
      }
   }

   public virtual Vector3 GenerateRandomSpawnPointOffset()
   {
      float offsetX = Random.Range(_minOffset.x, _maxOffset.x);
      float offsetY = Random.Range(_minOffset.y, _maxOffset.y);
            
      Vector3 offset = new Vector3(offsetX, offsetY);
      return offset;
   }

   public abstract void SpawnObject(Vector3 position, Quaternion rotation);
}
