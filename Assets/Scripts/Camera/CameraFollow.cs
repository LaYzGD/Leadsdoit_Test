using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;
    public void Initialize(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (!_target) return; 

        transform.position = new Vector3(transform.position.x, _target.position.y, transform.position.z);
    }
}
