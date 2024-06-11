using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Item
{
    public AudioSource audioSource;
    private MeshRenderer renderer;
    [SerializeField] private GameObject particleObj;

    private int value = 3;
    public override void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        renderer= GetComponent<MeshRenderer>();
    }
    public override void ItemEffect(Collider other)
    {
        base.ItemEffect(other);
        if(other.TryGetComponent<ShootingScript>(out ShootingScript pl))
        {
            Debug.Log("ÃÑ È¹µæ!");
            audioSource.Play();
            pl.bulletSpeed += value;

            renderer.enabled = false;
            particleObj.SetActive(false);

            Invoke("DestroyGun", 1f);
        }
    }

    private void DestroyGun()
    {
        Destroy(this.gameObject);
    }

}
