using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Variable declaration
    private GameMaster gm;
    private GameObject[] gatherCP;
    private bool _raiseFlag;
    private bool _lowerFlag;
    private GameObject _upwardFlag;
    private GameObject _downwardFlag;


    void Awake()
    {
        //get the gameMaster object
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        //initially set all objects to null
        _upwardFlag = null;
        _downwardFlag = null;

        //initially set all boolean variables to false
        _raiseFlag = false;
        _lowerFlag = false;
    }

    //Call this function when the box collider on the CP flag interacts with another object
    void OnTriggerEnter2D(Collider2D other)
    {
        //run if the CP interacts eith the player
        if(other.CompareTag("Player"))
        {
            //run if the checkpoint hit is the current active checkpoint
            if (gm.activeCP == this.transform.parent.gameObject)
            {
                return;
            }

            //run if there is a flag that is up which needs to be lowered
            if(gm.activeCP != null)
            {
                //drop the flag for the old checkpoint
                dropFlag(gm.activeCP);
            }

            //play the flag sound clip when flag is raised
            FindObjectOfType<AudioManager>().PlaySound("Flag");

            //set the new Checkpoint object and position into the GameMaster object
            gm.activeCP = this.transform.parent.gameObject;
            gm.spawnPosition = gm.activeCP.transform.position;

            //Raise the flag for the new checkpoint
            setFlag(gm.activeCP);
        }
    }

   void FixedUpdate()
    {
        //run if raising a flag
        if(_raiseFlag)
        {
            //Get a point of rotation, the axis of rotation, and the speed for the flag object to rotate around
            Vector3 point = _upwardFlag.transform.position; //flag will rotate around its self
            Vector3 axis = Vector3.forward; //shorthand for Vector3(0, 0, 1)[Axis of Rotation in the +Z direction -> CounterClockwise]
            float speed = 750f; //Speed of rotation

            //Rotate the flag around the set point and axis with the set speed
            _upwardFlag.transform.RotateAround(point, axis, Time.deltaTime * speed);

            //check if the flag has been set upright yet
            //If the flag has rotated 180 degrees to an upward position, _raiseFlag will be set to false
            setFlag(_upwardFlag);
        }

        //run if lowering a flag
        if(_lowerFlag)
        {
            //Get a point of rotation, the axis of rotation, and the speed for the flag object to rotate around
            Vector3 point = _downwardFlag.transform.position; //flag will rotate around its self
            Vector3 axis = Vector3.back; //shorthand for Vector3(0, 0, -1)[Axis of Rotation in the -Z direction -> Clockwise]
            float speed = 750f; //Speed of rotation

            //Rotate the flag around the set point and axis with the set speed
            _downwardFlag.transform.RotateAround(point, axis, Time.deltaTime * speed);

            //check if the flag has been set down yet
            //If the flag has rotated 180 degrees to a downward position, _lowerFlag will be set to false
            dropFlag(_downwardFlag);
        }
    }

    //Function to see if a flag has been rotated to an upright position
    void setFlag(GameObject flag)
    {
        if(flag == null)
        {
            return;
        }
        if(flag.transform.rotation.z < 1.0f)//1.0f is the same as 180 degrees
        {
            _raiseFlag = true;
            _upwardFlag = flag;
            return;
        }
        //This command will run if all other if statements fail since they all have a return command in them
        //if all other commands failed, then that means the flag has finished rotating
        _raiseFlag = false;
    }

    //Funtion to see if a flag has been set to a downward position
    void dropFlag(GameObject flag)
    {
        if(flag == null)
        {
            return;
        }
        if(flag.transform.rotation.z > 0.0f)//0.0f is the same as 0 degrees
        {
            _lowerFlag = true;
            _downwardFlag = flag;
            return;
        }
        //This command will run if all other if statements fail since they all have a return command in them
        //if all other commands failed, then that means the flag has finished rotating
        _lowerFlag = false;
    }

    /*
    //Gets the closest object with a specific tag
    //(REMOVED DUE TO NOT BEING NEEDED ANY LONGER)
    private GameObject ClosestCP(Vector3 pointPosition)
    {
        gatherCP = GameObject.FindGameObjectsWithTag("CP");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach(GameObject obj in gatherCP)
        {
            Vector3 diff = obj.transform.position - pointPosition;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                closest = obj;
                distance = curDistance;
            }
        }
        return closest;
    }
    */
}
