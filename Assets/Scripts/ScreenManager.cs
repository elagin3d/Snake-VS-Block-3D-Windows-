using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    
    void Start()
    {
        Finish.FinishEvent.AddListener(ShowWinScreen);
        SnakeManager.GameOver.AddListener(ShowLoseScreen);
        //
        if(GameManager._playGame == false)
        {
            _startScreen.SetActive(true);
        }
        else
        {
            _gameScreen.SetActive(true);
        }
    }
    
    public void PlayGame()
    {
        _startScreen.SetActive(false);
        _gameScreen.SetActive(true);
    }
    public void ShowWinScreen()
    {
        _gameScreen.SetActive(false);
        _winScreen.SetActive(true);
    }
    public void ShowLoseScreen()
    {
        _gameScreen.SetActive(false);
        _loseScreen.SetActive(true);
    }
    public void ExitToTheMenu()
    {
        _startScreen.SetActive(true);
        _gameScreen.SetActive(false);
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);
    }
   
}
