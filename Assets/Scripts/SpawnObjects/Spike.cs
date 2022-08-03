using UnityEngine;

public class Spike : MonoBehaviour
{
   [SerializeField] private uint _damage;
   
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
      {
         playerHealth.ApplyDamage(_damage);
         Destroy(gameObject);
      } 
   }
}
