using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] obstacleObj;

    private void Awake()
    {
        if (GameManager_CH.Instance.stageData.obstacle.Length > 0)
        {
            obstacleObj = GameManager_CH.Instance.stageData.obstacle;
        }
    }

    private void OnEnable()
    {
        if(obstacleObj.Length > 0) 
        {
            if (Random.value > 0.9f)
                return;

            int count = Random.Range(0, 3);

            for (int i = 0; i < count; i++)
            {
                int spawnValue = Random.Range(0, spawnPoints.Length);
                int objValue = Random.Range(0, obstacleObj.Length);
                if (spawnPoints[spawnValue].childCount == 0)
                {
                    GameObject obj = Instantiate(obstacleObj[objValue]);
                    obj.transform.SetParent(spawnPoints[spawnValue], false);
                }
            }
        }
    }

    private void OnDisable()
    {
        foreach (var spawn in spawnPoints)
        {
            if (spawn.childCount != 0)
                Destroy(spawn.GetChild(0).gameObject);
        }
    }
}
