using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  
    public AttackSO enemySO;
    public Animator animator;
    public Slider healthSlider;
    public float curHealth;
    public float maxHealth;


    private Transform player;
    Rigidbody rigid;
    private void Awake() 
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        curHealth=enemySO.health;
        maxHealth = enemySO.health;


   
    }

    private void Update() 
    {
        ChasePlayer();
    }

   public void OnHit(int damage)
    {
        curHealth -= damage;
        healthSlider.value = curHealth/ maxHealth;
        Invoke("ReturnSprite", 0.1f);

        if (curHealth <= 0)
        {
            Debug.Log("맞았다");
            GameManager_CH.Instance.curMonster--;
            GameManager_CH.Instance.achievementManager_CH.MonsterKilled();
            GameManager_CH.Instance.curScore++;
            gameObject.SetActive(false);
            
        }
    }

    void ChasePlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 플레이어 따라서 이동
        if (distanceToPlayer > enemySO.stoppingDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            rigid.MovePosition(transform.position + direction * enemySO.speed * Time.deltaTime);
            animator.SetFloat("MoveSpeed", enemySO.speed);
        }
    }

    void OnCollisionEnter(Collision target) 
    {
        if(target.gameObject.CompareTag("Player"))
        {
            Debug.Log("부딪힘");
            animator.SetTrigger("Attack");
        }
    }

    private void OnDisable()
    {
        healthSlider.value = enemySO.health;
        curHealth =maxHealth;
    }
}
