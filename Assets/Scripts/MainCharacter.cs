using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    static float SPEED = 4f;
    
    List<KeyCode> UpKeys = new List<KeyCode>() { KeyCode.W, KeyCode.UpArrow };
    List<KeyCode> DownKeys = new List<KeyCode>() { KeyCode.S, KeyCode.DownArrow };
    List<KeyCode> LeftKeys = new List<KeyCode>() { KeyCode.A, KeyCode.LeftArrow };
    List<KeyCode> RightKeys = new List<KeyCode>() { KeyCode.D, KeyCode.RightArrow };

    private static double MAX_ITEM_COOLDOWN = 0.9;
    private double itemCooldown = 0;
    public static int INVENTORY_CAPACITY = 6;

    public List<Item> inventory =
        new List<Item>(new Item[] { Item.HOE, Item.SEEDS, Item.EMPTY, Item.EMPTY, Item.EMPTY, Item.EMPTY });

    public int currentlySelected = 0;
    private float mouseScroll = 0;
    public GameObject hoe;

    public GameObject plant;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    bool anyPressed(List<KeyCode> keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key))
            {
                return true;
            }
        }
        return false;
    }
    
    private static Vector2 getMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void shootHoe()
    {
        Vector2 position = transform.position;
        GameObject newHoe = Instantiate(this.hoe, position, Quaternion.identity);
        Hoe hoeComponent = newHoe.GetComponent<Hoe>();
        hoeComponent.angle = Vector2.SignedAngle(Vector2.right, getMousePosition() - position) - hoeComponent.remainingAngle / 2;
        hoeComponent.player = gameObject;
        itemCooldown = MAX_ITEM_COOLDOWN;
    }

    private void plantPlant()
    {
        GameObject newPlant = Instantiate(plant, transform.position, Quaternion.identity);

        /*
        Plant plantComponent = newPlant.GetComponent<Plant>();
        plantComponent.health = Plant.MAX_HEALTH / 5;
        plantComponent.activeGrowthAmount = Plant.MAX_HEALTH * (4f/5f);
        */
        itemCooldown = MAX_ITEM_COOLDOWN;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 newVelocity = Vector2.zero;
        if (anyPressed(UpKeys))
        {
            newVelocity.y = SPEED;
        } else if (anyPressed(DownKeys))
        {
            newVelocity.y = -SPEED;
        }

        if (anyPressed(LeftKeys))
        {
            newVelocity.x = -SPEED;
        } else if (anyPressed(RightKeys))
        {
            newVelocity.x = SPEED;
        }

        if (Input.GetMouseButton(0) && itemCooldown <= 0)
        {
            if (inventory[currentlySelected] == Item.HOE)
            {
                shootHoe();
            } else if (inventory[currentlySelected] == Item.SEEDS)
            {
                plantPlant();
            }
        }

        itemCooldown -= Time.deltaTime;
        
        mouseScroll += Input.mouseScrollDelta.y;
        if (mouseScroll > 1)
        {
            currentlySelected = (currentlySelected - 1 + INVENTORY_CAPACITY) % INVENTORY_CAPACITY;
            mouseScroll = 0;
        } else if (mouseScroll < -1)
        {
            currentlySelected = (currentlySelected + 1) % INVENTORY_CAPACITY;
            mouseScroll = 0;
        }

        rb.velocity = newVelocity;
    }
}
