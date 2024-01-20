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
        MoveTracks();
        TrackScroll();
        offset = Time.time * scrollSpeed;
    }

    public void MoveTracks()
    {
        //前進
        if(moveVector.x > 0 && moveVector.y > 0)
        {
            float movementAmount = moveVector.y * moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * movementAmount);
        }

        //後退
        if (moveVector.x < 0 && moveVector.y < 0)
        {
            float movementAmount = moveVector.y * moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * movementAmount);
        }

        //左轉
        if(moveVector.x == 0 && moveVector.y != 0)
        {
            float rotationAmount = moveVector.y * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }

        //右轉
        if (moveVector.x != 0 && moveVector.y == 0)
        {
            float rotationAmount = moveVector.x * -rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }
    public void TrackScroll()
    {
        if(moveVector.x != 0)
        {
            Rrend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }

        if (moveVector.y != 0)
        {
            Lrend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }     
        
    }

    public void TrackMove(InputAction.CallbackContext ctx)
    {
        moveVector =  ctx.ReadValue<Vector2>();
        Debug.Log(moveVector);
    }
}
