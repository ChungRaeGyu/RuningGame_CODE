using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    public float power;
    public LayerMask terget;

    public string name;
    public float health;
    public float speed;
    public float stoppingDistance;
}
