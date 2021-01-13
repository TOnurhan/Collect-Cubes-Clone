using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] float speed = default;
    private Vector3 direction;
    Vector2 firstPos, targetPos;
    [SerializeField]RectTransform rect = default;
    [SerializeField] Text touchToStart = default;

    void Initialized()
    {
        EventManager.PointerDragged += Move;
        EventManager.PointerUpped += Stop;
        EventManager.PointerDowned += Touched;
    }

    private void Awake()
    {
        Initialized();
        rb = GetComponent<Rigidbody>();
        LeanTween.alphaText(touchToStart.rectTransform, 0f, 1f).setEaseInCubic().setLoopPingPong();
    }

    public void Move(PointerEventData pointerEventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, pointerEventData.position, pointerEventData.pressEventCamera, out targetPos);
        var dragPos = targetPos - firstPos;
        direction = new Vector3(dragPos.x / Screen.width, 0, dragPos.y / Screen.height);

        if (pointerEventData.dragging)
        {
            rb.velocity = direction * speed;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }
    }

    public void Stop(PointerEventData pointerEventData)
    {//LERP
        //rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.1f);
        rb.velocity = Vector3.zero;
    }

    public void Touched(PointerEventData pointerEventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, pointerEventData.position, pointerEventData.pressEventCamera, out firstPos);
        touchToStart.enabled = false;
    }
}
