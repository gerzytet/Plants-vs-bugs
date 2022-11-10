using UnityEngine;

public class MamaBug : Bug
{
    public GameObject basicBug;
    public float speed;
    
    public override void Start()
    {
        base.Start();
        speed = ((BugInfo)gameTypeInfo).speed;
    }
    public override void FixedUpdate()
    {
        GameObject plant = findNearestPlant();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (plant == null)
        {
            rb.velocity = Vector2.zero;
        }
        else 
        {
            Vector2 direction = plant.transform.position - transform.position;
            rb.velocity = direction.normalized * speed;
        }

        base.FixedUpdate();
    }
    
    public override void Die()
    {
        base.Die();
        for (int i = 0; i < 2; i++)
        {
            Vector2 location = ((Vector2)transform.position) + new Vector2(Random.Range(0, 0.2f), Random.Range(0, 0.2f));
            GameObject newBug = Instantiate(basicBug, location, Quaternion.identity);
        }
    }
}