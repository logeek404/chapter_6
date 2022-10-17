using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MovingPlatform : MonoBehaviour
{

    public Vector3 finishPos = Vector3.zero;
    public float speed = 0.5f;
    private Vector3 _startPos;
    private float _trackPecent = 0;
    private int _direction = 1;

    //Gizmos by implementing abstract method
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, finishPos);
    }



    // Start is called before the first frame update
    void Start()
    {
        //world space coord
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _trackPecent += _direction * speed * Time.deltaTime;
        float x = (finishPos.x - _startPos.x) * _trackPecent + _startPos.x;
        float y = (finishPos.y - _startPos.y) * _trackPecent + _startPos.y;
        transform.position  = new Vector3(x,y,_startPos.z);
        if((_direction== 1 && _trackPecent >.9f)||
           (_direction == -1&& _trackPecent < .1f))
        {
            _direction *= -1;
        }

    }
}
