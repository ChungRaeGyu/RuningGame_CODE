using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject uniqueEnemyPrefab;
    public GameObject enemySPrefab;
    public GameObject enemyMPrefab;
    public GameObject enemyLPrefab;
    public GameObject bulletPrefab;

    GameObject[] uniqueEnemy;
    GameObject[] enemyS;
    GameObject[] enemyM;
    GameObject[] enemyL;
    GameObject[] bullets;

    GameObject[] targetPool;

    private void Awake() 
    {
        GameManager_CH.Instance.objectManager = this;
        uniqueEnemy = new GameObject[1];
        enemyS = new GameObject[100];
        enemyM = new GameObject[100];
        enemyL = new GameObject[100];
        bullets = new GameObject[1000];
        Generate();
    }

    void Generate()
    {
        // Enemy
        for (int i = 0; i < uniqueEnemy.Length; i++)
        {
            uniqueEnemy[i] = Instantiate(uniqueEnemyPrefab);
            uniqueEnemy[i].SetActive(false);
        }
        for (int i = 0; i < enemyS.Length; i++)
        {
            enemyS[i] = Instantiate(enemySPrefab);
            enemyS[i].SetActive(false);
        }
        for (int i = 0; i < enemyM.Length; i++)
        {
            enemyM[i] = Instantiate(enemyMPrefab);
            enemyM[i].SetActive(false);
        }
        for (int i = 0; i < enemyL.Length; i++)
        {
            enemyL[i] = Instantiate(enemyLPrefab);
            enemyL[i].SetActive(false);
        }
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = Instantiate(bulletPrefab);
            bullets[i].SetActive(false);
        }
    }
    public GameObject Activatebullet() 
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }

        }

       
    
        return null;
    }
    public GameObject ActivateObject(string type)
    {
        switch (type)
        {
            case "uniqueEnemy":
                targetPool = uniqueEnemy;
                break;
            case "enemyS":
                targetPool = enemyS;
                break;
            case "enemyM":
                targetPool = enemyM;
                break;
            case "enemyL":
                targetPool = enemyL;
                break;
        }

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }

        return null;
    }
}
