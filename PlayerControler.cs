using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private PlayerControls                             _playerControls;
    [SerializeField] private Vector2                   _playerDirection;
    
    private Rigidbody2D                                _playerRB2D;
    private Animator                                   _playerAnimator;
    public float                                       _playerSpeed;

    private void OnEnable(){
        _playerControls.Enable();
    }

    void OnDisable(){
        _playerControls.Disable();
    }

    void Awake(){
        _playerControls = new PlayerControls();
        _playerAnimator = GetComponent<Animator>();
    }

    void PlayerInput(){
        _playerDirection = _playerControls.Player.Movimento.ReadValue<Vector2>();
        
        _playerAnimator.SetInteger("idTransition", 1);


        PlayerFlip();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        if(_playerDirection.sqrMagnitude >  0){
            _playerAnimator.SetInteger("idTransition", 2);
        } else{
            _playerAnimator.SetInteger("idTransition", 1);
        }
    }

    private void FixedUpdate(){
        PlayerMove();
    }

    void PlayerMove(){
        _playerRB2D.MovePosition(_playerRB2D.position + _playerDirection * (_playerSpeed * Time.deltaTime));
    }

    void PlayerFlip(){
        if (_playerDirection.x > 0){
            transform.eulerAngles = new Vector2(0, 0);
        } else if(_playerDirection.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
