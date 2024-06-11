using System;
using System.Collections.Generic;

[Serializable]
public class AchievementData
{
    public string name;
    public string description;
    public List<int> maxCount;
    public Type id;
    public bool clear = false;
    public int level=0;
    public int curCount=0;

    public AchievementData(string name, string description, List<int> maxCount, Type id)
    {
        this.name = name;
        this.description = description;
        this.maxCount = maxCount;
        this.id = id;
    }
}
