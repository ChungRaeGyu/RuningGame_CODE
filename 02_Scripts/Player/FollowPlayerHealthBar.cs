using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayerHealthBar : MonoBehaviour
{
    public LayerMask layerMask;

    // 최대 체력

    public float maxHealth;

    // 현재 체력
    public float currentHealth;

    // 슬라이더 컴포넌트 
    public Slider healthSlider;


    void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;

        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // 피해를 입음
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
