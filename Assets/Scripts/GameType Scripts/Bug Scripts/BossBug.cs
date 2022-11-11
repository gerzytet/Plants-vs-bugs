using UnityEngine.SceneManagement;

public class BossBug : Bug
{
    public override void Die()
    {
        SceneManager.LoadScene("Scenes/Win Screen");
    }

    public override void Hypnotize()
    {
        //can't be hypnotized
    }
}