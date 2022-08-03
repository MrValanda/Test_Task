using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _minDistanceBetweenMovePoint;
   [SerializeField] private TouchListener _touchListener;

   public readonly List<Vector2> Path=new List<Vector2>();
   
   private Rigidbody2D _rigidbody2D;
   private Camera _camera;

   private void OnEnable()
   {
      _touchListener.SequentialClick += OnSequentialClick;
      _touchListener.SingleClick += OnSingleClick;
   }
   private void OnDisable()
   {
      _touchListener.SequentialClick -= OnSequentialClick;
      _touchListener.SingleClick -= OnSingleClick;
   }

   private void Start()
   {
      _rigidbody2D = GetComponent<Rigidbody2D>();
      _camera=Camera.main;
   }

   private void Update()
   {
      if (Path.Count == 0) return;

      if (Vector2.Distance(transform.position, Path[0]) <= _minDistanceBetweenMovePoint)
      {
         Path.RemoveAt(0);
      }

      Move();
   }

   private void Move()
   {
      if (Path.Count == 0) return;

      Vector3 newPosition = Vector3.MoveTowards(transform.position, Path[0], _moveSpeed * Time.deltaTime);
      _rigidbody2D.MovePosition(newPosition);
   }

   
   private void OnSequentialClick(Vector3 clickPosition)
   {
      Path.Add(_camera.ScreenToWorldPoint(clickPosition));
   }

   private void OnSingleClick(Vector3 clickPosition)
   {
      Path.Clear();
      Path.Add(_camera.ScreenToWorldPoint(clickPosition));
   }
}
