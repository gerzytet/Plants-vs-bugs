using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tags
{

    private static Dictionary<string, List<GameObject>> tagMap = new Dictionary<string, List<GameObject>>();
    
    public static void Add(GameObject gameObject, string tag)
    {
        List<GameObject> list;
        if (tagMap.TryGetValue(tag, out list))
        {
            list.Add(gameObject);
        }
        else
        {
            tagMap[tag] = new List<GameObject> {gameObject};
        }
    }
    
    public static void Remove(GameObject gameObject, string tag)
    {
        if (tagMap.ContainsKey(tag))
        {
            tagMap[tag].Remove(gameObject);
        }
    }
    
    public static void RemoveAll(GameObject gameObject)
    {
        foreach (var list in tagMap.Values)
        {
            list.Remove(gameObject);
        }
    }
    
    public static List<GameObject> GetAll(string tag)
    {
        List<GameObject> list;
        tagMap.TryGetValue(tag, out list);
        if (list == null)
        {
            list = new List<GameObject>();
        }

        List<GameObject> filteredList = new List<GameObject>();
        foreach (GameObject obj in list)
        {
            if (!obj.IsDestroyed())
            {
                filteredList.Add(obj);
            }
        }

        return filteredList;
    }

    public static bool HasTag(GameObject gameObject, string tag)
    {
        return tagMap.ContainsKey(tag) && tagMap[tag].Contains(gameObject);
    }
}
