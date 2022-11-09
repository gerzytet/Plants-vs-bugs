using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public List<Trade> trades = new List<Trade>(new Trade[]
    {
        new Trade(Item.SEEDS, 10),
        new Trade(Item.SEEDS, 15)
    });

    public GameObject tradeUI;
    public GameObject player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            tradeUI.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            tradeUI.SetActive(false);
        }
    }

    public void TryExecuteTrade(Trade trade)
    {
        MainCharacter mc = player.GetComponent<MainCharacter>();
        if (mc.CanFit(trade.item))
        {
            mc.money -= trade.cost;
            mc.AddItem(new ItemStack(trade.item));
        }
    }
}
