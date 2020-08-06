using UnityEngine;

public class SawRotation : MonoBehaviour
{
    //Variable Declaration
    private GameObject saw;
    Vector3 centerPosition;


    //Variable Initiallization for Serialized Variables
    [SerializeField] Vector3 centerOffset = new Vector3(54.5f, 6.5f, 0f);
    [SerializeField] float rotationSpeed = 250.0f;
    [SerializeField] bool flipRotation = false;

    void Awake()
    {
        //Get the game object that the script is attached to
        saw = this.gameObject;

        //save the new offset point to the be center of the saw
        centerPosition = saw.transform.position + centerOffset;
    }

    void FixedUpdate()
    {
        //flip rotation to +Z
        if(flipRotation)
        {
            //Rotate the saw around its set point in the +Z direction[CounterClockwise]
            transform.RotateAround(centerPosition, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        //flip rotation to -Z
        else
        {
            //Rotate the saw around its set point in the -Z direction[Clockwise]
            transform.RotateAround(centerPosition, Vector3.back, rotationSpeed * Time.deltaTime);
        }
    }
}
