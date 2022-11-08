using UnityEngine;

public class BugHealthBar : MonoBehaviour
{
    public GameObject bug;
    GameType gameType;

    // Update is called once per frame
    private void Start()
    {
        gameType = bug.GetComponent<GameType>();
    }
    void Update()
    {
        float healthPercent = (float)(gameType.GetHealth() / gameType.gameTypeInfo.maxHealth);
        transform.localScale = new Vector2(healthPercent, transform.localScale.y);
        transform.localPosition = new Vector2((healthPercent - 1f) * 0.5f, transform.localPosition.y);
    }
}
