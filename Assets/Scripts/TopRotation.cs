using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopRotation : MonoBehaviour
{
    private Vector2 rotateVector;

    [Header("旋轉速度")]
    public float rotationSpeed = 5f;

    [Header("上迴旋體物件")]
    public GameObject topRotation;

    private void Update()
    {
        _TopRotation();
    }
    public void _TopRotation()
    {
        // 计算旋转角度
        float rotationAmount = rotateVector.x * rotationSpeed * Time.deltaTime;

        // 应用旋转
        topRotation.transform.Rotate(Vector3.up, rotationAmount);
    }
    public void Rotation(InputAction.CallbackContext ctx)
    {
        rotateVector = ctx.ReadValue<Vector2>();
        Debug.Log(rotateVector);
    }
}
