using UnityEngine;
using UnityEngine.UI;

public class Rainbow : MonoBehaviour
{
    [SerializeField] private Image Item;
    [SerializeField] private Color[] ColorChange;
    [SerializeField][Range(0f, 5f)] float LerpTime;

    int ColorIndex = 0;

    float t = 0f;

    int len;

    private void Start()
    {
        len = ColorChange.Length;
    }
    void Update()
    {
        Item.color = Color.Lerp(Item.color, ColorChange[ColorIndex], LerpTime * Time.deltaTime);

        t = Mathf.Lerp(t, 1f, LerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            ColorIndex++;
            ColorIndex = (ColorIndex >= ColorChange.Length) ? 0 : ColorIndex;
        }
    }
}
