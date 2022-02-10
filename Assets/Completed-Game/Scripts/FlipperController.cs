using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperController : MonoBehaviour
{

    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 20000f;
    public float flipperDamper = 100f;
    public KeyCode inputKey;

    private bool pressed = false;

    HingeJoint hinge;

    void Awake()
    {
    }

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    public void Flippers(InputAction.CallbackContext context)
    {
        float pressedAmt = context.ReadValue<float>();
        if (pressedAmt > 0)
        {
            SoundManager.Instance.playFlipper();
            pressed = true;
        }
        else
        {
            pressed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        if (pressed)
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

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void FixedUpdate()
    {

    }
}
