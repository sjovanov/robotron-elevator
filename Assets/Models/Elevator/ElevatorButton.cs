using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public int floorShift = 1;


    void Start()
    {
        // OnMouseDown();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Elevator e = GetComponentInParent<Elevator>();

        if (e == null)
            return;

        e.OnButtonPress(floorShift);
    }
}
