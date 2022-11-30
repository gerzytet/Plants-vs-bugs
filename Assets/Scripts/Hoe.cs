using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hoe : MonoBehaviour
{
    //excepts player and angle to be set
    static float degreesPerSecond = 300.0f;
    private static float knockback = 2f;
    public Vector2 root;
    public float angle;
    public float remainingAngle = 60;
    public List<GameObject> alreadyHit = new List<GameObject>();
    public int HIT_LIMIT = 4;

    public void Start()
    {
        //prevent the hoe from being in the wrong place on the first frame
        Update();
    }

    void Update()
    {
        root = MainCharacter.instance.transform.position;
        angle += degreesPerSecond * Time.deltaTime;
        remainingAngle -= degreesPerSecond * Time.deltaTime;
        if (remainingAngle <= 0)
        {
            Destroy(gameObject);
            return;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * transform.localScale.x / 2 + root;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Tags.HasTag(collision.gameObject, "bug") && !alreadyHit.Contains(collision.gameObject) && alreadyHit.Count < HIT_LIMIT)
        {
            alreadyHit.Add(collision.gameObject);
            collision.gameObject.GetComponent<GameType>().Damage(20);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(((Vector2)collision.gameObject.transform.position - root).normalized * knockback, ForceMode2D.Impulse);
        }
    }
}
