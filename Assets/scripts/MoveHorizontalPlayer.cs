using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveHorizontalPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
 
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        _rigidbody2D.velocity = new Vector2(moveInput * _speed, _rigidbody2D.velocity.y);
    }
}
