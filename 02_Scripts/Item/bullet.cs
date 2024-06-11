using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
  
    public int damage =0;

    private void OnEnable()
    {
        StartCoroutine(Destroy());
        
    }
        public void OnTriggerEnter(Collider other)
    {
        if(((1<<other.gameObject.layer) & layerMask) != 0)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnHit(damage);
            Vector3 destroyPosition = other.ClosestPoint(transform.position);
            DestroyBullet();
            }
        }
       
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(3.5f);
      
        DestroyBullet();
    }

    public void DestroyBullet()
    {
        //TODO ObjectPool
        gameObject.SetActive(false);
    }
}
