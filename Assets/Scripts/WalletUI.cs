using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private Wallet wallet = null;
    [SerializeField] private TextMeshProUGUI moneyText = null;

    void Start()
    {

        wallet.onMoneyChange += UpdateWalletUI;

        UpdateWalletUI(0, wallet.Money);
    }

    private void UpdateWalletUI(int change, int money) 
    {
        moneyText.text = money.ToString();
    }
}
