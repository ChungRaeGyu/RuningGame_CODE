using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObject;
    public Transform[] spawnPoints;
    public ObjectManager objectManager;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public int curEnemyCnt = 0;


    private void Update() 
    {
        if(!GameManager_CH.Instance.isStart)return;
        if(curEnemyCnt < GameManager_CH.Instance.stageData.monsterCount-1)
        {
            curSpawnDelay += Time.deltaTime;

            if(curSpawnDelay > maxSpawnDelay)
            {
                SpawnEnemy();
                curEnemyCnt++;

                curSpawnDelay = 0;
            }
        }
        else if(curEnemyCnt == GameManager_CH.Instance.stageData.monsterCount-1) // 추후에 일반몬스터를 다 없애고 나오는걸로 변경
        {
            SpawnEnemy();
            curEnemyCnt++;
        }    
    }

    void SpawnEnemy()
    {
        int ranPoint = Random.Range(0, 3);
        int ranEnemy = Random.Range(0, 3);
        
        // 보스몬스터 추가
        if(curEnemyCnt == GameManager_CH.Instance.stageData.monsterCount-1)
        {
            ranEnemy = 3;
        }
        
        GameObject rtnEnemy = objectManager.ActivateObject(enemyObject[ranEnemy].GetComponent<Enemy>().enemySO.name);

        rtnEnemy.transform.position = spawnPoints[ranPoint].position;
        rtnEnemy.transform.rotation = spawnPoints[ranPoint].rotation;
    }
}
