using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectStat
{
    public int maxValue;
    public AttackSO attackSO;
}
public class ObstacleBarrel : Item
{
    //[SerializeField] private ObjectStat objectStat;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject dropItem;

    private int currentValue;
    private int maxValue;

    public override void Awake()
    {
        base.Awake();

        maxValue = Random.Range(1, 10);

        currentValue = maxValue;
        text.text = maxValue.ToString();
    }

    public override void ItemEffect(Collider other)
    {
        base.ItemEffect(other);

        if(currentValue > 0)
        {
            currentValue --;
            UpdateText();
        }
        
        if(currentValue <= 0)
        {
            GameObject ob = Instantiate(dropItem, this.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);

            ob.transform.SetParent(this.transform.parent, true);
            Destroy(this.gameObject);
        }
    }

    private void UpdateText()
    {
        if(text != null)
        {
            text.text = currentValue.ToString();
        }
    }
}
