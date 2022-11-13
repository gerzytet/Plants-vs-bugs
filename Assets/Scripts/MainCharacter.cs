using System.Collections.Generic;
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
    public int money;
    public GameObject gameController;
    public GameObject spriteObject;
    public static MainCharacter instance { get; private set; }
    [Space]
    public AudioSource swingHoe;

    public MainCharacter()
    {
        instance = this;
    }

    public List<ItemStack> inventory =
        new List<ItemStack>(new ItemStack[]
        {
            new ItemStack(Item.HOE),
            new ItemStack(Item.Wood_SEEDS, 5),
            new ItemStack(Item.EMPTY),
            new ItemStack(Item.EMPTY),
            new ItemStack(Item.EMPTY),
            new ItemStack(Item.EMPTY)
            //yep
        });

    private List<KeyCode> inventorySelectKeys = new List<KeyCode>(new KeyCode[]
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6
    });
    

    public int currentlySelected = 0;
    private float mouseScroll = 0;
    public GameObject hoe;
    public GameObject plantPlacementPreview;

    public GameObject tradeUI;

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

    private static Vector2 getMousePositionGridlined()
    {
        Vector2 MousePosition = getMousePosition();
        MousePosition -= new Vector2(0.5f, 0.5f);
        MousePosition = new Vector2(Mathf.Round(MousePosition.x), Mathf.Round(MousePosition.y));
        MousePosition += new Vector2(0.5f, 0.5f);
        return MousePosition;
    }

    private void consumeHeldItem()
    {
        inventory[currentlySelected].count--;
        if (HeldItem().count <= 0)
        {
            inventory[currentlySelected] = new ItemStack(Item.EMPTY);
        }
    }

    public bool CanFit(Item item)
    {
        for (int i = 0; i < INVENTORY_CAPACITY; i++)
        {
            if (inventory[i].item == item || inventory[i].item == Item.EMPTY)
            {
                return true;
            }
        }
        return false;
    }
    
    public void AddItem(ItemStack item)
    {
        for (int i = 0; i < INVENTORY_CAPACITY; i++)
        {
            if (inventory[i].item == item.item)
            {
                inventory[i].count += item.count;
                return;
            }
            else if (inventory[i].item == Item.EMPTY)
            {
                inventory[i] = item;
                return;
            }
        }
    }

    private void shootHoe()
    {
        swingHoe.Play();
        Vector2 position = transform.position;
        GameObject newHoe = Instantiate(this.hoe, position, Quaternion.identity);
        Hoe hoeComponent = newHoe.GetComponent<Hoe>();
        hoeComponent.angle = Vector2.SignedAngle(Vector2.right, getMousePosition() - position) - hoeComponent.remainingAngle / 2;
        itemCooldown = MAX_ITEM_COOLDOWN;
    }

    private void plantPlant()
    {
        GameObject plantPrefab = null;
        foreach (PlantInfo plantInfo in gameController.GetComponent<GameController>().plantList)
        {
            if (plantInfo.seed == HeldItem().item)
            {
                plantPrefab = plantInfo.plant;
                break;
            }
        }
        if (plantPrefab == null)
        {
            print("No plant prefab found for " + HeldItem().item);
            return;
        }
        GameObject newPlant = Instantiate(plantPrefab, getMousePositionGridlined(), Quaternion.identity);
        itemCooldown = 0.3;
        consumeHeldItem();
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

        if (newVelocity != Vector2.zero)
        {
            spriteObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, newVelocity));
        }

        if (Input.GetMouseButton(0) && !tradeUI.activeInHierarchy && itemCooldown <= 0)
        {
            if (HeldItem().item == Item.HOE)
            {
                shootHoe();
            } else if (HeldItem().item.IsSeeds() && plantPlacementPreview.GetComponent<PlantPlacementPreview>().CanPlantHere())
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
        
        for (int i = 0; i < INVENTORY_CAPACITY; i++)
        {
            if (Input.GetKeyDown(inventorySelectKeys[i]))
            {
                currentlySelected = i;
            }
        }

        rb.velocity = newVelocity;
    }

    public ItemStack HeldItem()
    {
        return inventory[currentlySelected];
    }
}
