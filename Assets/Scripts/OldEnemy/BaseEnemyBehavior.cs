using UnityEngine;

namespace Enemy
{
    public abstract class BaseEnemyBehavior : MonoBehaviour
    {
        public abstract void Attack();
        public abstract void OnAnimationCallback();

    }
}
