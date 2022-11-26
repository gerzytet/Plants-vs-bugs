
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuJukebox : MonoBehaviour
{
    public static MainMenuJukebox instance = null;

    private void Awake()
    {
        if (instance == null || instance.IsDestroyed())
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}