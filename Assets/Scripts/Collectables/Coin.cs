using UnityEngine;

public class Coin : Collectable
{
    [SerializeField] private float _attractionSpeed = 5f;

    private Transform _target;
    private bool _canAttract;

    public void AttractTo(Transform target)
    {
        _target = target;
        _canAttract = true;
    }

    private void Update()
    {
        if (!_canAttract) return;

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _attractionSpeed * Time.deltaTime);
    }
}