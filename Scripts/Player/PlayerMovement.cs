
using UnityEngine;

public class PlayerMovement : Player
{
    [SerializeField]private FloatingJoystick floatingJoystick ;
    [SerializeField] private float speedConstant;
    private Vector3 _direction,_position;
    private float _horizontalInput,_verticalInput;
    
    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            JoystickMovement();
        }
        else
        {
            animator.SetBool(IsMoving,false);
        }
    }
    private void JoystickMovement()
    {
        animator.SetBool(IsMoving,true);
        _horizontalInput = floatingJoystick.Horizontal;
        _verticalInput = floatingJoystick.Vertical;
        
        _position=new Vector3(_horizontalInput*speedConstant*Time.fixedDeltaTime,0,_verticalInput*speedConstant*Time.fixedDeltaTime);
        rb.velocity += _position;
        
        _direction = Vector3.forward * _verticalInput + Vector3.right * _horizontalInput;
        rb.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(_direction),10f*Time.fixedDeltaTime);
    }

    
}
