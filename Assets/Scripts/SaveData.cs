using System.Collections.Generic;

[System.Serializable]
public class UpgradeSaveData
{
    public string upgradeName;
    public int level;
}

[System.Serializable]
public class BalanceSaveData
{
    public double balance;
    public List<UpgradeSaveData> buildings = new List<UpgradeSaveData>();
}