using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TradeEntry : MonoBehaviour
{
    public Trade trade;
    public GameObject trader;

    void Update()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = trade.item.Name() + " : " + trade.cost;
    }

    public void BuyClicked()
    {
        Trader traderScript = trader.GetComponent<Trader>();
        traderScript.TryExecuteTrade(trade);
    }
}
