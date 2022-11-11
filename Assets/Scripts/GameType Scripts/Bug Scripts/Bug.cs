using UnityEngine;

public abstract class Bug : GameType
{
    Rigidbody2D rb;
    public GameObject player;
    public bool hypnotized = false;
    [Space]
    public AudioClip deathSound;
    public int moneyOnDeath = 0;


    public virtual void FixedUpdate()
    {
        GameObject plant = findNearestPlant();
        if (plant == null)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            Vector2 direction = plant.transform.position - transform.position;
            rb.velocity = direction.normalized * ((BugInfo)gameTypeInfo).speed;
        }
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, rb.velocity));
    }

    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        if (hypnotized)
        {
            Hypnotize();
        }
    }
    
    protected GameObject findNearestPlant()
    {
        Vector2 myLocation = transform.position;
        GameObject closestPlant = null;
        float closestDistance = float.MaxValue;
        string tag = hypnotized ? "bug" : "plant";
        foreach (GameObject plant in Tags.GetAll(tag))
        {
            float dist = Vector2.Distance(myLocation, plant.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestPlant = plant;
            }
        }
        return closestPlant;
    }
    
    public virtual void OnTriggerStay2D(Collider2D collision2D)
    {
        string tag = hypnotized ? "bug" : "plant";
        if (Tags.HasTag(collision2D.gameObject, tag))
        {
            collision2D.gameObject.GetComponent<GameType>().Damage(gameTypeInfo.damage);
        }

        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public override void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        MainCharacter.instance.money += moneyOnDeath;
        base.Die();
    }
    
    public virtual void Hypnotize()
    {
        hypnotized = true;
        gameObject.layer = LayerMask.NameToLayer("plants");
        var renderer = GetComponentInChildren<SpriteRenderer>();
        renderer.sortingLayerID = SortingLayer.NameToID("plants");
        renderer.color = Color.blue;
        health = gameTypeInfo.maxHealth;
        Tags.Add(gameObject, "plant");
        Tags.Remove(gameObject, "bug");
    }
}
