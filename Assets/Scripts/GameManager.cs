using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{

    [SerializeField] private LevelList _levelList;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;
    private int _currentLevelIndex;
    //
    [SerializeField] private TMP_Text _textLevel;
    //
    public static bool _playGame = false;

    private void Awake()
    {
        _currentLevelIndex = _saveLoadSystem.GetLevelIndex();
        _currentLevelIndex %= _levelList.Levels.Length;
        Instantiate(_levelList.Levels[_currentLevelIndex]);
    }
    private void Start()
    {
        SnakeManager.GameOver.AddListener(GameOver);
        Finish.FinishEvent.AddListener(WinLevel);
        if (_playGame == false)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        _textLevel.text = "Level " + (_currentLevelIndex + 1).ToString();
    }


    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        _saveLoadSystem.SaveLevelIndex(_currentLevelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PlayGame()
    {
        _playGame = true;
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
    }
    public void WinLevel()
    {
        Time.timeScale = 0;
    }
    public void ExitToTheMenu()
    {
        _playGame = false;
        Time.timeScale = 0;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
