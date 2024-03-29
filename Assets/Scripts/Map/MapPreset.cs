using UnityEngine;

[CreateAssetMenu(menuName = "Map/MapPreset", fileName = "New MapPreset")]
public class MapPreset : ScriptableObject
{
    [field: SerializeField] public float DistanceToNextPointerPosition { get; private set; }

    [SerializeField] private GameObject[] _presets;

    public GameObject GetPreset()
    {
        return _presets[Random.Range(0, _presets.Length)];
    }
}
