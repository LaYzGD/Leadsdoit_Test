using UnityEngine;

public class Root : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private MapChecker _checker;
    [SerializeField] private MapPointer _pointer;
    [Header("Camera")]
    [SerializeField] private CameraFollow _cameraFollow;
    [Header("Player")]
    [SerializeField] private PlayableCar _car;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _mapGenerator.Initialize();
        _car.Initialize(_health);
        _cameraFollow.Initialize(_car.transform);
        _checker.Initialize(_mapGenerator);
        _pointer.Initialize(_mapGenerator);
    }
}
