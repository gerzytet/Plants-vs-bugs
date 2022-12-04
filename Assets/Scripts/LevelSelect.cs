using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public List<Level> levels;
    public Level selected;
    public static LevelSelect instance { get; private set; }
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        var dropdown = GetComponent<TMP_Dropdown>();
        foreach (Level level in levels)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(level.name));
        }

        dropdown.value = 0;
        selected = levels[0];
    }
    
    public void OnValueChanged(int index)
    {
        selected = levels[index];
        DifficultySelect.instance.gameObject.SetActive(!selected.isTutorial);
        
    }
}
