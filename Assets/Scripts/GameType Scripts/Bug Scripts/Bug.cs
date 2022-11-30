using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bug : GameType
{
    Rigidbody2D rb;
    public bool hypnotized = false;
    [Space]
    public GameObject deathSoundPrefab;
    public AudioSource eatSound;
    public int moneyOnDeath = 0;
    public static float FRICTION = 0.98f;

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

            rb.AddForce(direction.normalized * (((BugInfo)gameTypeInfo).speed * rb.mass));
            rb.velocity *= FRICTION;
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, direction));
        }
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
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
    
    public virtual void OnCollisionStay2D(Collision2D collision2D)
    {
        if (hypnotized && Tags.HasTag(collision2D.gameObject, "bug") || !hypnotized && Tags.HasTag(collision2D.gameObject, "plant"))
        {
            collision2D.gameObject.GetComponent<GameType>().Damage(gameTypeInfo.damage);
            if (eatSound.isPlaying)
            {
                eatSound.Play();
            }
        }
        
    }

    public override void Die()
    {
        Destroy(Instantiate(deathSoundPrefab, transform.position, Quaternion.identity), 3);
        if (MainCharacter.instance != null)
        {
            MainCharacter.instance.money += moneyOnDeath;
        }
        base.Die();
    }
    
    public virtual void Hypnotize()
    {
        hypnotized = true;
        gameObject.layer = LayerMask.NameToLayer("plants");
        var image = transform.Find("Health Bar/Canvas/Health Bar Fill");
        image.gameObject.GetComponent<Image>().color = Color.blue;
        health = gameTypeInfo.maxHealth;
        Tags.Add(gameObject, "plant");
        Tags.Remove(gameObject, "bug");
    }
}
