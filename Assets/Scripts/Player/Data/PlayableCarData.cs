using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayableCar", fileName = "New PlayableCarData")]
public class PlayableCarData : ScriptableObject
{
    [field: SerializeField] public Vector2 BaseMovementSpeed { get; private set; }
    [field: SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float AccelerationTime { get; private set; }
    [field: SerializeField] public float Brake { get; private set; }
    [field: SerializeField] public float BrakeTime { get; private set; }
    [field: SerializeField] public float Deceleration { get; private set; }
    [field: SerializeField] public float DecelerationTime { get; private set; }
    [field: SerializeField] public float MaxSpeed { get; private set; }
    [field: SerializeField] public float MinSpeed { get; private set; }
}
