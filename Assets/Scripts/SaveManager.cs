using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private StoreManager storeManager;

    [SerializeField] private List<Upgrade> allUpgrades;

    private void Start()
    {
        LoadGame();
    }

    private void SaveGame()
    {
        BalanceSaveData data = new BalanceSaveData
        {
            balance = storeManager.exactBalance,
        };

        foreach (Upgrade upgrade in allUpgrades)
        {
            UpgradeSaveData upgradeData = new UpgradeSaveData
            {
                upgradeName = upgrade.nameOfUpgrade,
                level = upgrade.levelNumber
            };
            data.buildings.Add(upgradeData);
        }

        SaveSystem.Save(data);
    }

    private void LoadGame()
    {
        BalanceSaveData data = SaveSystem.Load();

        storeManager.exactBalance = data.balance;

        foreach (UpgradeSaveData savedUpgrade in data.buildings)
        {
            Upgrade target = allUpgrades.Find(u => u.nameOfUpgrade == savedUpgrade.upgradeName);
            
            if (target != null)
            {
                target.levelNumber = savedUpgrade.level;
            }
        }
        
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveGame();
        }
    }
}
