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
        tagMap.Remove(tag);
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
        return tagMap.TryGetValue(tag, out list) ? list : new List<GameObject>();
    }

    public static bool HasTag(GameObject gameObject, string tag)
    {
        return tagMap.ContainsKey(tag) && tagMap[tag].Contains(gameObject);
    }
}
