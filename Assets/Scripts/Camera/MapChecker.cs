using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MapChecker : MonoBehaviour
{
    private MapGenerator _mapGenerator;

    public void Initialize(MapGenerator mapGenerator)
    {
        _mapGenerator = mapGenerator;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MapPointer pointer))
        {
            _mapGenerator.GenerateMap(pointer.transform.position);
            pointer.SetNextPosition();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MapPointer pointer))
        {
            return;
        }

        _mapGenerator.DestoyMap(collision.gameObject);
    }
}
