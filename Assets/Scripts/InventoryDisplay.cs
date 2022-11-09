using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public List<GameObject> inventorySlots;
    public List<GameObject> inventoryNumbers = new List<GameObject>();
    public GameObject hoeDisplay;
    public GameObject seedsDisplay;
    public GameObject emptyDisplay;
    public List<Item> lastKnownInventory;
    public GameObject selectIndicator;
    public GameObject inventoryNumber;

    public GameObject player;

    void Start()
    {
        for (int i = 0; i < MainCharacter.INVENTORY_CAPACITY; i++)
        {
            lastKnownInventory.Add(Item.INVALID);
        }
        for (int i = 0; i < MainCharacter.INVENTORY_CAPACITY; i++)
        {
            inventoryNumbers.Add(null);
        }
    }
    void Update()
    {
        MainCharacter mc = player.GetComponent<MainCharacter>();
        List<Item> currentInventory = mc.inventory.Select(itemStack => itemStack.item).ToList();
        for (int i = 0; i < MainCharacter.INVENTORY_CAPACITY; i++)
        {
            if (currentInventory[i] != lastKnownInventory[i])
            {
                GameObject newDisplay = currentInventory[i] switch {
                    Item.HOE => hoeDisplay,
                    Item.SEEDS => seedsDisplay,
                    _ => emptyDisplay
                };
                GameObject oldDisplay = inventorySlots[i];
                GameObject newDisplayInstance = Instantiate(newDisplay, oldDisplay.transform.position + new Vector3(0, 0, -0.05f), newDisplay.transform.rotation);
                newDisplayInstance.transform.SetParent(transform);
                Destroy(oldDisplay);
                inventorySlots[i] = newDisplayInstance;
                inventoryNumbers[i] = Instantiate(inventoryNumber, newDisplayInstance.transform, false);
            }
            
            var textComponent = inventoryNumbers[i].GetComponent<TextMesh>();
            string text = mc.inventory[i].item == Item.EMPTY ? " " : mc.inventory[i].count.ToString();
            textComponent.text = text;
        }

        lastKnownInventory = currentInventory;
        selectIndicator.transform.position = inventorySlots[mc.currentlySelected].transform.position + new Vector3(0, 0, -0.1f);
    }
}
