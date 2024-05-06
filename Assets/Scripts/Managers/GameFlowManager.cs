using UnityEngine;
using UnityEngine.SceneManagement;
public class GameFlowManager : MonoBehaviour
{
    private enum EGameState 
    {
        READY,
        PLAYING,
        PAUSED,
        GAME_OVER
    }

    public string _playerTag = "Player";
    public string _startInput = "ActionInput";
    public string _pauseInput = "PauseInput";
    public float _resetGameWaitTime = 0.5f;
    public GameObject _pauseCanvas;

    private EGameState _currentGameState = EGameState.READY;
    private NotifyPlayerEvents _playerEvents;

    void Start()
    {
        if(_playerEvents == null)
            _playerEvents = GameObject.FindGameObjectWithTag(_playerTag).GetComponent<NotifyPlayerEvents>();
        _playerEvents.OnPlayerDied += OnPlayerDied;

        EnterCurrentState();
    }

    void Update()
    {
        if (Input.GetButtonDown(_startInput) && (_currentGameState == EGameState.READY || _currentGameState == EGameState.PAUSED))
            ChangeGameState(EGameState.PLAYING);

        else if(Input.GetButtonDown(_pauseInput) && _currentGameState == EGameState.PLAYING)
            ChangeGameState(EGameState.PAUSED);
    }

    private void OnPlayerDied()
    {
        ChangeGameState(EGameState.GAME_OVER);
    }

    private void ChangeGameState(EGameState newState)
    {
        if (newState == _currentGameState)
            return;
        Debug.Log(newState.ToString());
        ExitCurrentState();
        _currentGameState = newState;
        EnterCurrentState();
    }

    private void ExitCurrentState()
    {
        switch(_currentGameState) 
        {
            case EGameState.READY:
                Time.timeScale = 1.0f;
                _pauseCanvas.SetActive(false);
                break;
            case EGameState.PLAYING:
                break;
            case EGameState.PAUSED:
                Time.timeScale = 1.0f;
                _pauseCanvas.SetActive(false);
                break;
            case EGameState.GAME_OVER:
                Time.timeScale = 1.0f;
                break;
        }
    }

    private void EnterCurrentState()
    {
        switch (_currentGameState)
        {
            case EGameState.READY:
                Time.timeScale = 0.0f;
                _pauseCanvas.SetActive(true);
                break;
            case EGameState.PLAYING:
                break;
            case EGameState.PAUSED:
                Time.timeScale = 0.0f;
                _pauseCanvas.SetActive(true);
                break;
            case EGameState.GAME_OVER:
                Time.timeScale = 0.25f;
                Invoke("ResetGame", _resetGameWaitTime);
                _playerEvents.OnPlayerDied -= OnPlayerDied;
                break;
        }
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
