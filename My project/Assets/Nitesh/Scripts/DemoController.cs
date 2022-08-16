using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class DemoController : MonoBehaviour
{

	private Animator animator;

	public float walkspeed = 5;
	private float horizontal;
	private float vertical;
	private float rotationDegreePerSecond = 1000;
	private bool isAttacking = false;

	public GameObject gamecam;
	public Vector2 camPosition;
	private bool dead;


	public GameObject[] characters;
	public int currentChar = 0;

    public GameObject[] targets;
    public float minAttackDistance;

    public UnityEngine.UI.Text nameText;

    public bool isLeft;
    public bool isRight;
    public bool isUp;
    public bool isDown;
    public bool isAttack;
    public bool isJump;
    public bool isLeave;
    public bool isDead;
    public bool isGetHit;


	void Start()
	{
		setCharacter(0);
	}

	void FixedUpdate()
	{
		if (animator && !dead)
		{
			//walk
			horizontal = isRight ? 1 : isLeft ? -1 : 0;
			vertical = isUp ? 1 : isDown ? -1 : 0;

			Vector3 stickDirection = new Vector3(horizontal, 0, vertical);
			float speedOut;

			if (stickDirection.sqrMagnitude > 1) stickDirection.Normalize();

			if (!isAttacking)
				speedOut = stickDirection.sqrMagnitude;
			else
				speedOut = 0;

			if (stickDirection != Vector3.zero && !isAttacking)
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(stickDirection, Vector3.up), rotationDegreePerSecond * Time.deltaTime);
			GetComponent<Rigidbody>().velocity = transform.forward * speedOut * walkspeed + new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);

			animator.SetFloat("Speed", speedOut);
		}
	}

	void Update()
	{
         //if touch count is more than 1, then do nothing
        
        
		if (!isDead)
		{
			// move camera
			if (gamecam)
				gamecam.transform.position = transform.position + new Vector3(0, camPosition.x, -camPosition.y);

        

			//switch character

			if (isLeft)
			{
				setCharacter(-1);
			}

			if (isRight)
			{
				setCharacter(1);
			}
            }

		

            //Leave
            if (isLeave)
            {
                //set leave animation
                Debug.Log("Leave");
                animator.SetBool("Leave", true);
            }
        

	}
   


    public void setCharacter(int i)
	{
		currentChar += i;

		if (currentChar > characters.Length - 1)
			currentChar = 0;
		if (currentChar < 0)
			currentChar = characters.Length - 1;

		foreach (GameObject child in characters)
		{
            if (child == characters[currentChar])
            {
                child.SetActive(true);
                if (nameText != null)
                    nameText.text = child.name;
            }
            else
            {
                child.SetActive(false);
            }
		}
		animator = GetComponentInChildren<Animator>();
    }


    public void moveLeft(){
        Reset();
        isLeft = true;
    }
    public void moveRight(){
        Reset();
        isRight = true;
    }
    public void moveUp(){
        Reset();
        isUp = true;
    }
    public void moveDown(){
        Reset();
        isDown = true;
    }

    public void deathButtonClick(){
        Reset();
        isDead = true;
    }
    public void attackButtonClick(){
        isAttack = true;
    }
    public void leaveButtonClick(){
        Reset();
        isLeave = true;
    }
    public void getHitButtonClick(){
        isGetHit = true;
    }

    public void Reset() {
        isLeft = false;
        isRight = false;
        isUp = false;
        isDown = false;
        isAttack = false;
        isLeave = false;
        isGetHit = false;
        isDead = false;
    }

  
}
