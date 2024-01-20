using UnityEngine;

public class TreadTextureScroll : MonoBehaviour
{
    
    public float scrollSpeed = 1.0f;
    public Renderer Lrend;
    public Renderer Rrend;

    void Start()
    {
    }

    void Update()
    {

        float offset = Time.time * scrollSpeed;

        // 只有在水平输入不为零时才进行纹理偏移
        if (Input.GetKey("a"))
        {
            // 获取材质偏移量
            

            // 设置主纹理坐标偏移量
            Lrend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }

        if (Input.GetKey("d"))
        {
            // 获取材质偏移量


            // 设置主纹理坐标偏移量
            Rrend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }

    }

}