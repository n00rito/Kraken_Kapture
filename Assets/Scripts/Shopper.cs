using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleInventory
{
    [RequireComponent(typeof(Wallet))]
    public class Shopper : MonoBehaviour
    {
        [SerializeField] InventoryManager inventory = null;
        private Wallet wallet = null;

        private Shop currentShop = null;

        public Shop GetCurrentShop => currentShop;

        public delegate void OnEnterShop(Shop shop);
        public delegate void OnExitShop();
        public OnEnterShop onEnterShop;
        public OnExitShop onExitShop;

        #region
        private void Start()
        {
            if (!TryGetComponent(out wallet))
            ExitShop();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (TryGetComponent(out currentShop))
                    EnterShop();
            }
        }


        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                ExitShop();
            }
        }
        #endregion

        private void EnterShop()
        {
            currentShop.EnterShop(this);

            onEnterShop?.Invoke(currentShop);
        }

        private void ExitShop()
        {
            currentShop.ExitShop();

            currentShop = null;

            onExitShop?.Invoke();
        }

        public bool TryBuyItem(ItemSO i, int number)
        {
            if (wallet.CanAfford(i.GetPrice()))
            {
                inventory.AddToInventory(i, number);

                wallet.RemoveMoney(i.GetPrice() * number);

                return true;
            }
            return false;
        }

        public void SellItem(ItemSO i)
        {
            //If at a shop, we have the item, and the shop can afford/will be able to resell it
            if (currentShop && inventory.HasNumberOfItem(i, 1) && currentShop.TryBuyFromPlayer(i))
            {
                inventory.RemoveFromInventory(i, 1);

                wallet.AddMoney(i.GetPrice());
            }
        }
    }
}