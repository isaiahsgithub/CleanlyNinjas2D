using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class moveNinja : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 5.0f;
    public List<Vector3> playerPosition = new List<Vector3>();


    [SerializeField] GameObject[] previousNinja;
    [SerializeField] GameObject nextNinja;
    [SerializeField] GameObject entireMapScope;

    [SerializeField] Camera mainCamera;
    private Vector3 initialCameraPosition;


    [SerializeField] TextMeshProUGUI tutorialTextBox;

    [SerializeField] GameObject ninjaCountUI;
    [SerializeField] GameObject overlayUI;

    [SerializeField] GameObject timeReference;

    public bool startRecord = false;
    public bool startPlay = false;
    public bool[] startAllPlays = { true, true, true, true };
    //UPDATE THIS IN PLAYERMANAGER;
    public bool areAnyTrue = false;
    public int[] playbackLocs = {0,0,0,0};
    private int howManyPreviousNinjas = 0;


    private Transform footPos;
    private LayerMask groundLayers;
    private float closeEnough = 0.1f;
    private Rigidbody2D rb;
    private float jumpForce = 450f;

    public bool canIMove = true;
    // Start is called before the first frame update

    public Animator ninjaAnimator;
    public bool isMoving = false;
    public float previousPosition;
    public bool isGrounded = false;
    public bool playJump = false;
    public bool playFall = false;
    public bool playIdleAgain = false;
    public bool startCheckingGround = false;
    public int direction = 1;
    public bool lockRotation = false;
    float unlockTime = 0.5f;
    void Start()
    {
        //Used to see if any ninja clones are able to move. 
        areAnyTrue = false;

        //Used to see how many ninja clones there are (i.e. playing as red ninja: 1 clone - the purple one)
        howManyPreviousNinjas = 0;

        //Initial camera position - used to restore the position back to its original location for resets, or for activating a ninja clone.
        initialCameraPosition = mainCamera.transform.position;

        //Determines which ninja is moving (which one isn't currently a clone)
        canIMove = true;

        //Get RigidBody (enables jumping)
        rb = GetComponent<Rigidbody2D>();

        //Get GroundLayer, which will determine if player is grounded
        //Shifting by 1: https://docs.unity3d.com/Manual/layermask-set.html
        groundLayers = (1 << LayerMask.NameToLayer("WalkableGround"));

        //Record all movements that the player performs (NOT the ninja clone)
        startRecord = true;

        //Playback previous movement
        if (previousNinja != null)
        {
            startPlay = true;
            howManyPreviousNinjas = previousNinja.Count();

        }


        //Getting gameobject where name is footposition (thats also a child of the ninja) - used to determine if the player is grounded
        footPos = this.gameObject.GetComponentsInChildren<Transform>().ToList().Find(x => x.name.Contains("FootPosition") == true);

        ninjaAnimator = this.gameObject.GetComponent<Animator>();
        isMoving = false;
        previousPosition = this.gameObject.transform.position.x;
        isGrounded = true;
        playJump = false;
        playFall = false;
        playIdleAgain = false;
        startCheckingGround = false;
        direction = 1;
        lockRotation = false;
        unlockTime = 0.5f;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Blockage"))
        {
            lockRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the overlay UI is active, the player is not moving. Don't record movements or playback any other movements.
        if(overlayUI.activeInHierarchy == true)
        {
            //Upon ANY keypress, hide the overlay and begin playing.
            if (Input.anyKeyDown)
            {
                //Only hide UI if it is the "Ready _ Ninja" text. Do not hide if its the ending text.
                if ((overlayUI.GetComponentInChildren<TextMeshProUGUI>().text).Contains("Ready") == true)
                {
                    if(timeReference.GetComponent<timeManager>().dontInstantlyDisappear == false)
                    {
                        overlayUI.SetActive(false);

                    }

                }
                //Bug fix: the overlay UI won't instantly disappear after doing a soft-reset via R key.
                timeReference.GetComponent<timeManager>().dontInstantlyDisappear = false;
            }
        }
        else
        {
            //Every frame it checks if the player wants to move (for the active ninja only)
            if (canIMove == true)
            {
                checkToMove();
            }

            foreach (GameObject prevNinja in previousNinja)
            {
                //Prevents the object from going to sleep. Source: "YagoRG" - https://answers.unity.com/questions/478415/ontriggerstay-doesnt-work-if-not-moving.html (This is for colliding with buttons)
                prevNinja.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
            }


            //Animation

            if(isGrounded == true)
            {
                playJump = true;

                //Check if moving: https://forum.unity.com/threads/check-if-an-object-is-moving.149003/
                if (previousPosition == this.gameObject.transform.position.x)
                {
                    isMoving = false;
                    ninjaAnimator.SetBool("isMoving", false);
                }
                else
                {
                    isMoving = true;
                    ninjaAnimator.SetBool("isMoving", true);
                }
                if(playIdleAgain == true)
                {
                    ninjaAnimator.SetTrigger("landed");
                    playIdleAgain = false;
                }
            }
            else
            {
                if(playJump == true)
                {
                    playJump = false;
                    ninjaAnimator.SetTrigger("jumped");
                    playFall = true;
                }
                if(playFall == true)
                {
                    if(this.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
                    {
                        playFall = false;
                        ninjaAnimator.SetTrigger("jumpEnding");
                        playIdleAgain = true;
                        startCheckingGround = true;
                    }
                }
            }

            if(startCheckingGround == true)
            {
                RaycastHit2D hit = Physics2D.Raycast(footPos.position, Vector2.down, closeEnough, groundLayers);

                if (hit.collider)
                {
                    startCheckingGround = false;
                    isGrounded = true;
                }

            }



        }

    }


    //Used to record movement history of each ninja. Will both play and record at appropriate times.
    private void FixedUpdate()
    {
        //If the overlay UI is not active, then the player can move/movement can be played back.
        if (overlayUI.activeInHierarchy != true)
        {
            //Checks if the player is able to move
            if (canIMove == true)
            {
                //If recording is enabled, record.
                if (startRecord == true)
                {
                    recordMovement();
                }

                //If playback of ninja clone movements (player previous movements) is  allowed, play them back.
                if (startPlay == true)
                {
                    areAnyTrue = false;

                    //Loop through all of the ninja clones 
                    for (int i = 0; i < howManyPreviousNinjas + 1; i++)
                    {
                        if (i < howManyPreviousNinjas)
                        {
                            //If there exists a ninja clone that can move, then there is a TRUE value (so some ninjas are still moving) 
                            if (startAllPlays[i] == true)
                            {
                                areAnyTrue = true;
                            }
                        }
                        else
                        {
                            //If there are no more available moves for the ninja clones, end playback.
                            if (areAnyTrue == false)
                            {
                                startPlay = false;
                            }
                        }
                    }
                }


                if (startPlay == true)
                {
                    
                    //Counter variable
                    int whichPrevNinja = 0;
                    foreach (GameObject prevNinja in previousNinja)
                    {
                        //If the ninja (at index whichPrevNinja) has moves left to playback (determined by startAllPlays), continue their movement
                        if (startAllPlays[whichPrevNinja] == true)
                        {
                            playMovement(prevNinja, whichPrevNinja);
                        }
                        //Increment index by 1.
                        whichPrevNinja += 1;
                    }
                }

            }



            if (lockRotation == false)
            {
                //Swap the way the ninja is facing depending on how they move.
                if (direction == 1)
                {
                    if (previousPosition - this.gameObject.transform.position.x > 0)
                    {
                        //Debug.Log("1");
                        //Debug.Log(Mathf.Abs(previousPosition - this.gameObject.transform.position.x));
                        //if (Mathf.Abs(previousPosition - this.gameObject.transform.position.x) > 0.045f)
                        //{
                        direction = -1;
                        this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * -1, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);

                        //}
                    }

                }
                if (direction == -1)
                {
                    if (previousPosition - this.gameObject.transform.position.x < 0)
                    {
                        //Debug.Log("0");
                        //Debug.Log(Mathf.Abs(previousPosition - this.gameObject.transform.position.x));
                        //if (Mathf.Abs(previousPosition - this.gameObject.transform.position.x) > 0.045f)
                        //{
                        direction = 1;
                        this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * -1, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
                        //}

                    }
                }

            }
            else
            {
                //When you run into a wall, prevent flipping left/right for 0.5 seconds.
                unlockTime -= Time.deltaTime;
                if (unlockTime <= 0)
                {
                    lockRotation = false;
                    unlockTime = 0.5f;
                }
            }



            previousPosition = this.gameObject.transform.position.x;





        }
        
    }

    private void checkToMove()
    {
        //Move left/right. If player lets go of key, they stop moving.
        if (Input.GetKey("left"))
        {
            Vector3 movementLeft = (Vector3.right * -1) * movementSpeed * Time.deltaTime;
            transform.Translate(movementLeft);
        }
        if (Input.GetKey("right"))
        {
            Vector3 movementRight = (Vector3.right) * movementSpeed * Time.deltaTime;
            transform.Translate(movementRight);
        }

        //Jump
        if (Input.GetKeyDown("up"))
        {
            //Checks if player is grounded
            RaycastHit2D hit = Physics2D.Raycast(footPos.position, Vector2.down, closeEnough, groundLayers);

            //If the player is on the ground, they can jump.
            if (hit.collider)
            {
                isGrounded = false;
                rb.AddForce(Vector3.up * jumpForce);
            }
        }

        //You can only end your turn if you aren't the final ninja
        if(nextNinja != null)
        {
            if (Input.GetKeyDown("space"))
            {
                //Increment the ninja count by 1, to inform the player they are playing as a new ninja.
                ninjaCountUI.GetComponent<whichNinjaPlayedAs>().updateNinjaCount();
                ninjaCountUI.GetComponent<whichNinjaPlayedAs>().updateNinjaCountText();

               

                //Inform the player they can do a full restart now via the F key. (For starting room text in the tutorial only).
                tutorialTextBox.GetComponent<tutorialText>().textOptions[0] = "Not happy with your overall performance? " +
                    "Press the \"F\" key to completely restart this level. Welcome to the Tutorial. You can move with the arrow keys " +
                    "and press the UP arrow key to jump. The collectable object for this game is soap. " +
                    "Try collecting them all! When you're ready, go through the door.";

               //End turn
               startRecord = false;

                //make bool to enable movement
                canIMove = false;

                //change opacity of ninja clones to be lower than the currently controlled player ninja (clones go to 37.5% opacity).
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(this.gameObject.GetComponent<SpriteRenderer>().color.r,
                    this.gameObject.GetComponent<SpriteRenderer>().color.g, this.gameObject.GetComponent<SpriteRenderer>().color.b, 0.375f);

                //Restore original values of map objects
                restartStuff();

                //Show the "Ready _ Ninja" Overlay UI.
                overlayUI.SetActive(true);
                overlayUI.GetComponentInChildren<overlayManager>().displayText();

                //Enable next ninja
                nextNinja.SetActive(true);
            }
        }


    }


    //Records all actions that a player performs. This will be replayed once they go to another ninja. (and this becomes a shadowy clone).
    private void recordMovement()
    {

        playerPosition.Add(transform.position);
    }


    //Replays ninja clone movement
    public void playMovement(GameObject pN, int theIndex)
    {
        //Prevents the object from going to sleep. Source: "YagoRG" - https://answers.unity.com/questions/478415/ontriggerstay-doesnt-work-if-not-moving.html (This is for colliding with buttons)
        pN.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);

        //For the specific previous ninja, update their position to their recorded position.
        pN.transform.position = pN.GetComponent<moveNinja>().playerPosition[playbackLocs[theIndex]];
        
        //Increment the index, which keeps track of where in the playerPosition array the ninja clone is at (movement purposes)
        playbackLocs[theIndex] += 1;

        //If the ninja clone has played back their entire movement
        if (playbackLocs[theIndex] >= pN.GetComponent<moveNinja>().playerPosition.Count)
        {
            //Debug.Log("yea");

            //Prevent them from moving any further.
            startAllPlays[theIndex] = false;
        }

    }

    public void restartStuff()
    {

        //Reset text position (if in tutorial only)
        if (tutorialTextBox != null)
        {
            tutorialTextBox.GetComponent<tutorialText>().textPosition = 0;
            tutorialTextBox.text = tutorialTextBox.GetComponent<tutorialText>().textOptions[tutorialTextBox.GetComponent<tutorialText>().textPosition];
        }

        //Reset Camera
        mainCamera.transform.position = new Vector3(initialCameraPosition.x, initialCameraPosition.y, initialCameraPosition.z);

        //Reset levers
        List<Transform> allLevers = entireMapScope.GetComponentsInChildren<Transform>().ToList().FindAll(x => x.name.Contains("Lever") == true);
        foreach (Transform lev in allLevers)
        {
            lev.GetComponent<interactLever>().resetLever();
        }




        //Reset CTs
        List<Transform> allCTs = entireMapScope.GetComponentsInChildren<Transform>().ToList().FindAll(x => x.name.Contains("CountingTile") == true);
        foreach (Transform ct in allCTs)
        {
            ct.GetComponent<interactCT>().resetCT();
        }
    }

}
