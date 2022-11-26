using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantsAndBugs : MonoBehaviour
{
    public void Press() {
        SceneManager.LoadScene("PlantsAndBugs");
    }

    public void PressPlants()
    {
        SceneManager.LoadScene("Plant Guide");
    }
    
    public void PressBugs()
    {
        SceneManager.LoadScene("Bug Guide");
    }
}
