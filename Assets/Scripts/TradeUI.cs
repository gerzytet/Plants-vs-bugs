using System;
using System.Collections.Generic;
using UnityEngine;

public class TradeUI : MonoBehaviour
{
    public List<GameObject> tradeEntryList = new List<GameObject>();
    public static TradeUI instance { get; private set; }
    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        List<Trade> trades = Trader.instance.trades;
        for (int i = 0; i < trades.Count; i++)
        {
            var tradeEntry = tradeEntryList[i].GetComponent<TradeEntry>();
            tradeEntry.trade = trades[i];
        }

        for (int i = trades.Count; i < tradeEntryList.Count; i++)
        {
            tradeEntryList[i].SetActive(false);
        }
    }
}
