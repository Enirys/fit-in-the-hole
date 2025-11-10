using UnityEngine;
using UnityEngine.InputSystem;

//Rotates shape

public class Rotator : MonoBehaviour {

    // Update is called once per frame
    void Update ()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
    }
}
