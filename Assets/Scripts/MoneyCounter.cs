using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Money: " + MainCharacter.instance.money;
    }
}
