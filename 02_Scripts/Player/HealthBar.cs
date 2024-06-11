using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public event Action OnDamage; //Fix


    public LayerMask layerMask;

    // 최대 체력

    public float maxHealth;

    // 현재 체력
    public float currentHealth;

    // 슬라이더 컴포넌트 
    public Slider healthSlider;

   
    void Start()
    {
        // 시작 시 현재 체력을 최대 체력으로 설정
        currentHealth = maxHealth;

        // 슬라이더의 최대 값을 최대 체력으로 설정
        healthSlider.maxValue = maxHealth;

        // 슬라이더의 현재 값을 현재 체력으로 설정
        healthSlider.value = currentHealth;
    }

    // 체력 감소 함수
    public void TakeDamage(float damage) {
        currentHealth -= damage; // 피해를 입음
        healthSlider.value = currentHealth;

        Debug.Log("공격 받는 중");

        OnDamage?.Invoke();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager_CH.Instance.GameOver();
            Debug.Log("사망");
        }
        // 슬라이더의 현재 값을 현재 체력으로 업데이트
    }

    private void OnTriggerEnter(Collider other)
    {
        if(((1 << other.gameObject.layer) & layerMask) != 0)
        {
            TakeDamage(10f); // Fix

            if(other.TryGetComponent<ObstacleBarrel>(out ObstacleBarrel obs))
            {
                Destroy(obs.gameObject);
            }
        }
    }

}