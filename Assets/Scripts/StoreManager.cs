using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private Upgrade[] upgrades;
    [SerializeField] private TMP_Text balanceText;
    [SerializeField] private long pointsPerClick = 1;
    [SerializeField] private long pointsPerSecond;

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
            upgrade.UpdateUI();
            upgrade.MakeEnabled(upgrade.GetUpgradeCost() <= currentBalance);
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