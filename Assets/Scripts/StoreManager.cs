using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private Upgrade[] upgrades;
    [SerializeField] private TMP_Text balanceText;
    [SerializeField] private long currentBalance;
    [SerializeField] private long pointsPerClick = 1;
    [SerializeField] private long pointsPerSecond;

    private double _exactBalance;
    
    
    private void Update()
    {
        pointsPerSecond = 0;
        foreach (Upgrade upgrade in upgrades)
        {
            pointsPerSecond += upgrade.GetCurrentIncome();
            if (upgrade.wasBought)
            {
                _exactBalance -= upgrade.GetUpgradeCost();
                upgrade.wasBought = false;
                upgrade.levelNumber++;
            }
            upgrade.UpdateUI();
            upgrade.MakeEnabled(upgrade.GetUpgradeCost() <= currentBalance);
        }
        
        _exactBalance += (double)pointsPerSecond * Time.deltaTime;
        currentBalance = (long)_exactBalance;
        balanceText.text = GlobalMethods.MakeShorter(currentBalance);
    }

    public void OnMushroomClick()
    {
        _exactBalance += pointsPerClick;
        currentBalance = (long)_exactBalance;
        balanceText.text = GlobalMethods.MakeShorter(currentBalance);
    }

    
}