using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDownMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private bool move = false;
    private Vector3 currentPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move){
            transform.parent.position -= new Vector3(0, 1f * Time.deltaTime, 0);
        }

        if (transform.parent.position.y <= currentPosition.y - 4.75 && move){
            move = false;
        }
    }

    void OnMouseDown(){
        move = true;
        currentPosition = transform.parent.position;
    }
}
