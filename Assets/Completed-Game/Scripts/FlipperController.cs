using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{

    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 20000f;
    public float flipperDamper = 100f;
    public KeyCode inputKey;

    HingeJoint hinge;

    void Awake()
    {
    }

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        if (Input.GetKey(inputKey) == true)
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = restPosition;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }

    void FixedUpdate()
    {

    }
}
