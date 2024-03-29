using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private Interaction _interaction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IObstacleInteractable interactable))
        {
            interactable.HandleEffect(_interaction);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IObstacleInteractable interactable))
        {
            interactable.StopEffect();
        }
    }
}
