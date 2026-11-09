using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    private int money = 0;

    public static MoneyManager instance;

    private void Start()
    {
        AddMoney(20);
    }
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }
    public void UpdateMoneyText()
    {
        moneyText.text = "Money: " + money.ToString();
    }
    public void RemoveMoney(int amount)
    {
        money -= amount;
        UpdateMoneyText();
    }
    public bool CanAfford(int amount)
    {
        if (money >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
