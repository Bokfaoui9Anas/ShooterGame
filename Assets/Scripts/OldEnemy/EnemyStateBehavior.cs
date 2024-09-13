using System;

namespace Enemy
{
    public class EnemyStateBehavior
    {
        public event Action OnFinished;

        public virtual void OnStart()
        {
            throw new NotImplementedException();
        }

        public virtual void OnEnd()
        {
            throw new NotImplementedException();
        }
    }
    public class StateTransition<T> where T : System.Enum
    {
        public StateTransitionType transitionType;
        public delegate bool EvaluateDelegate(out T nextState);
        public EvaluateDelegate Evaluate { get; set; }

        public StateTransition(EvaluateDelegate evaluate, StateTransitionType transitionType = StateTransitionType.Independent)
        {
            this.transitionType = transitionType;
            Evaluate = evaluate;
        }
    }

    public enum StateTransitionType
    {
        Independent,
        OnFinish,
    }
}