using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    private bool onGround = true;
    public int jumpStrength = 100;
    public int acceleration = 2;
    public int maxSpeed = 20;
    private Rigidbody2D ourRigidBody;


    // Use this for initialization
    void Start()
    {
        ourRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // Jumping
        // ON Jump pressed IF player is on ground 
        if (Input.GetButtonDown("Jump") && onGround)
        {
            // then add a force going up with the amount of power: jumpStrength
            ourRigidBody.AddForce(Vector2.up * jumpStrength);
        }

        // IF left or right is down
        // AND our velocity is less than maxSpeed
        if (Input.GetAxis("Horizontal") != 0f && Mathf.Abs(ourRigidBody.velocity.x) < maxSpeed)
        {
            // give us some speed going right or left (based on Input) with the amount of power: acceleration
            ourRigidBody.AddForce(Vector2.right * acceleration * Input.GetAxis("Horizontal"));
        }

        // How can we know if we're on the ground?
        // We use a "Ray" which is like a laser
        // We'll have a whole lesson dealing with this.
        // For now, what this does is lets us know if there is a plaform 0.5 units beneath us.
        // If so, we're on the ground. Otherwise, we're not.
        RaycastHit2D rayToGround = Physics2D.Raycast(this.transform.position, Vector2.down, 0.5f);

        if (rayToGround)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

    }
}
