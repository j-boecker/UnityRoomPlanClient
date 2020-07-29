using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCamera : MonoBehaviour
{
    private FreeFlyCamera _freeFlyCamera;
    // Start is called before the first frame update
    void Start()
    {
        _freeFlyCamera = GetComponent<FreeFlyCamera>();
        _freeFlyCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _freeFlyCamera.enabled = !_freeFlyCamera.enabled;
    }
}
