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
        Boom();
        Bucket();
    }

    //�j�u
    public void Boom()
    {
        float BoomAmount = RightJoystickVector.y * boomSpeed * Time.deltaTime;

        boom.transform.Rotate(Vector3.right * BoomAmount);
    }

    //����
    public void Bucket()
    {
        float BoomAmount = RightJoystickVector.x* bicketSpeed * Time.deltaTime;
        bucket.transform.Rotate(Vector3.left * BoomAmount);
    }

    public void _RightJoystick(InputAction.CallbackContext ctx)
    {
        RightJoystickVector = ctx.ReadValue<Vector2>();
        Debug.Log(RightJoystickVector);
    }
}
