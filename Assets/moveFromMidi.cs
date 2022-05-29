using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.HighDefinition.Attributes;

public class moveFromMidi : MonoBehaviour
{
    public VfxMidi Midi; 
    public float minDistanceZ;

    public float maxDistanceZ;
    public float minDistanceY;

    public float maxDistanceY;
    // Start is called before the first frame update
    private void Awake()
    {
        Midi = new VfxMidi();
        //Midi.camera.cameraZ.started += ctx => move(ctx.ReadValue<float>());
    }


    void OnEnable()
    {
        Midi.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var valueZ = Midi.camera.cameraZ.ReadValue<float>();
        var valueY = Midi.camera.cameraY.ReadValue<float>();
        var mappedZ = Mathf.Lerp(minDistanceZ, maxDistanceZ, valueZ);
        var mappedY = Mathf.Lerp(minDistanceY, maxDistanceY, valueY);
        var x = transform.localPosition.x;
        var y = mappedY;
        var z = mappedZ;
        
        transform.localPosition = new Vector3(x,y,z);
    }
}
