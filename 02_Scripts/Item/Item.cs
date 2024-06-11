using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction
{    public void GetItemEffect(Collider other);
}

public class Item : MonoBehaviour, IInteraction
{
    [SerializeField] protected ItemDataSO itemData;
    [SerializeField] protected LayerMask layerMask;


    public virtual void Awake()
    {
        
    }

    public void GetItemEffect(Collider other)
    {
        ItemEffect(other);
        //Destroy(gameObject);
    }

    public virtual void ItemEffect(Collider other){}
    
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerMask) != 0)
        {
            GetItemEffect(other);
            
        }
    }
}
