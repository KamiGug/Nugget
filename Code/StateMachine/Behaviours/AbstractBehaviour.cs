using System;
using Godot;

namespace StateMachine.Behaviours
{
    public abstract partial class AbstractBehaviour : AbstractComponent
    {
        private bool IsInterruptable { get; set; }

        public abstract void Start();

        public abstract void Run();

        public abstract void Stop();

    }
}