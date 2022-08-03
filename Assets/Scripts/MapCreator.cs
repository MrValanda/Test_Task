using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class MapCreator : MonoBehaviour
{
   [SerializeField] private List<ObjectSpawner> _spawners;
   [SerializeField] private Transform _startPoint;
   [SerializeField] private bool _checkDistanceBetweenObjects;
   [SerializeField] private float _minDistanceBetweenObjects = 1f;
   [SerializeField] private float _maxNumberIterations = 1f;

   private void Start()
   {
      if (_checkDistanceBetweenObjects)
      {
         GenerateMapWithCheckDistanceBetweenObjects();
      }
      else
      {
         GenerateMap();
      }
   }

   private void GenerateMapWithCheckDistanceBetweenObjects()
   {
      List<Vector3> previousPositions = new List<Vector3>();
      
      foreach (var spawner in _spawners)
      {
         for (var i = 0; i < spawner.NumberSpawnObject; i++)
         {
            Vector3 spawnPoint = _startPoint.position + spawner.GenerateRandomSpawnPointOffset();
            if (previousPositions.Count > 0)
            {
               int countIterations = 0;
               while (countIterations<=_maxNumberIterations && previousPositions.Any(x => Vector2.Distance(x, spawnPoint) <= _minDistanceBetweenObjects))
               {
                  spawnPoint =_startPoint.position + spawner.GenerateRandomSpawnPointOffset();
                  countIterations++;
               }
            }

            spawner.SpawnObject(spawnPoint, Quaternion.identity);
            previousPositions.Add(spawnPoint);
         }
      }
   }

   private void GenerateMap()
   {
      foreach (var spawner in _spawners)
      {
         spawner.SpawnObjects(_startPoint.position, Quaternion.identity);
      }
   }
}
