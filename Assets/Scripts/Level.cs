using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    public string scene;
    public string displayName;
    public bool isTutorial = false;

    public void Load()
    {
        SceneManager.LoadSceneAsync("Scenes/" + scene);
    }
}