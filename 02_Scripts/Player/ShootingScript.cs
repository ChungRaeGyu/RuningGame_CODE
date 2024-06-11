using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // �Ѿ� ������
    public GameObject bulletPrefab;
    private ObjectManager objectManager;
    private AudioSource audioSource;

    // �Ѿ� �ӵ�
    public float bulletSpeed;

    // �� ���� ������Ʈ �±�
    public LayerMask layerMask;

    // �Ѿ� �߻� �Ÿ�
    public float shootingDistance;


    float attackCoolTime=0.2f;
    float timer;

    private void Awake() 
    {
         audioSource = gameObject.GetComponent<AudioSource>();    
    }

    void Start(){
        objectManager = GameManager_CH.Instance.objectManager;
    }

    void Update()
    {
        // �÷��̾� �ֺ� �� ����
        DetectAndShootEnemy();
        Debug.DrawRay(transform.position + new Vector3(0, 0.4f, 0), transform.forward * 100, Color.red);

        timer += Time.deltaTime;

    }

    // �÷��̾� �ֺ� �� ���� �� �߻� �Լ�
    void DetectAndShootEnemy()
    {
        // ���� ���� ����
        float detectionAngle = 45f; // ������ ���� (��: 45��)

        // ���� �߻� ������ ���� ����
        Vector3 rayOrigin = transform.position + new Vector3(0, 0.4f, 0); // ���� �߻� ��ġ
        Vector3 forward = transform.forward; // ���� ����

        // ���� �߰��� ��츦 ��Ÿ���� ����
        bool enemyDetected = false;

        // ���� ������ ���� �߻��Ͽ� ����
        for (float angle = -detectionAngle / 2; angle <= detectionAngle / 2; angle += 5f)
        {
            // ���� ������ ���� ���� ���
            Quaternion rotation = Quaternion.AngleAxis(angle, transform.up);
            Vector3 direction = rotation * forward;

            // ���� ����
            Ray ray = new Ray(rayOrigin, direction);

            // ���� ���
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, shootingDistance, layerMask))
            {
                // ���� �߰��ϸ� �� �߻�
                if (hitInfo.collider.gameObject.layer == 7 || hitInfo.collider.gameObject.layer == 8)
                {
                    if (timer >= attackCoolTime)
                    {
                        audioSource.Play();
                        Shoot(hitInfo.transform.gameObject);

                        timer = 0;

                    }
                    Debug.Log("�� �߰�!");
                    enemyDetected = true; // ���� �߰������� ǥ��
                }
            }
        }
    }

    // �� �߻� �Լ�
    void Shoot(GameObject enemyObject)
    {
        // �Ѿ� ���� �� �ʱ� ��ġ ����
        GameObject bullet = objectManager.Activatebullet();
        bullet.transform.position = transform.position + new Vector3(0, 0.4f, 0);

        //Instantiate(bulletPrefab, , Quaternion.identity);
        // �Ѿ� ���� ����
        Vector3 shootDirection = (enemyObject.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
    }
}

