using UnityEngine;

public class BugHealthBar : MonoBehaviour
{
    public GameObject bug;

    // Update is called once per frame
    void Update()
    {
        float healthPercent = (float) (bug.GetComponent<BasicBug>().health / BasicBug.MAX_HEALTH);
        transform.localScale = new Vector2(healthPercent, transform.localScale.y);
        transform.localPosition = new Vector2((healthPercent - 1f) * 0.5f, transform.localPosition.y);
    }
}
