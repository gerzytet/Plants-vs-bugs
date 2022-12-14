using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Type / New Bug")]

public class BugInfo : GameTypeInfo
{
    public float speed;
    public GameObject bug;
    public int moneyOnDeath;
    public string guideDescription = "";
    public string displayName = "";
}
