using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fence : Item
{
    private int value;
    [SerializeField] private GameObject obj;
    [SerializeField] private bool inequality;
    [SerializeField] private TextMeshProUGUI text;

    public override void Awake()
    {
        base.Awake();

        text = GetComponentInChildren<TextMeshProUGUI>();

        do
        {
            value = Random.Range(-5, 6);
        }
        while (value == 0);

        inequality = value > 0;
    }

    private void Start()
    {
        text.text = value.ToString();
    }
    public override void ItemEffect(Collider other)
    {
        if(inequality)
        {
            IncreasePlayerList(other);
        }
        else
        {
            DecreasePlayerList(other);
        }
    }

    private void IncreasePlayerList(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player pl))
        {
            for (int i = 0; i < value; i++)
            {
                //pl.playerList.Add(obj);
                //float randomAngle = Random.Range(Mathf.PI / 2, 3 * Mathf.PI / 2);
                //Vector3 randomDir = new Vector3(Mathf.Cos(randomAngle), 0, -Mathf.Sin(randomAngle)) * 5f;
                Vector3 randomPoint = Random.insideUnitSphere;

                if (randomPoint.z > 0)
                {
                    randomPoint.z = -randomPoint.z;
                }
                randomPoint.y = 0;
                randomPoint *= 5;
                Vector3 pos = pl.transform.position + randomPoint;
                GameObject ob = Instantiate(obj, pos,Quaternion.identity);
                pl.playerList.Add(ob);
                ob.transform.SetParent(pl.playerGroup);

                FollowPlayer follow = ob.AddComponent<FollowPlayer>();
                follow.playerTransform = pl.transform;
            }
        }
    }

    private void DecreasePlayerList(Collider other)
    {

        //if (other.TryGetComponent<Player>(out Player pl))
        //{
        //    int newValue = Mathf.Abs(value);
        //    int childrenToRemove = Mathf.Min(newValue, pl.playerList.Count);

        //    for (int i = childrenToRemove - 1; i >= 0; i--)
        //    {
        //        if (pl.playerList.Count > i)
        //        {
        //            GameObject child = pl.playerList[i];
        //            pl.playerList.RemoveAt(i);
        //            Destroy(child);
        //        }
        //    }
        //}


        if (other.TryGetComponent<Player>(out Player pl))
        {
            int newValue = Mathf.Abs(value);

            if (pl.playerList.Count > 0)
            {
                //int indexToRemove = Mathf.Clamp(newValue, 0, pl.playerList.Count - 1);
                //pl.playerList.RemoveAt(indexToRemove);

                Transform playerTransform = pl.playerGroup;
                int childrenToRemove = Mathf.Min(newValue, playerTransform.childCount);

                for (int i = childrenToRemove - 1; i >= 0; i--)
                {
                    //pl.playerList.RemoveAt(i);
                    //Destroy(playerTransform.GetChild(0).gameObject);
                    GameObject child = pl.playerList[i];
                    pl.playerList.RemoveAt(i);
                    Destroy(child);
                }
            }
        }

    }
}
