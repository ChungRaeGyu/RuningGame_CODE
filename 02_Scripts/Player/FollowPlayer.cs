using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 5f; 
    public Transform playerTransform;
    private bool isMove = true;
    public float stoppingDistance = 0.2f;
    private float maxDistance = 1f;
    public float sphereRadius = 0.2f;
    private Rigidbody rigid;
    public LayerMask layer;
    private RaycastHit hit;
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody>();
        layer = LayerMask.GetMask("Player","CopyPlayer");
    }

    private void Update()
    {
        if (playerTransform != null && isMove)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > stoppingDistance)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            if (Physics.SphereCast(transform.position, sphereRadius, direction, out hit, maxDistance, layer))
            {
                Debug.DrawLine(transform.position, hit.point, Color.blue);
                rigid.constraints = RigidbodyConstraints.FreezeAll;
                isMove = false;
            }
            else
            {
                transform.position += direction * speed * Time.deltaTime;
            }
        }
        else
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;
            isMove = false;
        }

    }


}
