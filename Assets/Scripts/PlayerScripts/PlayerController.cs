using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject DownGroundCheck;
    public GameObject UpGroundCheck;
    public GameObject FowardGroundcheck; 
	public static bool reversed;
	public static bool action;
	public float speedBoost;
	public float moveSpeedX;
	public float moveSpeedY;
	public float forceToAddVer;
	public float forceToAddHor;

	private float scaleX;
	private float scaleY;
	private float scaleZ;
	private float tapSpeed = 0.5f; //in seconds
	public float moveVelocityX;
	private float moveVelocityY;
	private float lastTap_W_Time = 0;
	private float lastTap_S_Time = 0;
	private float lastTap_D_Time = 0;
	private float lastTap_A_Time = 0;

	private bool doubleTapVer;
	private bool doubleTapHor;
    private bool canMoveRight;
    private bool canMoveLeft;
    private bool canMoveUp;
    private bool canMoveDown;


	// Use this for initialization
	void Start () {

		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;
		scaleZ = transform.localScale.z;

		lastTap_W_Time = 0;
		lastTap_S_Time = 0;
		lastTap_D_Time = 0;
		lastTap_A_Time = 0;
		doubleTapVer = false;
		doubleTapHor = false;
	
	}
	void Update()
	{
        Debug.Log(canMoveRight);
        moveVelocityX = 0f;
        moveVelocityY = 0f;
        if (Input.GetKeyDown(KeyCode.F)) //Action Key
        {
            action = true;
        }
        else
        {
            action = false;
        }

        CheckGround();

        //NormalMovementInput
        if (canMoveUp)
        {
            if (Input.GetKey(KeyCode.W))
            {

                moveVelocityY = moveSpeedY;

            }
        }

        if (canMoveDown)
        {
            if (Input.GetKey(KeyCode.S))
            {
                moveVelocityY = -moveSpeedY;


            }
        }

        if (canMoveRight)
        {
            if (Input.GetKey(KeyCode.D))
            {
                moveVelocityX = moveSpeedX;
            }
        }

        if (canMoveLeft)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveVelocityX = -moveSpeedX;


            }
        }

        //DoubleTap Dashing Input
        if (canMoveUp)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {


                if ((Time.time - lastTap_W_Time) < tapSpeed)
                {

                    GetComponent<Rigidbody>().AddForce(0, 0, forceToAddVer, ForceMode.VelocityChange);
                    doubleTapVer = true;

                }

                lastTap_W_Time = Time.time;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                doubleTapVer = false;
            }
        }

        if (canMoveDown)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {


                if ((Time.time - lastTap_S_Time) < tapSpeed)
                {

                    GetComponent<Rigidbody>().AddForce(0, 0, -forceToAddVer, ForceMode.VelocityChange);
                    doubleTapVer = true;

                }

                lastTap_S_Time = Time.time;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                doubleTapVer = false;
            }
        }

        if (canMoveRight)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {


                if ((Time.time - lastTap_D_Time) < tapSpeed)
                {

                    GetComponent<Rigidbody>().AddForce(forceToAddHor, 0, 0, ForceMode.VelocityChange);
                    doubleTapHor = true;

                }

                lastTap_D_Time = Time.time;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                doubleTapHor = false;
            }
        }

        if (canMoveLeft)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {


                if ((Time.time - lastTap_A_Time) < tapSpeed)
                {

                    GetComponent<Rigidbody>().AddForce(-forceToAddHor, 0, 0, ForceMode.VelocityChange);
                    doubleTapHor = true;

                }

                lastTap_A_Time = Time.time;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                doubleTapHor = false;
            }
        }

		//*****Make KnockBack a percentage of the dmg to Health for Player increase as percentage increases****
		//IF less than percentage ignore knockback
		//Player KnockBack on enemy hit

		//DoubleTap and MovementOutPut
		if (doubleTapHor == true) 
		{
			moveVelocityX = moveVelocityX * speedBoost;
		} else if (doubleTapVer == true)
		{
			moveVelocityY = moveVelocityY * speedBoost;
		}
			
		GetComponent<Rigidbody> ().velocity = new Vector3 (moveVelocityX, GetComponent<Rigidbody> ().velocity.y, moveVelocityY);//Moves Player
		//Adjusts direction player faces
		if (GetComponent<Rigidbody> ().velocity.x > 0) 
		{
			transform.localScale = new Vector3 (scaleX, scaleY,scaleZ);
			reversed = false;

		} else if (GetComponent<Rigidbody> ().velocity.x < 0)
		{
			transform.localScale = new Vector3 (-scaleX, scaleY,scaleZ);
			reversed = true;
		}

	

	}

    void CheckGround()
    {
        //ForwardGroundCheck
        RaycastHit hit;
        Ray groundRay = new Ray(FowardGroundcheck.transform.position, -FowardGroundcheck.transform.up );
        Debug.DrawRay(FowardGroundcheck.transform.position, -FowardGroundcheck.transform.up);
        if (Physics.Raycast(groundRay, out hit, 5f))
        {
            canMoveRight = true;
            canMoveLeft = true;
        }
        else
        {
            if (!reversed)
            {
                canMoveRight = false;
            }
            else { canMoveLeft = false; canMoveRight = true; }
        }

        if (!canMoveRight)
        {
            if (GetComponent<Rigidbody>().velocity.x >= 0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0f, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
            }
        }
        if (!canMoveLeft)
        {
            if (GetComponent<Rigidbody>().velocity.x <= 0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0f, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
            }
        }

        //UpGroundCheck
        RaycastHit hit2;
        Ray groundRay2 = new Ray(UpGroundCheck.transform.position, -UpGroundCheck.transform.up);
        Debug.DrawRay(UpGroundCheck.transform.position, -UpGroundCheck.transform.up);
        if (Physics.Raycast(groundRay2, out hit2, 5f))
        {
            canMoveUp = true;
        }
        else
        {
             canMoveUp = false;
        }

        if (!canMoveUp)
        {
            if (GetComponent<Rigidbody>().velocity.z >= 0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, 0f);
            }
        }

        //DoownGroundCheck
        RaycastHit hit3;
        Ray groundRay3 = new Ray(DownGroundCheck.transform.position, -DownGroundCheck.transform.up);
        Debug.DrawRay(DownGroundCheck.transform.position, -DownGroundCheck.transform.up);
        if (Physics.Raycast(groundRay3, out hit3, 5f))
        {
            canMoveDown = true;
        }
        else
        {
            canMoveDown = false;
        }

        if (!canMoveDown)
        {
            if (GetComponent<Rigidbody>().velocity.z <= 0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, 0f);
            }
        }


    }

}
