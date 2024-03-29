using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectable : MonoBehaviour
{
    protected Action onCollect;

    public virtual void Initialize(Vector2 position, Action collectAction)
    {
        transform.position = position;
        onCollect = collectAction;
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out PlayableCar car))
        {
            onCollect();
        }
    }
}
