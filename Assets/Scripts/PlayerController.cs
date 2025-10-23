using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SMScript sound_manager;
    Rigidbody2D rgbd;
    CapsuleCollider2D GroundCollider;
    [SerializeField] private Animator _animator;
    AnimationFSM.FSM fsm = new AnimationFSM.FSM();
    SpriteRenderer sprite;
    InputAction MoveRight;
    InputAction MoveLeft;
    InputAction Jump;
    float XVelocity = 0;
    float YVelocity = 0;
    float BaseSpeed = 200;
    float Speed = 200;
    float JumpSpeed = 500;
    bool onGround = false;
    bool JumpTriggered = false;
    public GameObject DeathScreen;
    private Vector2 lastFacingDir = Vector2.right;
    public Vector2 FacingDir => lastFacingDir;
    void Awake()
    {
        MoveRight = InputSystem.actions.FindAction("MoveRight");
        MoveLeft = InputSystem.actions.FindAction("MoveLeft");
        Jump = InputSystem.actions.FindAction("Jump");
        rgbd = GetComponent<Rigidbody2D>();
        Assert.NotNull(rgbd);
        GroundCollider = GetComponent<CapsuleCollider2D>();
        Assert.NotNull(GroundCollider);
        _animator = GetComponent<Animator>();
        Assert.NotNull(_animator);
        sprite = GetComponent<SpriteRenderer>();
        fsm.AddState(new AnimationFSM.JumpState("Jumping"));
        fsm.AddState(new AnimationFSM.WalkState("Walking"));
        fsm.AddState(new AnimationFSM.IdleState("Idle"));
        if (sound_manager == null)
        {
            GameObject sm_obj = GameObject.Find("SoundManager");
            if (sm_obj != null)
            {
                sound_manager = sm_obj.GetComponent<SMScript>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        onGround = GroundCollider.IsTouchingLayers(LayerMask.GetMask("Environment"));
        fsm.Update();
        var animatorState = _animator.GetCurrentAnimatorStateInfo(0);
        fsm.conditions.isOnGround = onGround;
        var fsmAnimationName = fsm.currentState.animationName;
        fsm.conditions.movingX = (XVelocity != 0);
        if (!animatorState.IsName(fsmAnimationName))
        {
            _animator.Play(fsmAnimationName);
        }
        if (XVelocity > 0)
        {
            sprite.flipX = false;
            lastFacingDir = Vector2.right;
        }
        else if (XVelocity < 0)
        {
            sprite.flipX = true;
            lastFacingDir = Vector2.left;
        }
        GetInput();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    private void GetInput()
    {
        XVelocity = 0;
        if (MoveRight.IsPressed())
        {
            XVelocity = Speed;
        }
        if (MoveLeft.IsPressed())
        {
            XVelocity = -Speed;
        }
        if (Jump.triggered && onGround)
        {
            JumpTriggered = true;
        }
    }

    private void PlayerMovement()
    {
        if (JumpTriggered)
        {
            rgbd.linearVelocityY = JumpSpeed * Time.fixedDeltaTime;
            JumpTriggered = false;
            sound_manager.JumpSound();
        }
        rgbd.linearVelocityX = XVelocity * Time.fixedDeltaTime;
        Vector2 newVelocity = new Vector2(rgbd.linearVelocityX, YVelocity);
        rgbd.AddForce(newVelocity);
        string CurrentScene = SceneManager.GetActiveScene().name;
        if (rgbd.position.y < -20)
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ApplySpeedBuff(float multiplier, float duration)
    {
        StartCoroutine(SpeedBuffRoutine(multiplier, duration));
    }
    private IEnumerator SpeedBuffRoutine(float multiplier, float duration)
    {
        Speed *= multiplier;
        yield return new WaitForSeconds(duration);
        Speed = BaseSpeed;
    }

    public void ApplyBigBuff(float multiplier, float duration, float increaseDuration)
    {
        StartCoroutine(BigBuffRoutine(multiplier, duration, increaseDuration));
    }
    private IEnumerator BigBuffRoutine(float multiplier, float duration, float increaseDuration)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * multiplier;
        float elapse = 0f;
        while (elapse < increaseDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapse / increaseDuration);
            elapse += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(duration);
        transform.localScale = originalScale;
    }
}
