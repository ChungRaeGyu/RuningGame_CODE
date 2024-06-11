using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public event Action OnDamage; //Fix


    public LayerMask layerMask;

    // �ִ� ü��

    public float maxHealth;

    // ���� ü��
    public float currentHealth;

    // �����̴� ������Ʈ 
    public Slider healthSlider;

   
    void Start()
    {
        // ���� �� ���� ü���� �ִ� ü������ ����
        currentHealth = maxHealth;

        // �����̴��� �ִ� ���� �ִ� ü������ ����
        healthSlider.maxValue = maxHealth;

        // �����̴��� ���� ���� ���� ü������ ����
        healthSlider.value = currentHealth;
    }

    // ü�� ���� �Լ�
    public void TakeDamage(float damage) {
        currentHealth -= damage; // ���ظ� ����
        healthSlider.value = currentHealth;

        Debug.Log("���� �޴� ��");

        OnDamage?.Invoke();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager_CH.Instance.GameOver();
            Debug.Log("���");
        }
        // �����̴��� ���� ���� ���� ü������ ������Ʈ
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