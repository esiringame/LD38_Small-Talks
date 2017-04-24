using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walking,
        Hidding,
        Talking
    }

    public TextBoxManager _textBoxManager;
    public PrefabFactory HideoutFactory;
    public float _horSpeed, _verSpeed;
    public float HideoutDistanceMax = .3f;
    private State _state;
    private bool isFacingRight;
    private ScrollingManager _scrollingManager;
    private TrashcanAnimatorController _hideout;
    private ScrollableRigidbody _scrollableRigidbody;
    public float score,highScore;
    private Text textScore;
    private Text textHighScore;

    //private Rigidbody2D _rigidbody;

    public State GetState()
    {
        return _state;
    }

    public bool GetIsFacingRight()
    {
        return isFacingRight;
    }

    // Use this for initialization
    void Start () {
        _state = State.Idle;
        score = 0;
        highScore = score;
        isFacingRight = true;

        _scrollingManager = GetComponentInParent<ScrollingManager>();
        _scrollableRigidbody = GetComponent<ScrollableRigidbody>();

        textScore = GameObject.FindGameObjectWithTag("txtsco").GetComponent<Text>();
        textHighScore = GameObject.FindGameObjectWithTag("txthsco").GetComponent<Text>();

    }

    void Movement()
    {
        if (_state == State.Idle || _state == State.Walking)
        {
            Vector3 move = Vector2.zero;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            isFacingRight = horizontal >= 0;
            if (vertical > 0)
            {
                move += transform.up;
            }
            else if (vertical < 0)
            {
                move += -transform.up;
            }
            if (horizontal > 0)
            {
                move += transform.right;
                 
            }
            else if (horizontal < 0)
            {
                move += -transform.right;
            }
            if (move != Vector3.zero)
            {
                _state = State.Walking;
            }
            else
            {
                _state = State.Idle;
            }

            Vector2 move2D = move.normalized;
            move2D.Scale(new Vector2(_horSpeed, _verSpeed));
            _scrollableRigidbody.MoveVector = move2D;
        }
    }

    void FixedUpdate()
    {
        _scrollableRigidbody.MoveVector = Vector2.zero;
        Movement();
        if (_state != State.Talking)
        {
            score = 100f + score*1.0025f;

            if (highScore < score)
                highScore = score;
        }

        textScore.text = ((int)score).ToString();
        textHighScore.text = ((int) highScore).ToString();
    }

    // Update is called once per frame
    void Update () {
        Action();

    }

    public void OnRelease()
    {
        _scrollingManager.enabled = true;
        _state = State.Idle;
    }

    public void OnTrigger(int CharacterId, int EncounterCounter)
    {
        _scrollingManager.enabled = false;
        _textBoxManager.talkTriggered(CharacterId, EncounterCounter);
        _state = State.Talking;
 
        score = 0;
    }

    void Action()
    {
        if (Input.GetButtonDown("Action"))
        {
            if (_state == State.Idle || _state == State.Walking)
            {
                Hide();
            }
            else if (_state == State.Hidding)
            {
                Unhide();
            }
        }
    }

    void Hide()
    {
        TrashcanAnimatorController trashCan = null;
        float distance = float.PositiveInfinity;
        foreach (GameObject hideoutObject in HideoutFactory.AliveObjects)
        {
            float dist = (hideoutObject.transform.position - transform.position).magnitude;

            if (dist > HideoutDistanceMax)
                continue;

            if (dist < distance)
            {
                distance = dist;
                trashCan = hideoutObject.GetComponent<TrashcanAnimatorController>();
            }
        }

        if (trashCan == null)
            return;
        _hideout = trashCan;

        _hideout.OnHide(this);
        GetComponent<SpriteRenderer>().enabled = false;
        _state = State.Hidding;
    }

    void Unhide()
    {
        _hideout.OnUnhide();
        GetComponent<SpriteRenderer>().enabled = true;
        _state = State.Idle;
    }

    public void ForceUnhide()
    {
        Unhide();
    }
}
