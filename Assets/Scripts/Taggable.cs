using System.Collections.Generic;
using UnityEngine;

public abstract class Taggable : MonoBehaviour
{
    public List<string> initialTags;
    
    public virtual void AddTags()
    {
        //get this game object
        foreach (string tag in initialTags)
        {
            Tags.Add(gameObject, tag);
        }
    }
    
    public virtual void RemoveTags()
    {
        Tags.RemoveAll(gameObject);
    }
}
