using System.Collections.Generic;
using UnityEngine;

public class Taggable : MonoBehaviour
{
    public List<string> initialTags;
    
    public virtual void Start()
    {
        foreach (string tag in initialTags)
        {
            Tags.Add(gameObject, tag);
        }
    }
    
    public virtual void OnDestroy()
    {
        Tags.RemoveAll(gameObject);
    }
}
