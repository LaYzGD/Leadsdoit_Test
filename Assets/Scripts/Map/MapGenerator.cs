using UnityEngine;
using UnityEngine.Pool;

public class MapGenerator : MonoBehaviour
{
    [field: SerializeField] public MapPreset Map { get; private set; }

    private ObjectPool<GameObject> _pool;

    public void Initialize()
    {
        _pool = new(() => Instantiate(Map.GetPreset()),
                    (preset) => preset.SetActive(true),
                    (preset) => preset.SetActive(false),
                    (preset) => Destroy(preset),
                    false);
    }

    public void GenerateMap(Vector2 position)
    {
        var preset = _pool.Get();
        preset.transform.position = position;
        preset.transform.SetParent(transform);
    }

    public void DestoyMap(GameObject preset)
    {
        _pool.Release(preset);
    }
}
