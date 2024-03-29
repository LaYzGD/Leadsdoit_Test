using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MapPointer : MonoBehaviour
{
    private MapPreset _map;
    public void Initialize(MapGenerator generator)
    {
        _map = generator.Map;
    }

    public void SetNextPosition()
    {
        float currentVerticalPosition = transform.position.y;
        Vector2 nextPosition = new(transform.position.x, currentVerticalPosition + _map.DistanceToNextPointerPosition);
        transform.position = nextPosition;
    }
}
