using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftJoystick : MonoBehaviour
{
    private Vector2 LeftJoystickVector;

    [Header("旋轉速度")]
    public float rotationSpeed = 20f;

    [Header("二臂速度")]
    public float moveSpeed = 5f;

    [Header("上迴旋體物件")]
    public GameObject topRotation;
    [Header("二臂物件")]
    public GameObject dipper;

    private void Update()
    {
        TopRotation();
        Dipper();

        Debug.LogError(dipper.transform.rotation.x);

    }

    //上迴旋體旋轉
    public void TopRotation()
    {
        // 计算旋转角度
        float rotationAmount = LeftJoystickVector.x * rotationSpeed * Time.deltaTime;

        // 应用旋转
        topRotation.transform.Rotate(Vector3.up, rotationAmount);
        //Camera.transform.Rotate(Vector3.up, rotationAmount);
    }

    //二臂

    public void Dipper()
    {

        if(LeftJoystickVector.y == -1 && dipper.transform.rotation.x < 0.4 || LeftJoystickVector.y == 1 && dipper.transform.rotation.x > -0.65 )
        {
            float rotationAmount = LeftJoystickVector.y * moveSpeed * Time.deltaTime;

            dipper.transform.Rotate(Vector3.left, rotationAmount);
        }
            
        
    }
    public void _LeftJoystick(InputAction.CallbackContext ctx)
    {
        LeftJoystickVector = ctx.ReadValue<Vector2>();
        Debug.Log(LeftJoystickVector);
    }
}
