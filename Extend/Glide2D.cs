﻿using UnityEngine;

public class Glide2D : MonoBehaviour
{
    [SerializeField]
    private GameObjectReference glider;
    [SerializeField]
    private Vector2Reference position;
    [SerializeField]
    private FloatReference time;
    [SerializeField]
    private BoolReference useRigidbody;

    [SerializeField]
    private ActionEvents events;

    private bool isGliding = false;

    private Rigidbody2D gliderRigidbody;
    private Vector2 glideStart;
    private Vector2 glideEnd;
    private float glideInverseTime;
    private float glideInterpolator;

    public void StartGliding()
    {
        if(useRigidbody.value)
        {
            gliderRigidbody = glider.value.GetComponent<Rigidbody2D>();
        }

        glideStart = glider.value.transform.position;
        glideEnd = position.value;
        glideInverseTime = 1.0f / time.value;
        glideInterpolator = 0;

        isGliding = true;
        events.start.Invoke();
    }

    public void StopGliding()
    {
        isGliding = false;
        events.stop.Invoke();
    }

    private void Update()
    {
        if (isGliding)
        {
            GlideStep();
        }
    }

    private void GlideStep()
    {
        if (glideInterpolator <= 1)
        {
            glideInterpolator += Time.deltaTime * glideInverseTime;
            
            if(useRigidbody.value)
            {
                gliderRigidbody.position = Vector2.Lerp(glideStart, glideEnd, glideInterpolator);
            }
            else
            {
                glider.value.transform.position = Vector2.Lerp(glideStart, glideEnd, glideInterpolator);
            }

            events.step.Invoke();
        }
        else
        {
            StopGliding();
        }
    }
}
