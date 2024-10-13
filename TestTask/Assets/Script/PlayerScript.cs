using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    Vector3 moveVector;
    Rigidbody rb;
	[SerializeField]float speed;
	float jumpForce = 7f;
    [SerializeField] float helth = 3f;
    [SerializeField] float speedRotation;
    public float Heth
    {
        set { value = helth; }
        get { return helth; }
    }
    [SerializeField] GameObject panel;


    
    public float raycastDistance = 0.5f; // Расстояние для проверки земли
    private bool isGrounded = false; // Флаг, указывающий, на земле ли персонаж


    void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate () {

        if (helth > 0)
        {
            
            if(moveVector.x !=0 || moveVector.y != 0)
            {
                if (Vector3.Angle(Vector3.forward, moveVector) > 1 || Vector3.Angle(Vector3.forward, moveVector) == 0)
                {
                    Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, speed, 0.0f);
                    Quaternion quater = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, quater, speedRotation * Time.deltaTime);
                }
            }


            moveVector.x = Input.GetAxis("Horizontal") * speed;
            moveVector.z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Translate(0, 0, moveVector.z);

            CheckGrounded();

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Click Jump");
            }
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
        
        
    }
    private void CheckGrounded()
    {
       
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray,out hit,0.5f))
        {
            if (hit.collider != null) {
                if (hit.collider.gameObject.CompareTag("Floor"))
                {
                    isGrounded = true;

                }
                
            }
            
        }
        else
        {
            isGrounded = false;
        }
        Debug.Log("Status: " + isGrounded);

    }
   
    public void hit_player(float value)
    {
        helth -= value;
        Debug.Log("hit");
    }
    
}
