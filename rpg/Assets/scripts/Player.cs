using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;
    private PlayerItens playerItens;

    public bool isPaused;
    private float initialSpeed;
    private bool  _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWaltering;
    private bool _isAttack;
    private Vector2 _direction;
    
    [HideInInspector] public int handlingObj;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }   
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling 
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    public bool isWaltering
    {
        get { return _isWaltering; }
        set { _isWaltering = value; }
    }
     public bool isAttack
    {
        get { return _isAttack; }
        set { _isAttack = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItens = GetComponent<PlayerItens>();
        initialSpeed = speed;
    }
    private void Update()
    {

        if(!isPaused)
        {
            //teclas numericas de cima
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObj = 0;
            }

            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                handlingObj = 1;
            }

            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                handlingObj = 2;
            }

            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                handlingObj = 3;
            }

            OnInput();
            OnRun();
            OnRolling();
            onCutting();
            onDig();
            onWaltering();
            onAttack();
        }

        //troca para outra cena
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("teste");
        }
        
    }

    private void FixedUpdate()
    {
        if(!isPaused)
        {
            OnMove();
        }
    }

    #region Moviment
        void onWaltering()
        {
            if(handlingObj == 2 )
            {
                if(Input.GetMouseButtonDown(0) && playerItens.currentWater > 0)
                {
                    isWaltering = true;
                    speed = 0f;
                }
                if(Input.GetMouseButtonUp(0) || playerItens.currentWater <= 0)
                {
                    isWaltering = false;
                    speed = initialSpeed;
                }

                if(isWaltering)
                {
                    playerItens.currentWater -= 0.01f;
                }
            }
            
        }
        void onDig()
        {
            if(handlingObj == 1)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    isDigging = true;
                    speed = 0f;
                }
                if(Input.GetMouseButtonUp(0))
                {
                    isDigging = false;
                    speed = initialSpeed;
                }
            }
            
        }
        void onCutting()
        {
            if(handlingObj == 0)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    isCutting = true;
                    speed = 0f;
                }
                if(Input.GetMouseButtonUp(0))
                {
                    isCutting = false;
                    speed = initialSpeed;
                }
            }
            
        }

        void onAttack()
        {
            if(handlingObj == 3)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    isAttack = true;
                    speed = 0f;
                }
                if(Input.GetMouseButtonUp(0))
                {
                    isAttack = false;
                    speed = initialSpeed;
                }
            }
        }

        void OnInput()
        {
            //captura as teclas digitadas 
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }    

        void OnMove()
        {
            // move o personagem
            rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
        }
        void OnRun()
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = runSpeed;
                _isRunning = true;
            }

            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = initialSpeed;
                _isRunning = false;
            }
            
        }

        void OnRolling()
        {
            //botão direito do mouse
            if (Input.GetMouseButtonDown(1))
            {
                _isRolling = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                _isRolling = false;
            }
    }
    #endregion


}
