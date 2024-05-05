using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI moneyAmount;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyText();

        
    }

    public void DeductMoney(int amount)
    {
        money -= amount;
        UpdateMoneyText();
    }


    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }

    // Update is called once per frame
    void UpdateMoneyText()
    {
        moneyAmount.text = money.ToString();
    }
}
