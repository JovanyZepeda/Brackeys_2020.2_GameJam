using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    private GameObject[] gatherCP;
    private Vector3 _flagUp;
    private Vector3 _flagDown;
    private Vector3 startSpawn;
    private bool _raiseFlag;
    private bool _lowerFlag;
    //private GameObject _closestCP;
    private GameObject _upwardFlag;
    private GameObject _downwardFlag;


    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        _upwardFlag = null;
        _downwardFlag = null;
        //_closestCP = null;
        _raiseFlag = false;
        _lowerFlag = false;
        _flagUp = new Vector3(0, 0, 180);
        _flagDown = new Vector3(0, 0, 0);
        startSpawn = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(gm.activeCP == this.transform.parent.gameObject)
            {
                Debug.Log("YOS");
                return;
            }
            if(gm.activeCP != null && gm.activeCP.tag != "Respawn")
            {
                dropFlag(gm.activeCP);
            }
            //_closestCP = ClosestCP(other.transform.position);//(REMOVED DUE TO QUICKER OPTION)
            gm.activeCP = this.transform.parent.gameObject;
            gm.spawnPosition = gm.activeCP.transform.position;
            setFlag(gm.activeCP);
        }
    }

   void FixedUpdate()
    {
        if(_raiseFlag)
        {
            Vector3 point = _upwardFlag.transform.position;
            Vector3 axis = new Vector3(0, 0, 1);
            _upwardFlag.transform.RotateAround(point, axis, Time.deltaTime * 750f);
            setFlag(_upwardFlag);
        }
        if(_lowerFlag)
        {
            Vector3 point = _downwardFlag.transform.position;
            Vector3 axis = new Vector3(0, 0, -1);
            _downwardFlag.transform.RotateAround(point, axis, Time.deltaTime * 750f);
            dropFlag(_downwardFlag);
        }
    }

    void setFlag(GameObject flag)
    {
        if(flag == null)
        {
            return;
        }
        if(flag.transform.rotation.z < 1.0f)
        {
            _raiseFlag = true;
            _upwardFlag = flag;
            return;
        }
        _raiseFlag = false;
    }

    void dropFlag(GameObject flag)
    {
        if(flag == null)
        {
            return;
        }
        if(flag.transform.rotation.z > 0.0f)
        {
            _lowerFlag = true;
            _downwardFlag = flag;
            return;
        }
        _lowerFlag = false;
    }

    /*
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
