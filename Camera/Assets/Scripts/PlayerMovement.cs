using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerEnum
    {
        Player1,
        Player2
    }
    
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private PlayerEnum _player = default;
    [SerializeField] private string _InputHorizontal;
    [SerializeField] private string _InputVertical;
    
    private float moveX;
    private float moveZ;

    private void Start()
    {
        switch (_player)
        {
            case PlayerEnum.Player1:
                _InputHorizontal = "Horizontal";
                _InputVertical = "Vertical";
                break;
            case PlayerEnum.Player2:
                _InputHorizontal = "MineHorizontal";
                _InputVertical = "MineVertical";
                break;
        }
    }

    void Update()
    {
        moveX = Input.GetAxis(_InputHorizontal);
        moveZ = Input.GetAxis(_InputVertical);
        var moveDirection = new Vector3(moveX, 0, moveZ);
        Move(moveDirection);
    }

    private void Move (Vector3 direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}
