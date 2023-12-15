using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
    {
        [SerializeField] private AppTrigger _trigger;
        [SerializeField] private Transform _root;
        [SerializeField] private GameObject _mainMenuScreen;
        [SerializeField] private GameObject _menuOptionScreen;
        [SerializeField] private GameObject _gameplayScreen;
        [SerializeField] private GameObject _lootScreen;
        [SerializeField] private GameObject _acceptRewards;
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private GameObject _looseScreen;

        private GameObject _currentScreen;

    private void Start()
    {
        StartCoroutine(WaitForInitializeRoutine());
    }

    private IEnumerator WaitForInitializeRoutine()
    {
        while (!Context.Instance.IsInitialized)
        {
            yield return null;
        }

        var appSystem = Context.Instance.AppSystem;
        appSystem.OnStateChange += OnStateChange;
        DontDestroyOnLoad(gameObject);
        OnStateChange(new StateChangeData<AppState, AppTrigger>(
            appSystem.CurrentState,
            AppState.Loading,
            AppTrigger.ToMainMenu));
    }

    [ContextMenu("SetTrigger")]
    public void SetTrigger()
    {
        Context.Instance.AppSystem.Trigger(_trigger);
    }

    private void OnStateChange(StateChangeData<AppState, AppTrigger> data)
    {
        if (_currentScreen != null)
        {
            Destroy(_currentScreen);
        }

        switch (data.NewState)
            {
                case AppState.MainMenu:
                    //Fade In (make some loading scren opacity 1(animated)
                    //Load scene
                    //Change screen
                    //Fade out
                    SceneManager.LoadScene("Menu");
                Context.Instance.AudioSystem.PlayMusic(new SoundSettings("Menu_GamePlaye"));
                    _currentScreen = Instantiate(_mainMenuScreen, _root);
                    break;
                case AppState.Gameplay:
                    SceneManager.LoadScene("GamePlay");
                Context.Instance.AudioSystem.PlayMusic(new SoundSettings("Menu_GamePlaye"));
                _currentScreen = Instantiate(_gameplayScreen, _root);
                    break;
                case AppState.WinScreen:
                    _currentScreen = Instantiate(_winScreen, _root);
                    break;
                case AppState.LooseScreen:
                    _currentScreen = Instantiate(_looseScreen, _root);
                    break;
                case AppState.AcceptRewards:
                    _currentScreen = Instantiate(_acceptRewards, _root);
                    break;
                case AppState.LootScreen:
                    _currentScreen = Instantiate(_lootScreen, _root);
                    break;
                case AppState.MenuOptionsScreen:
                        SceneManager.LoadScene("Options");
                    _currentScreen = Instantiate(_menuOptionScreen, _root);
                    break ;
            }
        }
    }
