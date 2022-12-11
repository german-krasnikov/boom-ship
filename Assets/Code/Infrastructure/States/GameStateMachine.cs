using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class GameStateMachine : MonoBehaviour, IService
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public void Construct(AllServices services)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services),
                [typeof(GameLoopState)] = new GameLoopState(this, services)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        public void Update()
        {
            _activeState?.Tick(Time.deltaTime);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            _states[typeof(TState)] as TState;
    }
}