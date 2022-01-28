using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    
    [SerializeField] Vector3 force;

    private Rigidbody2D rb;

    private Spaceship[] _spaceships;

    private void OnEnable()
    {
        _spaceships = FindObjectsOfType<Spaceship>();
    }

    void Start()
    {

        /*rb = GetComponent<Rigidbody2D>();

        force = new Vector3(0, 100, 0);

        rb.AddForce(force);*/

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "topBoundary")
        {
            Destroy(this.gameObject);
        }
    }

    public void AbductAlien()
    {
        rb = GetComponent<Rigidbody2D>();

        force = new Vector3(0, 0, 0);

        rb.AddForce(force);
    }

    public void CheckAlien()
    {
/*        foreach (Spaceship spaceship in _spaceships)
        {
            if (spaceship !=null || (int)spaceship.transform.position.x == (int)transform.position.x)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }*/
    }


}
