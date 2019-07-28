using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    public Animator animator;
    //private PlayerMove playerMove;
    public float move_Speed = 2f;
    public float normal_Push = 10f;
    public float extra_Push = 14f;
    private bool initial_Push;
    private int push_Count;
    private bool player_Died;
    //public static bool player_DiedReplica;

    // Awake is called once for every object before the every scene 
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is always run at a fixed time interval
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (player_Died)
            return;

        //Touch Controls

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touch_Pos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch_Pos.x > 0)
            {
                myBody.velocity = new Vector2(move_Speed, myBody.velocity.y);
            }
            else if (touch_Pos.x < 0)
            {
                myBody.velocity = new Vector2(-move_Speed, myBody.velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.instance.Pause();
        }

        // Keyboard Controls

        //if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    myBody.velocity = new Vector2(move_Speed, myBody.velocity.y);
        //}
        //else if (Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    myBody.velocity = new Vector2(-move_Speed, myBody.velocity.y);
        //}


    } // player movement


    private void OnTriggerEnter2D(Collider2D target)
    {

        if (player_Died)
            return;

        if (target.tag == "ExtraPush")
        {
            if (!initial_Push)
            {
                initial_Push = true;
                myBody.velocity = new Vector2(myBody.velocity.x, 18f);
                target.gameObject.SetActive(false);

                // sound manager
                SoundManager.instance.JumpSoundFX();

                //exit from the on trigger enter because of initial push
                return;
            } // initial push
        } // beacuse of the initial_push

        if(target.tag == "NormalPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, normal_Push);
            target.gameObject.SetActive(false);
            push_Count++;

            // sound manager
            SoundManager.instance.JumpSoundFX();

        }

        if (target.tag == "ExtraPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, extra_Push);
            target.gameObject.SetActive(false);
            push_Count++;

            // sound manager
            SoundManager.instance.JumpSoundFX();

        }

        if (push_Count == 2)
        {
            push_Count = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        } // spawning new platforms after 2 jumps for making endless of game

        if(target.tag == "FallDown" || target.tag == "Bird")
        {
            player_Died = true;
            //player_DiedReplica = true;

            // Sound Manager
            SoundManager.instance.GameOverSoundFX();
            // Animation
            animator.SetTrigger("PlayerDiedTrg");
            // Game Manager
            GameManager.instance.RestartGame();
        }

    } // on trigger enter


} //class
