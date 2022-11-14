using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialText;
    public GameObject movementTest;
    public GameObject tutorialBug;
    public static TutorialController instance { get; private set; }

    public int stage = 0;

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Trader.instance.gameObject.SetActive(false);
        Clock.instance.frozen = true;
        MainCharacter.instance.inventory = new List<ItemStack>(new ItemStack[]
        {
            new ItemStack(Item.EMPTY),
            new ItemStack(Item.EMPTY),
            new ItemStack(Item.EMPTY),
            new ItemStack(Item.EMPTY),
            new ItemStack(Item.EMPTY),
            new ItemStack(Item.EMPTY)
        });
    }

    public void Advance()
    {
        stage++;
        TextMeshProUGUI text = tutorialText.GetComponent<TextMeshProUGUI>();
        Button button = tutorialText.GetComponentInChildren<Button>();
        switch (stage)
        {
            case 1:
                text.text =
                    "Your goal is to defend the 4 flowers in the middle, called life lilies, against the swarm of mutant bugs!";
                break;
            case 2:
                text.text = "Use the WASD keys or arrow keys to move around.  Move to the magenta circle to continue.";
                button.interactable = false;
                movementTest.SetActive(true);
                break;
            case 3:
                text.text = "Oh no, a bug!  Use the left mouse button to swing your hoe at it.  Kill it to continue.";
                var mainCharacter = MainCharacter.instance;
                mainCharacter.inventory[0] = new ItemStack(Item.HOE);
                mainCharacter.currentlySelected = 0;
                tutorialBug.SetActive(true);
                break;
            case 4:
                text.text = "More bugs will come at night, so you must prepare!  You can use your money to buy plants at the trader desk.  Buy any plant to continue.";
                Trader.instance.gameObject.SetActive(true);
                break;
            case 5:
                text.text =
                    "Great!  now switch to the inventory slot containing your seeds by pressing a number key or scrolling.   Then left click any empty space on the ground to plant it.";
                break;
            case 6:
                text.text =
                    "Normally, bugs only spawn at night.  You can see the time of day by looking at the clock in the top right.";
                button.interactable = true;
                break;
            case 7:
                text.text = "You can use the skip to night button to skip to the night, once your defenses are ready.  Wait until night, or press the button to continue.";
                button.interactable = false;
                Clock.instance.frozen = false;
                break;
            case 8:
                text.text = "Don't let them eat your life lilies!";
                break;
            case 9:
                text.text = "Good job!  Press next one more time to close this tutorial.";
                button.interactable = true;
                break;
            case 10:
                gameObject.SetActive(false);
                button.gameObject.SetActive(false);
                tutorialText.SetActive(false);
                break;
        }
    }

    public void Update()
    {
        var mainCharacter = MainCharacter.instance;
        if (stage == 4)
        {
            foreach (var stack in mainCharacter.inventory)
            {
                if (stack.item.IsSeeds())
                {
                    Advance();
                    break;
                }
            }
        } else if (stage == 5)
        {
            if (Tags.GetAll("life_plant").Count < Tags.GetAll("plant").Count)
            {
                Advance();
            }
        } else if (stage == 7)
        {
            if (!Clock.instance.IsDay())
            {
                Advance();
            }
        } else if (stage == 8)
        {
            if (Clock.instance.GetComponent<Clock>().IsDay())
            {
                Advance();
            }
        }
    }
}
