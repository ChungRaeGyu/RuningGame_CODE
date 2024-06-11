using UnityEngine;

public enum EItemType
{
    REINFORCE,
    EARN,
}

[CreateAssetMenu(fileName = "Item", menuName = "Item",  order = 0)]
public class ItemDataSO : ScriptableObject
{
    public int value = 0;
    public EItemType type;
}
