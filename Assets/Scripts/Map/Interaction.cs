using UnityEngine;

[CreateAssetMenu(menuName = "Data/Interaction", fileName = "New Interaction")]
public class Interaction : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float Friction { get; private set; }

    public override string ToString()
    {
        return $"Damage: {Damage}, Deceleration: {Friction}";
    }
}
