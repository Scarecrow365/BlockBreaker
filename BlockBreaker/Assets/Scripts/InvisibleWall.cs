using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    [SerializeField] private Side _side;
    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        SetPosition();
        SetSize();
    }

    private void SetPosition()
    {
        switch (_side)
        {
            case Side.Down:
                transform.position = new Vector3(transform.position.x, 0 - (_collider.size.y / 2));
                break;
            case Side.Up:
                transform.position = new Vector3(transform.position.x, NewPosY + (_collider.size.y / 2));
                break;
            case Side.Left:
                transform.position = new Vector3((-NewPosX / 2) - (_collider.size.x / 2), transform.position.y);
                break;
            case Side.Right:
                transform.position = new Vector3((NewPosX / 2) + (_collider.size.x / 2), transform.position.y);
                break;
        }
    }

    private void SetSize()
    {
        if (_side == Side.Up || _side == Side.Down)
            _collider.size = new Vector2(NewPosX, _collider.size.y);
        else if (_side == Side.Left || _side == Side.Right)
            _collider.size = new Vector2(_collider.size.x, NewPosY);
    }

    private float NewPosX => 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
    private float NewPosY => 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).y);

    private enum Side
    {
        Up,
        Down,
        Left,
        Right
    }
}
