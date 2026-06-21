using System.Collections.Generic;

[System.Serializable]
public class UpgradeSaveData
{
    public string upgradeName;
    public int level;
}

[System.Serializable]
public class ClickUpgradeSaveData
{
    public string clickUpgradeName;
    public bool isPurchased;
}

[System.Serializable]
public class BalanceSaveData
{
    public double balance;
    public List<UpgradeSaveData> upgrades = new List<UpgradeSaveData>();
    public List<ClickUpgradeSaveData> clickUpgrades = new List<ClickUpgradeSaveData>();
}