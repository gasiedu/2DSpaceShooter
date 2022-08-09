using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private float _canFire = -1f;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4.9f, 0);       
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        
        //if i hit the space key
        //spawn gameObject

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
           Instantiate(_laserPrefab,transform.position + new Vector3(0,0.8f,0),Quaternion.identity);
        }

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

        //if the player postion on the Y is greater than 0
        //y postion = 0
        //else if postion on the y is less than -3.8f

        if (transform.position.y >= 4.9f)
        {
            transform.position = new Vector3(transform.position.x, 4.9f, 0);
        }
        else if (transform.position.y <= -4.9f)
        {
            transform.position = new Vector3(transform.position.x, -4.9f, 0);
        }

        //if player on the x is > 11
        // x pos = -1
        //else if player on the x is less than -11
        //x pos = 11

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }

    }

}
