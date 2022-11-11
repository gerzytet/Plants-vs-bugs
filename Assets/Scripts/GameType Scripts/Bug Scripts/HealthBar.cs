using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject gameTypePrefab;
    GameType gameType;
    public Transform healthBar;
    public Image healthBarFill;

    // Update is called once per frame
    private void Start()
    {
        gameType = gameTypePrefab.GetComponent<GameType>();
    }
    void Update()
    {
        float healthPercent = (float)(gameType.GetHealth() / gameType.gameTypeInfo.maxHealth);
        healthBarFill.fillAmount = healthPercent;
        healthBar.rotation = Quaternion.identity;

    }
}
