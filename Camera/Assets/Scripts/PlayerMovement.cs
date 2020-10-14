using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveZ = Input.GetAxis("Vertical");
        var direction = new Vector3(moveX, 0, moveZ);
        Move(direction);
    }

    private void Move (Vector3 direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}
