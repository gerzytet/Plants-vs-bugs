using System;
using System.Collections.Generic;
using UnityEngine;

public class TradeUI : MonoBehaviour
{
    public GameObject trader;
    public List<GameObject> tradeEntryList = new List<GameObject>();
    void Awake()
    {
        List<Trade> trades = trader.GetComponent<Trader>().trades;
        for (int i = 0; i < trades.Count; i++)
        {
            var tradeEntry = tradeEntryList[i].GetComponent<TradeEntry>();
            tradeEntry.trade = trades[i];
            tradeEntry.trader = trader;
        }

        for (int i = trades.Count; i < tradeEntryList.Count; i++)
        {
            tradeEntryList[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
