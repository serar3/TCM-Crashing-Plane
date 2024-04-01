using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovebyVelocity : MonoBehaviour
{
    public Vector2 _direction = Vector2.right;
    public float _speed = 1.0f;

    private void Start()
    {
        //Applies an initial velocity to the rigidbody
        Rigidbody2D l_rigidbody2D = GetComponent<Rigidbody2D>();
        l_rigidbody2D.velocity = _direction.normalized * _speed;
    }
}
