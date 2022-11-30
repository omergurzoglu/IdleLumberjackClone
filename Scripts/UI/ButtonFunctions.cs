using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
   [SerializeField]private TextMeshProUGUI priceText;
   private int _currentPrice;
   public void ExitButton()
   {
      GameEvents.instance.CloseShopUI();
   }

   public void BuyButton()
   {
      _currentPrice = int.Parse(priceText.text);
      if (Money._moneyScore < _currentPrice)
      {
         return;
      }
      GameEvents.instance.MoneyScoreMinus(_currentPrice);
      var nextPrice = _currentPrice + 5;
      priceText.text = nextPrice.ToString();
      GameEvents.instance.ReduceTreeHP();
   }
}
