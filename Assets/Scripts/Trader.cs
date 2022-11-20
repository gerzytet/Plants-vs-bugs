using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public List<Trade> trades = new List<Trade>();

    public Sprite daySprite;
    public Sprite nightSprite;
    private bool inRange = false;
    public static Trader instance { get; private set; }
    
    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        foreach (PlantInfo plant in GameController.instance.GetComponent<GameController>().plantList)
        {
            if (plant.buyable)
            {
                trades.Add(new Trade(plant.seed, (int) (plant.cost * GameController.difficulty.CostMultiplier())));
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == MainCharacter.instance.gameObject)
        {
            inRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == MainCharacter.instance.gameObject)
        {
            inRange = false;
        }
    }

    public void TryExecuteTrade(Trade trade)
    {
        MainCharacter mc = MainCharacter.instance;
        if (mc.CanFit(trade.item) && mc.money >= trade.cost)
        {
            mc.money -= trade.cost;
            mc.AddItem(new ItemStack(trade.item));
            GetComponent<AudioSource>().Play();
        }
    }

    public void Update()
    {
        bool day = Clock.instance.IsDay();
        var renderer = GetComponent<SpriteRenderer>();
        if (day)
        {
            renderer.sprite = daySprite;
        }
        else
        {
            renderer.sprite = nightSprite;
        }
        
        TradeUI.instance.gameObject.SetActive(day && inRange);
    }
}
