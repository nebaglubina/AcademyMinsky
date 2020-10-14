using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotatespeed;
    [SerializeField] private Camera _myCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveZ = Input.GetAxis("Vertical");
        var moveDirection = new Vector3(moveX, 0, moveZ);

        var rotateX = Input.GetAxis("Mouse X");
        var rotateY = Input.GetAxis("Mouse Y");
        var rotateXDirection = new Vector3(0, rotateX, 0);
        var rotateYDirection = new Vector3(-rotateY, 0, 0);
        
        

        Move(moveDirection);
        Rotate(rotateXDirection, rotateYDirection);
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
}
