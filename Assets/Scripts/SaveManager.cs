using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private StoreManager storeManager;
    [SerializeField] private List<Upgrade> allUpgrades;
    [SerializeField] private List<ClickUpgrade> allClickUpgrades;
    

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
            data.upgrades.Add(upgradeData);
        }

        foreach (ClickUpgrade clickUpgrade in allClickUpgrades)
        {
            ClickUpgradeSaveData clickUpgradeData = new ClickUpgradeSaveData
            {
                clickUpgradeName = clickUpgrade.nameOfClickUpgrade,
                isPurchased = clickUpgrade.isPurchased,
            };
            data.clickUpgrades.Add(clickUpgradeData);
        }

        SaveSystem.Save(data);
    }

    private void LoadGame()
    {
        BalanceSaveData data = SaveSystem.Load();

        storeManager.exactBalance = data.balance;

        foreach (UpgradeSaveData savedUpgrade in data.upgrades)
        {
            Upgrade target = allUpgrades.Find(u => u.nameOfUpgrade == savedUpgrade.upgradeName);
            
            if (target != null)
            {
                target.levelNumber = savedUpgrade.level;
            }
        }
        
        foreach (ClickUpgradeSaveData savedClickUpgrade in data.clickUpgrades)
        {
            ClickUpgrade target = allClickUpgrades.Find(u => u.nameOfClickUpgrade == savedClickUpgrade.clickUpgradeName);
            
            if (target != null)
            {
                target.isPurchased = savedClickUpgrade.isPurchased;
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
