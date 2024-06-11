using System;
using System.Collections.Generic;

[Serializable]
public class Data{
    //PlayerData
    public int atk;
    public int def;
    public int level;
    public int[] maxExp = {10,20,30,40,50};//5레벨까지 있다고 생각.
    public float exp;
    //stage
    public bool[] stages = {false,false,false};
    public List<AchievementData> achievementData;
    //업적
    // 이름 , 클리어 조건, 클리어 여부, 종류
}