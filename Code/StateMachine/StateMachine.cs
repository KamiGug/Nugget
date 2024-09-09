using System;
using Godot;
using StateMachine.States;
using StateMachine.Behaviours;

namespace StateMachine
{
    public abstract partial class AbstracStateMachine : AbstractComponent
    {
        public AbstractState CurrentState { get; set; }
        public AbstractBehaviour CurrentBehaviour { get; set; }
    }
}