using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

// Input.GetTouch example.
//
// Attach to an origin based cube.
// A screen touch moves the cube on an iPhone or iPad.
// A second screen touch reduces the cube size.

public class TouchInput : MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    [NonSerialized] public float width;
    [NonSerialized] public float height;
    [NonSerialized] public Vector3 TouchPosRelToCam;

    public Camera MainCam;
    public Sprite TargetGraphic;
    public Sprite PressedGraphic;
    //[SerializeField] public string MyName;

    public UnityEvent OnTouchDown;
    public UnityEvent OnTouchUp;
    public UnityEvent OnTouchMoved;
    public UnityEvent OnTouchHold;
    public UnityEvent OnTouchTapped;

    float touchStartTime;
    public float holdDuration = 0.7f;
    bool OnHold = false;
    //public UnityEvent OnTouchActive;
    Touch CurrentTouch;

    void Awake()
    {
        if (OnTouchDown == null)
            OnTouchDown = new UnityEvent();

        if (OnTouchUp == null)
            OnTouchUp = new UnityEvent();

        if (OnTouchMoved == null)
            OnTouchMoved = new UnityEvent();

        if (OnTouchHold == null)
            OnTouchHold = new UnityEvent();

        if (OnTouchTapped == null)
            OnTouchTapped = new UnityEvent();
        
        //if (OnTouchActive == null)
        //    OnTouchActive = new UnityEvent();

        if (MainCam == null)
            MainCam = Camera.main;

        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        position = new Vector3(0.0f, 0.0f, 0.0f);
        TouchPosRelToCam = MainCam.ScreenToWorldPoint(position);

        CurrentTouch.fingerId = -1;

        if (TargetGraphic == null)
        {
            if (gameObject.GetComponent<SpriteRenderer>())
            {
                TargetGraphic = gameObject.GetComponent<SpriteRenderer>().sprite;
                return;
            }
            if (gameObject.GetComponent<Image>())
            {
                TargetGraphic = gameObject.GetComponent<Image>().sprite;
                return;
            }
            
        }
        

    }



    void ChangeSprite(Sprite sprite)
    {
        if (gameObject.GetComponent<SpriteRenderer>())
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            return;
        }
        if (gameObject.GetComponent<SpriteRenderer>())
        {
            gameObject.GetComponent<Image>().sprite = sprite;
            return;
        }
            

    }


    void TouchPhaseBegan()
    {
        if (PressedGraphic)
        {
            ChangeSprite(PressedGraphic);
        }
    }

    void TouchPhaseEnded()
    {
        if (TargetGraphic)
        {
            ChangeSprite(TargetGraphic);
        }
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector2 pos = touch.position;
                //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
                Collider2D collider = Physics2D.OverlapPoint(MainCam.ScreenToWorldPoint(pos));

                if (collider != null && collider.gameObject == gameObject)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        //Debug.Log(MyName+" Began");
                        CurrentTouch = touch;
                        position = new Vector3(pos.x, pos.y, 0.0f);
                        TouchPosRelToCam = MainCam.ScreenToWorldPoint(position);
                        TouchPhaseBegan();
                        touchStartTime = Time.time;
                        OnTouchDown.Invoke();
                    }

                    if (touch.phase == TouchPhase.Stationary && Time.time - touchStartTime >= holdDuration)
                    {
                        //Debug.Log("User is touch holding the game object!");
                        OnHold = true;

                    }
                }

                if (CurrentTouch.fingerId != -1 && CurrentTouch.fingerId == touch.fingerId)
                {

                    //OnTouchActive.Invoke();

                    if (touch.phase == TouchPhase.Moved)
                    {
                        position = new Vector3(pos.x, pos.y, 0.0f);
                        TouchPosRelToCam = MainCam.ScreenToWorldPoint(position);
                        OnTouchMoved.Invoke();
                    
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        TouchPhaseEnded();
                        OnTouchUp.Invoke();

                        if(!OnHold)
                        {
                            OnTouchTapped.Invoke();
                        }

                        position = new Vector3(0.0f, 0.0f, 0.0f);
                        TouchPosRelToCam = MainCam.ScreenToWorldPoint(position);
                        //Debug.Log(MyName + " Ended");
                        CurrentTouch.fingerId = -1;

                        OnHold = false;
                    }

                    if (OnHold)
                    {
                        OnTouchHold.Invoke();
                    }


                }


            }
        }
    }
}