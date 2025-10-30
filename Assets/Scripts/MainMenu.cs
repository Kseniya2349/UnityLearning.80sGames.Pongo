using TMPro;
using UnityEngine;
using System;

public class MainMenu : MonoBehaviour
{
    private UIInputActions _uiInputActions;
    
    [SerializeField] GameObject highScorePanel;
    [SerializeField] TextMeshProUGUI highScoreTable;
    
    private void Awake()
    {
        _uiInputActions = new UIInputActions();
    }
    
    private void OnEnable()
    {
        _uiInputActions.Enable();
    }

    private void OnDisable()
    {
        _uiInputActions.Disable();
    }

    void Update()
    {
        if (_uiInputActions.UI.Cancel.triggered)
        {
            GameManager.Instance.LoadMainMenu();
        } 
    }

    public void StartGame()
    {
        GameManager.Instance.LoadGame();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowHighScorePanel()
    {
        highScorePanel.SetActive(true);
        highScoreTable.text = string.Join(Environment.NewLine, GameManager.Instance.GetHighScores());
    }
    
    public void CloseHighScorePanel()
    {
        highScorePanel.SetActive(false);
    }
}
