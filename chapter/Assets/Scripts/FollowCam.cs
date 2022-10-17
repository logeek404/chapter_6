using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public Transform target;
    
    public float smoothTime = 0.2f;
    
    private Vector3 _velocity = Vector3.zero;
    private Camera _cam;
    private float OriginSize ;
    private void LateUpdate()
    {

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        if (target.position.y >= -10)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
            
            if(_cam != null&&(_cam.orthographicSize > OriginSize))
            _cam.orthographicSize -=0.1f ;

        }
        else
        {
            if (_cam != null)
            {
                _cam.orthographicSize += .1F;
            }

            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0f,0f, targetPosition.z), ref _velocity, smoothTime);

        }   

    }
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<Camera>();
        if (_cam != null)
        {
            OriginSize = _cam.orthographicSize;
            

        }
    }

    // Update is called once per frame
    void Update()
    {   
        
        
    }
}
