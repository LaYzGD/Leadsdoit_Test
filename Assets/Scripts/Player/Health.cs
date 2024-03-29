using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image[] _healthContainers;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = 3;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0) return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Debug.Log("Destroyed");
        }

        UpdateUI();
        Debug.Log(_currentHealth);
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _healthContainers.Length; i++)
        {
            _healthContainers[i].gameObject.SetActive(i < _currentHealth);
        }
    }
}
