using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour
{
    [SerializeField] private List<string> _contactExeptions;
    [SerializeField] private List<Transform> _targetList;

    public List<Transform> TargetList { get { return _targetList; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool CanCollect = false;
        foreach (var item in _contactExeptions)
        {
            if (collision.gameObject.CompareTag(item))
            {
                CanCollect = false;
                continue;
            }
            CanCollect = true;
        }
        if (CanCollect)
            Collect(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _targetList.Remove(collision.transform);
    }

    private void Collect(Collider2D collision)
    {
        _targetList.Add(collision.GetComponent<Transform>());
    }

    public Transform FindClosest(Transform shooterTransform)
    {
        Transform _targetPosition = _targetList[0];
        float _closestDistance;
        float distance;
        _closestDistance = (shooterTransform.position - _targetList[0].position).sqrMagnitude;
        for (int i = 1; i < _targetList.Count; i++)
        {
            distance = (shooterTransform.position - _targetList[i].position).sqrMagnitude;
            if (_closestDistance > distance)
            {
                _closestDistance = distance;
                _targetPosition = _targetList[i];
            }
            else
                continue;
        }
        return _targetPosition;
    }
}
