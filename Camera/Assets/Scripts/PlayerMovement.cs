using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerEnum
    {
        Player1,
        Player2
    }
    
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _rotatespeed = 150;
    [SerializeField] private Camera _myCamera = default;
    [SerializeField] private PlayerEnum _player = default;
    
    private float moveX;
    private float moveZ;
    
    
    void Update()
    {
        switch (_player)
        {
            case PlayerEnum.Player1:
                moveX = Input.GetAxis("Horizontal");
                moveZ = Input.GetAxis("Vertical");
                break;
            case PlayerEnum.Player2:
                moveX = Input.GetAxis("MineHorizontal");
                moveZ = Input.GetAxis("MineVertical");
                break;
        }
        var moveDirection = new Vector3(moveX, 0, moveZ);
        Move(moveDirection);

        var rotateX = Input.GetAxis("Mouse X");
        var rotateXDirection = new Vector3(0, rotateX, 0);

        Rotate(rotateXDirection);
    }

    private void Move (Vector3 direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void Rotate(Vector3 directionX)
    {
        transform.Rotate(directionX * _rotatespeed * Time.deltaTime);
    }
}
