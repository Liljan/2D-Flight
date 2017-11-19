using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Throttle
    //public float force = 10.0f;
    //public float torque = 10.0f;

    public float maxSpeed = 10.0f;
    public float minSpeed = 1.0f;

    public float rotationSpeed = 10.0f;

    private float _debugSpeed;

    // Turning

    private Rigidbody2D _rb2d;

    public void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }


    private void FixedUpdate()
    {
        float horizontal = -Input.GetAxis("Horizontal");
        float throttle = Input.GetAxis("Throttle");

        // map throttle from [-1,1] to [0,1]


        //Debug.Log(horizontal + " , " + throttle);

        //_rb2d.AddForce(force * transform.forward);
        //_rb2d.AddTorque(torque * horizontal);

        float rot = rotationSpeed * horizontal * Time.deltaTime;
        _rb2d.rotation += rot;

        float speed = CalculateSpeed(throttle);

        Vector2 vel = transform.up * speed;
        _debugSpeed = speed;

        _rb2d.velocity = vel;
    }

    private float CalculateSpeed(float rawThrottle)
    {
        // map throttle from [-1,1] to [0,1]
        rawThrottle += 1.0f;
        rawThrottle /= 2.0f;

        return Mathf.Lerp(minSpeed,maxSpeed,rawThrottle);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 90), "Throttle: " + _debugSpeed);
    }


}

