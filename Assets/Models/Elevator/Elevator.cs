using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform door;
    public Transform walls;

    public GameObject floorHeightObject;
   
    public enum State { Open, Closing, Closed, Opening };

    public State state = State.Open;

    private Vector3 currentPositionWalls;

    public float floorHeight;

    int currentFloor = 0;

    int targetFloor = 0;
    float distanceToMove = 0;
    float distanceToMoveForComparison = 0;
    public float elevatorMaxSpeed = 2;
    float elevatorSpeed = 0;
    void Start()
    {
        floorHeight = floorHeightObject.GetComponent<MeshRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Open:
            break;
            case State.Opening:
                door.position -= new Vector3(1 * Time.deltaTime, 0, 0);
                if(door.localScale.x > 85.72202){
                    door.localScale -= new Vector3(6 * Time.deltaTime, 0, 0);
                }
                if (door.position.x <= -0.5173443f){
                    state = State.Open;
                }
            break;
            case State.Closing:
                door.position += new Vector3(1 * Time.deltaTime, 0, 0);
                if(door.localScale.x < 100){
                    door.localScale += new Vector3(6 * Time.deltaTime, 0, 0);
                }
                if (door.position.x >= 1.974f){
                    state = State.Closed;
                    elevatorSpeed = 1;
                }
            break;
            case State.Closed:
                float d = Mathf.Sign(distanceToMove) * elevatorSpeed * Time.deltaTime;
                
                if (Mathf.Abs(d) > Mathf.Abs(distanceToMove))
                {
                    d = distanceToMove;
                    state = State.Opening;
                    elevatorSpeed = 0;
                }
                else
                {
                    distanceToMove -= d;
                    if (Mathf.Abs(distanceToMove) > Mathf.Abs(distanceToMoveForComparison/2) && elevatorSpeed < elevatorMaxSpeed)
                    {
                        elevatorSpeed+=0.01f;
                    }
                    else if (Mathf.Abs(distanceToMove) < Mathf.Abs(distanceToMoveForComparison/2) && elevatorSpeed > 1)
                    {
                        elevatorSpeed-=0.01f;
                    }
                }

                walls.localPosition = new Vector3(walls.localPosition.x, (walls.localPosition.y - d) % floorHeight, walls.localPosition.z);
                break;
            default:
            break;
        }
    }

    public void OnButtonPress(int floorShift)
    {
        switch (state)
        {
            case State.Open:
            case State.Opening:
                targetFloor = currentFloor + floorShift;
                distanceToMove = (targetFloor - currentFloor) * floorHeight;
                distanceToMoveForComparison = distanceToMove;
                state = State.Closing;
                break;
            case State.Closing:
            case State.Closed:
            default:
            break;
        }
        currentPositionWalls = walls.position;
    }
}
