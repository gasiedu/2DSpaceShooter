using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1.1f;
    [SerializeField] private float _xPos;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.42f)
        {
            _xPos = Random.Range(-11.3f, 9.41f);
            transform.position = new Vector3(_xPos, 6.38f, 0);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
            //if other is player
        if(other.gameObject.CompareTag("Player"))
        {
            //damage the player
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);
        }
        
        if(other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        
    }

}
