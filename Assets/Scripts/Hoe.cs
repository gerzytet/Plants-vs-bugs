using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{
    //excepts player and angle to be set
    static float degreesPerSecond = 300.0f;
    public GameObject player;
    public Vector2 root;
    public float angle;
    public float remainingAngle = 60;
    public List<GameObject> alreadyHit = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        root = player.transform.position;
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
        if (Tags.HasTag(collision.gameObject, "bug") && !alreadyHit.Contains(collision.gameObject))
        {
            alreadyHit.Add(collision.gameObject);
            collision.gameObject.GetComponent<GameType>().Damage(20);
        }
    }
}
