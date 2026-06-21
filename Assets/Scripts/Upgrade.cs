using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private int baseCost = 1;  // Cost on first level
    [SerializeField] private float multiplier = 1.15f;
    [SerializeField] private float baseIncome = 1f; // Income on first level
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text levelAndIncomeText;
    [SerializeField] private TMP_Text costText;

    public int levelNumber; // Number of bought upgrades
    public bool wasBought;
    
    
    public int GetUpgradeCost()     // Counts next upgrade's cost
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(multiplier, levelNumber));
    }

    public int GetCurrentIncome()
    {
        return Mathf.RoundToInt(baseIncome * levelNumber);
    }

    public void UpdateUI()
    {
        levelAndIncomeText.text = $"{levelNumber} x {GlobalMethods.MakeShorter(GetCurrentIncome())}/s";
        costText.text = GlobalMethods.MakeShorter(GetUpgradeCost());
    }

    public void MakeEnabled(bool isEnabled)
    {
        button.interactable = isEnabled;
    }

    public void BuyUpgrade()
    {
        wasBought = true;
    }
}