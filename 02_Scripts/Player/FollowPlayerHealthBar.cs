using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayerHealthBar : MonoBehaviour
{
    public LayerMask layerMask;

    // �ִ� ü��

    public float maxHealth;

    // ���� ü��
    public float currentHealth;

    // �����̴� ������Ʈ 
    public Slider healthSlider;


    void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;

        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ���ظ� ����
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //GameManager_CH.Instance.DamageEvent();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerMask) != 0)
        {
            TakeDamage(5f); // Fix

            if (other.TryGetComponent<ObstacleBarrel>(out ObstacleBarrel obs))
            {
                Destroy(obs.gameObject);
            }
        }
    }
}
