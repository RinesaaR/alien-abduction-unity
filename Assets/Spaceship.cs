using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Spaceship : MonoBehaviour
{
    private Vector3 _initialPosition;
    private float PlayerSpeed = 5;
    private Alien[] _aliens;
    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void OnEnable()
    {
        _aliens = FindObjectsOfType<Alien>();
    }
    private void Start()
    {
        Debug.Log("ALIENAT   " +_aliens.Length);
    }
    private void Update()
    {
        float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * amtToMove, Space.World);

        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);

        Vector2 directionToInitialPosition = transform.position;
        /* _spaceshipWasLaunched = true;*/
        
        foreach (Alien alien in _aliens)
        {
            /*Debug.Log((int)transform.position.x + " alieni: " + (int)alien.transform.position.x);*/
            /*for (int i = -11; i<8; i++)
            {
                if((int)transform.position.x == i && (int)alien.transform.position.x == i)
                {
                    alien.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    alien.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }*/
            if (alien!=null && (int)transform.position.x == (int)alien.transform.position.x)
            {
                alien.GetComponent<SpriteRenderer>().color = Color.red;
                if (Input.GetMouseButtonDown(1))
                {
                    alien.AbductAlien();
                    break;
                }
            }
            if (alien != null && (int)transform.position.x != (int)alien.transform.position.x)
            {
                alien.GetComponent<SpriteRenderer>().color = Color.white;
            }
            /*alien.GetComponent<SpriteRenderer>().color = Color.white;*/
        }
    }
/*    private void OnMouseUp()
    {
        Destroy(this.gameObject);
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "topBoundaryOutside")
        {
            Destroy(this.gameObject);
        }
    }


}
