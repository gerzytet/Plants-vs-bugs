using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBug : Bug
{
    private const int MAMA_BUGS_TO_SPAWN = 5;
    [SerializeField] private int mamaBugsLeft = MAMA_BUGS_TO_SPAWN;
    public GameObject mamaBug;
    public override void Die()
    {
        SceneManager.LoadScene("Scenes/Win Screen");
    }

    public override void Hypnotize()
    {
        //can't be hypnotized
    }

    public override void Damage(float damage)
    {
        float nextSpawnHealth = (gameTypeInfo.maxHealth / MAMA_BUGS_TO_SPAWN) * mamaBugsLeft;
        if (health - damage <= nextSpawnHealth)
        {
            mamaBugsLeft--;
            Instantiate(mamaBug, transform.position, Quaternion.identity);
        }
        base.Damage(damage);
    }
}