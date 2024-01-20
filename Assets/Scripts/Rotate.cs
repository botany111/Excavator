using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public GameObject rotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获取Q和E键的输入
        float rotateInput = Input.GetAxis("Rotate");

        // 根据输入旋转物体
        RotateVolume(rotateInput);
    }

    void RotateVolume(float input)
    {
        // 计算旋转角度
        float rotationAmount = input * rotationSpeed * Time.deltaTime;

        // 通过Quaternion.Euler创建旋转
        Quaternion rotation = Quaternion.Euler(0f, rotationAmount, 0f);

        // 将物体旋转
        transform.Rotate(rotation.eulerAngles);
    }
}
