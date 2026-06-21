using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private Upgrade[] upgrades;
    [SerializeField] private ClickUpgrade[] clickUpgrades;
    [SerializeField] private TMP_Text balanceText;
    [SerializeField] private long pointsPerSecond;
    
    public long pointsPerClick;
    public double exactBalance;
    public long currentBalance;
    
    
    private void Update()
    {
        pointsPerSecond = 0;
        foreach (Upgrade upgrade in upgrades)
        {
            pointsPerSecond += upgrade.GetCurrentIncome();
            if (upgrade.wasBought)
            {
                exactBalance -= upgrade.GetUpgradeCost();
                upgrade.wasBought = false;
                upgrade.levelNumber++;
            }
            upgrade.UpdateUpgradeUI();
            upgrade.MakeEnabled(upgrade.GetUpgradeCost() <= currentBalance);
        }
        
        pointsPerClick = 1;
        foreach (ClickUpgrade clickUpgrade in clickUpgrades)
        {
            if (clickUpgrade.isPurchased)
            {
                pointsPerClick += clickUpgrade.clickBonus;
                clickUpgrade.button.interactable = false;
            }
            else if (clickUpgrade.cost <= currentBalance)
            {
                clickUpgrade.button.interactable = true;
                if (clickUpgrade.wasBought)
                {
                    clickUpgrade.wasBought = false;
                    clickUpgrade.isPurchased = true;
                    exactBalance -= clickUpgrade.cost;
                    pointsPerClick += clickUpgrade.clickBonus;
                }
            }
            else
            {
                clickUpgrade.button.interactable = false;
            }



            clickUpgrade.UpdateClickUpgradeUI();
        }

        exactBalance += (double)pointsPerSecond * Time.deltaTime;
        currentBalance = (long)exactBalance;
        balanceText.text = GlobalMethods.MakeShorter(currentBalance);
    }

    public void OnMushroomClick()
    {
        exactBalance += pointsPerClick;
        currentBalance = (long)exactBalance;
        balanceText.text = GlobalMethods.MakeShorter(currentBalance);
    }
    
}