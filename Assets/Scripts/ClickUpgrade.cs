using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text bonusText;

    public string nameOfClickUpgrade;
    public Button button;
    public long cost;
    public long clickBonus;
    public bool isPurchased;
    public bool wasBought;

    public void OnClickUpgradeButtonPressed()
    {
        wasBought = true;
    }

    public void UpdateClickUpgradeUI()
    {
        if (isPurchased)
        {
            costText.text = "";
            button.image.color = new Color32(70, 200, 70, 255);
        }
        else
        {
            costText.text = GlobalMethods.MakeShorter(cost);
        }
        bonusText.text = $"+{GlobalMethods.MakeShorter(clickBonus)}\nper click";
    }
}