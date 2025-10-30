using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private UIInputActions _uiInputActions;
    
    [SerializeField] GameObject _highScorePanel;
    
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
        _highScorePanel.SetActive(true);
    }
    
    public void CloseHighScorePanel()
    {
        _highScorePanel.SetActive(false);
    }
}
