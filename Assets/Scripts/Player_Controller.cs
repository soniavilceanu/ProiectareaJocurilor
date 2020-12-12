﻿/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;

    public float jump_height = 2.0f;
    public bool is_grounded;
    public Vector3 jump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
    }

    void OnCollisionStay(Collision other)
    {
        is_grounded = true;
    }

    void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (move_horizontal, 0.0f, move_vertical);

        rb.AddForce(movement * speed);
        
        if(Input.GetKeyDown(KeyCode.Space) && is_grounded == true)
        {
            rb.AddForce(jump * jump_height, ForceMode.Impulse);
            is_grounded = false;
        }
    }
    
    /// <summary>
    /// OnCollisionStay is called once per frame for every collider/rigidbody
    /// that is touching rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    
    
}*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    //[SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rigidBodyComponent;

    private int count;
    public Text count_text;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
        count = 0;
        set_text_count();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            jumpKeyWasPressed = true;
        }
        

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    //fixed update is called once every physics updates
    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput, 0, verticalInput).normalized * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            count++;
            set_text_count();
        }
    }

    void set_text_count()
    {
        count_text.text = "Buna ziua, hai la sarmale!\nCate am adunat : " + count.ToString();
    }
}

