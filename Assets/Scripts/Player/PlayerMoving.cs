using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public float thrust = 20f;
   
    private float turnAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        this.MoveByRigidBody();
    }
    public void MoveByRigidBody()
    {
        float vertical = InputManager.instance.vertical;
        float horizontal =  InputManager.instance.horizontal;
        turnAngle += horizontal * speed * Time.deltaTime;
        turnAngle = Mathf.Clamp(turnAngle, -45f, 45f);
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.rotation = Quaternion.Euler(0f, turnAngle, 0f);
        rb.AddForce(direction * this.thrust);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
