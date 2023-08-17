using UnityEngine;
using UnityEngine.Pool;

public class EssenceSpawner : MonoBehaviour, IInitializable
{
    [Header("ObjectPool")]
    [SerializeField] protected bool _usePool = true;
    [SerializeField] protected int _spawnAmount = 10;
    protected ObjectPool<EssenceClass> _pool;
    protected Transform _transform;
    [Header("Essence params")]
    [SerializeField] protected EssenceClass _essencePrefab;
    [SerializeField] protected float _maxHealth = 5;
    [SerializeField] protected float _movementSpeed = 5;
    [SerializeField] protected float _collisionDamage = 2;
    [SerializeField] protected float _projResistance = 2;

    public virtual void Init()
    {
        _transform = GetComponent<Transform>();
        _pool = new ObjectPool<EssenceClass>(CreateEssence, PullEssence, KillEssence, DestroyEssence, false, 10, 20);
        InvokeRepeating(nameof(Spawn), .2f, .2f);
    }

    protected virtual void Spawn()
    {
        for (int i = 0; i < _spawnAmount; i++) CreateEssence();
    }

    protected void InitializeEssence(EssenceClass essence)
    {
        essence.Init(
            this,
            _maxHealth,
            _movementSpeed,
            _collisionDamage,
            _projResistance);
        essence.transform.position = _transform.position;
    }

    public virtual EssenceClass CreateEssence()
    {
        EssenceClass essence = Instantiate(_essencePrefab);
        InitializeEssence(essence);
        essence.SetPool(_pool);
        _pool.Release(essence);
        return essence;
    }

    public virtual void PullEssence(EssenceClass essence)
    {
        essence.transform.position = _transform.position;
        essence.gameObject.SetActive(true);
    }

    public void KillEssence(EssenceClass essence)
    {
        if (_usePool) essence.gameObject.SetActive(false);
        else DestroyEssence(essence);
    }

    public virtual void DestroyEssence(EssenceClass essence) => Destroy(essence.gameObject);
}