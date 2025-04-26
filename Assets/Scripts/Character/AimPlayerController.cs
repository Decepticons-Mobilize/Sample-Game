using UnityEngine;

public class AimPlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5.0f;
    [SerializeField] LayerMask _aimLayerMask;

    Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        AimTowardMouse();

        // Reading Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 charMovement = new Vector3(horizontalInput, 0, verticalInput);

        // Movement
        if (charMovement.magnitude > 0)
        {
            charMovement.Normalize();
            charMovement *= _speed * Time.deltaTime;
            transform.Translate(charMovement, Space.World);
        }

        // Char Animation
        float velocityZ = Vector3.Dot(charMovement.normalized, transform.forward);
        float velocityX = Vector3.Dot(charMovement.normalized, transform.right);

        _animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        _animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }

    private void AimTowardMouse() 
    { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _aimLayerMask)) 
        {
            Vector3 _direction = hitInfo.point - transform.position;
            _direction.y = 0f;
            _direction.Normalize();
            transform.forward = _direction;
        }
    }
}
