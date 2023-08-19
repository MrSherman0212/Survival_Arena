public class EnemyHealthSystem : HealthSystem
{
    public delegate void DieEvent();
    public static DieEvent OnDieEvent;

    public override void Die()
    {
        base.Die();
        OnDieEvent.Invoke();
    }
}
