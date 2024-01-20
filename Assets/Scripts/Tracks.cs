using UnityEngine;
using UnityEngine.InputSystem;

public class Tracks : MonoBehaviour
{
    [Header("履帶移動")]
    public float rotationSpeed = 5f;
    public float moveSpeed = 1f;
    private Vector2 moveVector;

    [Header("履帶材質偏移")]
    public float scrollSpeed = 1.0f;
    public Renderer Lrend;
    public Renderer Rrend;
    public float offset;

    void Update()
    {

        // 根据输入旋转履带
        RotateTracks();
        MoveTracks();
        TrackScroll();
        offset = Time.time * scrollSpeed;

    }

    public void MoveTracks()
    {
        float movementAmount = moveVector.y * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * movementAmount);

        
    }
    public void RotateTracks()
    {
        if(moveVector != Vector2.zero)
        {
            float rotationAmount = moveVector.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }

    public void TrackScroll()
    {
        if(moveVector.x < 0)
        {
            Rrend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }

        if (moveVector.x > 0)
        {
            Lrend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }

        if(moveVector.y != 0)
        {
            Rrend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            Lrend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
       
        
    }

    public void TrackMove(InputAction.CallbackContext ctx)
    {
        moveVector =  ctx.ReadValue<Vector2>();
        Debug.Log(moveVector);
    }
}
