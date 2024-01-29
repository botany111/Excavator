using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightJoystick : MonoBehaviour
{
    private Vector2 RightJoystickVector;

    [Header("�j�u�t��")]
    public float boomSpeed = 5f;

    public float bicketSpeed = 5f;

    [Header("�j�u����")]
    public GameObject boom;

    [Header("���檫��")]
    public GameObject bucket;
    void Update()
    {
        Debug.LogError(bucket.transform.rotation.x);

        Boom();
        
        
        Bucket();
    }

    //�j�u
    public void Boom()
    {
        if (RightJoystickVector.y == -1 && boom.transform.rotation.x > -0.30 || RightJoystickVector.y == 1 && boom.transform.rotation.x < 0.1)
        {
            float BoomAmount = RightJoystickVector.y * boomSpeed * Time.deltaTime;

            boom.transform.Rotate(Vector3.right * BoomAmount);
        }

    }

    //����
    public void Bucket()
    {
        if(RightJoystickVector.x == -1 && bucket.transform.rotation.x < 0.6 || RightJoystickVector.x == 1 && bucket.transform.rotation.x > -0.7)
        {
            float BoomAmount = RightJoystickVector.x * bicketSpeed * Time.deltaTime;
            bucket.transform.Rotate(Vector3.left * BoomAmount);
        }else if(RightJoystickVector.x == 1 )
        {
            
        }
        
    }

    public void _RightJoystick(InputAction.CallbackContext ctx)
    {
        RightJoystickVector = ctx.ReadValue<Vector2>();
        Debug.Log(RightJoystickVector);
    }
}
