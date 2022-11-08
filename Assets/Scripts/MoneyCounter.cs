using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Money: " + player.GetComponent<MainCharacter>().money;
    }
}
