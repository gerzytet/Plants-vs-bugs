using Unity.VisualScripting;
using UnityEngine;

public class MamaBug : Bug
{
    public GameObject basicBug;
    
    public override void Start()
    {
        base.Start();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    
    public override void Die()
    {
        base.Die();
        for (int i = 0; i < 2; i++)
        {
            Vector2 location = ((Vector2)transform.position) + new Vector2(Random.Range(0, 0.2f), Random.Range(0, 0.2f));
            GameObject newBug = Instantiate(basicBug, location, Quaternion.identity);
            if (hypnotized)
            {
                newBug.GetComponent<Bug>().hypnotized = true;
            }
        }
    }
}