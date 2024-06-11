using UnityEngine;

[CreateAssetMenu(fileName = "AchievementDataSO", menuName = "newAchievementDataSO", order = 4)]
public class AchievementDataSO : ScriptableObject 
{
    public string name;
    public string description;
    public bool clear;
    public int[] maxCount;
    public int curCount;
    public int level;
}
