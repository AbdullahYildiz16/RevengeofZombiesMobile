using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGun : MonoBehaviour
{
    public GameObject ParentObje;
    public float moveAmount;
    public float moveSpeed;
    float moveX;
    float moveY;
    public Vector3 defaultParentObjePos;
    public Vector3 newParentObjePos;
    public FixedTouchField FixedTouchField;



    void Start()
    {

        defaultParentObjePos = transform.localPosition;

    }

    
    void Update()
    {
        moveX = FixedTouchField.TouchDist.x * Time.deltaTime * moveAmount;

        moveY = FixedTouchField.TouchDist.y * Time.deltaTime * moveAmount;

        newParentObjePos = new Vector3(defaultParentObjePos.x + moveX, defaultParentObjePos.y + moveY, defaultParentObjePos.z);

        ParentObje.transform.localPosition = Vector3.Lerp(ParentObje.transform.localPosition, newParentObjePos, moveSpeed * Time.deltaTime);
        /*
        moveX = Input.GetAxis("Mouse X") * Time.deltaTime * moveAmount;

        moveY = Input.GetAxis("Mouse Y") * Time.deltaTime * moveAmount;

        newParentObjePos = new Vector3(defaultParentObjePos.x + moveX, defaultParentObjePos.y + moveY, defaultParentObjePos.z);

        ParentObje.transform.localPosition = Vector3.Lerp(ParentObje.transform.localPosition, newParentObjePos, moveSpeed * Time.deltaTime);
        */
    }
}
