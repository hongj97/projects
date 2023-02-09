using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float  speed;
    public GameObject[] item;
    public bool[] hasitem;

    [SerializeField]
    private float cameraRotationLimit;  
    private float currentCameraRotationX;  
    [SerializeField]
    private Camera theCamera; 
    private Rigidbody myRigid;
    [SerializeField]
    private float lookSensitivity; 

    float hAxis;
    float vAxis; 
    float _xRotation;
    float _yRotation;
    bool shift_Down;
    bool jump_Down;
    bool e_Down;

    bool is_jump;
    bool is_Dodge;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Rigidbody rigid;
    Transform trans;

    Animator anim;

    GameObject nearObject;

    // Start is called before the first frame update
    void Start(){
        myRigid = GetComponent<Rigidbody>();  // private
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInPut();
        Move(); 
        CameraRotation();
        CharacterRotation(); 
        Jump();
        Dodge();
        Interation();
    }

    void GetInPut(){
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        shift_Down = Input.GetButton("Walk");
        jump_Down = Input.GetButtonDown("Jump");
        e_Down = Input.GetButtonDown("Interation");
        _yRotation = Input.GetAxisRaw("Mouse X");
        _xRotation = Input.GetAxisRaw("Mouse Y"); 
    }

    void Move(){
        Vector3 _moveHorizontal = transform.right * hAxis; 
        Vector3 _moveVertical = transform.forward * vAxis; 

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed * (shift_Down ? 0.3f : 1f); 
        moveVec = _velocity;
        if(is_Dodge){
            moveVec = dodgeVec;
        }
        
        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", shift_Down);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if(jump_Down && moveVec == Vector3.zero && !is_jump && !is_Dodge){
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            is_jump = true;
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Floor"){
            anim.SetBool("isJump", false);
            is_jump = false;
        }
    }


    void Dodge()
    {
        if(jump_Down && moveVec != Vector3.zero && !is_jump && !is_Dodge){
            dodgeVec = moveVec;
            speed *= 2;
            anim.SetTrigger("doDodge");
            is_Dodge = true;

            Invoke("DodgeOut", 0.4f);
        }
    }
    
    void DodgeOut()
    {
        speed *= 0.5f;
        is_Dodge = false;
    }

    void Interation(){
        if(e_Down && nearObject != null && !is_jump && !is_Dodge ){
            if(nearObject.tag == "Bear"){
                Item item = nearObject.GetComponent<Item>();
                int bearIndex = item.val;
                hasitem[bearIndex] = true;
                Destroy(nearObject);
                if(item_check() == true){
                    trans = GameObject.FindWithTag("closet").GetComponent<Transform>();
                    trans.Translate(Vector3.right*7);
                    // Destroy(GameObject.FindWithTag("closet"));
                }
            }
        }
    }


    bool item_check(){
        for(int i = 0; i<4; i++){
            if(hasitem[i] == false){
                return false;
            }
        }
        return true;
    }

    void OnTriggerStay(Collider other){
        if(other.tag == "Bear"){
            nearObject = other.gameObject;
            Debug.Log(nearObject.name);
        }
        if(other.tag == "Key"){
            nearObject = other.gameObject;
        }        
    }

    void OnTriggerEixt(Collider other){
        nearObject = null;
    }

    private void CameraRotation()  
    {
        if(Input.mousePosition.y < Screen.height / 2)
        {
            if(_xRotation > 0)
                _xRotation = 0;
        }
        else if(Input.mousePosition.y > Screen.height / 2)
        {
            if(_xRotation < 0)
                _xRotation = 0;
        }
        else
        {
            _xRotation = 0;
        }
        float _cameraRotationX = _xRotation * lookSensitivity;
        
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()  // 좌우 캐릭터 회전
    {
        if(Input.mousePosition.x < Screen.width / 2)
        {
            if(_yRotation > 0)
                _yRotation = 0;
            if(Input.mousePosition.x < Screen.width / 10)
                _yRotation = -1;
        }
        else if(Input.mousePosition.x > Screen.width / 2)
        {
            if(_yRotation < 0)
                _yRotation = 0;
            if(Input.mousePosition.x > Screen.width / 10 *9)
                _yRotation = 1;
        }
        else
        {
            _yRotation = 0;
        }
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }
   

}


