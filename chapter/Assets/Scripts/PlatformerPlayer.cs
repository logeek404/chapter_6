using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{

    public float jumpForce = 2.5f;
    private Animator _anim;
    private BoxCollider2D _box;
    public float speed = 250.0f;
    private Rigidbody2D _body;
    // Start is called before the first frame update
    void Start()
    {

        // assign bunch of renferences
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {

        


        // moving on x-axies
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;



        // jumping 
        bool grounded = false;

        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);     
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);   // collision detect
        MovingPlatform platform = null; //dectecting whether stands on a moving platform
        if (hit != null)
        {
            grounded = true;
            platform = hit.GetComponent<MovingPlatform>();
            if(platform != null)
            {
                transform.parent = platform.transform;
            }
            else
            {
                transform.parent = null;
            }
        }
        else
        {
            transform.parent = null;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&grounded)
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }




        // stop gravity while player is on a slope 
        _body.gravityScale = (grounded && deltaX == 0) ? 0:1 ;

       

        //animation 
        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        // speed is a parameter in animator(windows -> anmation->animator) to be consistent with transition 
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1); // translate in local space (here is used to turn the direction of face)
        }

        // couter-scaling  on  moving platform
       Vector3 pScale = Vector3.one;
        if (platform != null)
        {
            pScale = platform.transform.localScale;

        }

        if (deltaX != 0)
        {
            transform.localScale = new Vector3(
              Mathf.Sign(deltaX) / pScale.x, 1 / pScale.y, 1);

        }

        //reset after falling out of scene
        if (transform.position.y <= -20 )
        {
            transform.position = new Vector3(-2, 10, transform.position.z);
            
        }


    }
}
