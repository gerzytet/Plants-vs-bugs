using System.Collections.Generic;
using UnityEngine;

public abstract class Taggable : MonoBehaviour
{
    public List<string> initialTags;
    
    public virtual void AddTag()
    {
        foreach (string tag in initialTags)
        {
            Tags.Add(gameObject, tag);
        }
    }
    
    public virtual void RemoveTag()
    {
        Tags.RemoveAll(gameObject);
    }
}
