using UnityEngine;

[CreateAssetMenu(fileName ="Stage",menuName = "NewStage",order =1)]
public class StageData : ScriptableObject
{
    public int stageNum;
    public int monsterCount;
    public GameObject[] obstacle;
}
