using UnityEngine;
using TMPro;

public class ScoreLabel : MonoBehaviour
{
    private TextMeshProUGUI _labelComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    void Start()
    {
        _labelComponent = gameObject.GetComponent<TextMeshProUGUI>();
        _labelComponent.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        _labelComponent.text = "Score: " + GameManager.Score;
    }
}
