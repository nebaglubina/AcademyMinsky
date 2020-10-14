using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerEnum
    {
        Player1,
        Player2
    }
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotatespeed;
    [SerializeField] private Camera _myCamera;
    [SerializeField] private Camera _weaponCamera;
    [SerializeField] private PlayerEnum _player;

    private bool _isZoomed;
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
        var rotateY = Input.GetAxis("Mouse Y");
        var rotateXDirection = new Vector3(0, rotateX, 0);
        var rotateYDirection = new Vector3(-rotateY, 0, 0);
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Zoom();
        }


        Rotate(rotateXDirection, rotateYDirection);
        //var e = _myCamera.transform.localEulerAngles;
        //e.x = Mathf.Clamp(e.x, -60, 60);
        //_myCamera.transform.localEulerAngles = e;
        //_myCamera.transform.localEulerAngles = new Vector3(Mathf.Clamp(_myCamera.transform.rotation.x, -60, 60), _myCamera.transform.rotation.y, _myCamera.transform.rotation.z);
    }

    private void Move (Vector3 direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void Rotate(Vector3 directionX, Vector3 directionY)
    {
        transform.Rotate(directionX * _rotatespeed * Time.deltaTime);
        _myCamera.transform.Rotate(directionY * _rotatespeed * Time.deltaTime);
    }

    private void Zoom()
    {
        _myCamera.fieldOfView = _isZoomed ? 30 : 60;
        _isZoomed = !_isZoomed;
    }
}
