using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Jump = 5;
    public float speed = 20;
    public TextMeshProUGUI countText;
    public GameObject winTextobject;
    

    private Rigidbody rb;
    public int Score;
    private float movementX;
    private float movementY;
   
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Score = 0;

        SetCountText();
        winTextobject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    // skal rettes så bolden kan hoppe

    private void OnJump(InputValue JumpValue)
    {
        rb.AddForce(Vector3.up * Jump, ForceMode.Impulse);
    }


    void SetCountText()
    {
        countText.text = "Score:" + Score.ToString();
        if(Score >= 13)
        {
            winTextobject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {


        Vector3 movement = new Vector3(movementX, 0f, movementY);

        rb.AddForce(movement * speed);

    


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Score = Score + 1;
            SetCountText();
        }
    }
}
