using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameType : Taggable
{

    //GameTypeInfo is a ScriptableObject that will provide basic game stats for each GameType you create
    public GameTypeInfo gameTypeInfo;
    //The Gameobject that represents the created GameType
    public GameObject gameTypePrefab;

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
