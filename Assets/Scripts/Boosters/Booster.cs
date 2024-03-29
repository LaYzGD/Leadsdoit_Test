using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Booster : MonoBehaviour
{
    [SerializeField] private BoosterType _type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IBusterInteractable interactable))
        {
            interactable.HandleBusterEffect(_type);
        }
    }
}

public enum BoosterType 
{
    Speed,
    Shield,
    Magnet
}