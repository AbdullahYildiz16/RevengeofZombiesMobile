
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    CharacterController characterController;
    const float gravity = 9.8f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        MoveCharacter();
    }

    Vector3 moveVector;
    private void MoveCharacter()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        moveVector = transform.TransformDirection(moveVector);
        if (!characterController.isGrounded)
        {
            moveVector.y -= Time.deltaTime * gravity;
        }
        characterController.Move(moveVector);
        
    }
}
