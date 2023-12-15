using System;


    public interface IAppSystem
    {
        AppState CurrentState { get; }
        void Trigger(AppTrigger trigger);
        event Action<StateChangeData<AppState, AppTrigger>> OnStateChange;
    }

    public class AppSystem : IAppSystem
    {
        private StateMachine<AppState, AppTrigger> _stateMachine;

        public AppState CurrentState => _stateMachine.CurrentState;

        public event Action<StateChangeData<AppState, AppTrigger>> OnStateChange
        {
            add => _stateMachine.OnStateChange += value;
            remove => _stateMachine.OnStateChange -= value;
        }

        public AppSystem()
        {
            _stateMachine = new StateMachine<AppState, AppTrigger>(AppState.Loading);

            _stateMachine.AddTransition(AppState.Loading, AppTrigger.ToMainMenu, AppState.MainMenu);

            _stateMachine.AddTransition(AppState.MainMenu, AppTrigger.ToMenuOptionsScreen, AppState.MenuOptionsScreen);
            _stateMachine.AddTransition(AppState.MenuOptionsScreen, AppTrigger.ToMainMenu, AppState.MainMenu);

            _stateMachine.AddTransition(AppState.MainMenu, AppTrigger.ToGameplay, AppState.Gameplay);

            _stateMachine.AddTransition(AppState.WinScreen, AppTrigger.ToMainMenu, AppState.MainMenu);
            _stateMachine.AddTransition(AppState.LooseScreen, AppTrigger.ToMainMenu, AppState.MainMenu);

            _stateMachine.AddTransition(AppState.Gameplay, AppTrigger.ToWinScreen, AppState.WinScreen);
            _stateMachine.AddTransition(AppState.Gameplay, AppTrigger.ToLooseScreen, AppState.LooseScreen);
            _stateMachine.AddTransition(AppState.Gameplay, AppTrigger.ToMainMenu, AppState.MainMenu);
            
            _stateMachine.AddTransition(AppState. LootScreen, AppTrigger.ToAcceptRewards, AppState.AcceptRewards);
            _stateMachine.AddTransition(AppState. AcceptRewards, AppTrigger.ToLootScreen, AppState.LootScreen);
            _stateMachine.AddTransition(AppState.Gameplay, AppTrigger.ToLootScreen, AppState.LootScreen);
            _stateMachine.AddTransition(AppState. LootScreen, AppTrigger.ToLootScreen, AppState.LootScreen);
        }


        public void Trigger(AppTrigger trigger)
        {
            _stateMachine.SetTrigger(trigger);
        }
    }

    public enum AppState
    {
        Loading,
        MainMenu,
        Gameplay,
        WinScreen,
        LooseScreen,
        MenuOptionsScreen,
        AcceptRewards,
        LootScreen
    }

    public enum AppTrigger
    {
        ToMainMenu,
        ToGameplay,
        ToWinScreen,
        ToLooseScreen,
        ToMenuOptionsScreen,
        ToLootScreen,
        ToAcceptRewards
    }
