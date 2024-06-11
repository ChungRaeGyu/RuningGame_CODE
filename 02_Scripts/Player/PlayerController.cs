using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   // public Slider healthSlider;
    private Vector2 curMovementInput;
    private Camera mainCamera;
    private float minX = -3f;
    private float maxX = 3f;
   
    private bool Ismouse = false;
    private HealthBar healthBar;


    private ShootingScript shoot;



    private void Awake()
    {
       
        healthBar = GetComponent<HealthBar>();
        shoot = GetComponent<ShootingScript>();
        mainCamera =Camera.main;
    }

    public void OnMouseClik(InputAction.CallbackContext context)
    {
        Vector2 mousePostition = context.ReadValue<Vector2>();
    }
   
    public void OnMoveMouse(InputAction.CallbackContext context)
    {
        if(Time.timeScale==0)return;
        if (context.phase == InputActionPhase.Performed)
        {
          
            curMovementInput = context.ReadValue<Vector2>();
            Ray ray = mainCamera.ScreenPointToRay(curMovementInput); //�浿����ġ 
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                
                float xpos = Mathf.Clamp(hit.point.x, minX, maxX);
                transform.position =new Vector3(xpos,transform.position.y,transform.position.z);
                
            }
          
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
           
        }
    }
    private bool isTakingDamage = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7 && !isTakingDamage)
        {
            isTakingDamage = true;
            StartCoroutine(ApplyDamageOverTime(10, 0.05f)); // ���ʸ��� 10�� �������� ������ �ڷ�ƾ ����
        }
    }

    private IEnumerator ApplyDamageOverTime(float damageAmount, float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            healthBar.TakeDamage(damageAmount);
            Debug.Log("�¾Ҵ�");
            // �������� ���� �� ���� �ð� ���� �������� ���� �ʵ��� isTakingDamage ���� false�� ����
            yield return new WaitForSeconds(interval);
            isTakingDamage = false;
        }
    }

    
}
