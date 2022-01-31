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
    private Alien chosenAlien = null;
    private Rigidbody2D rb;
    [SerializeField] Vector3 force;
    /*private float translation;
    private readonly float LeftlimitScreen = -10.23f;
    private readonly float RightlimitScreen = 7.53f;
    private float movementSpeed = 2;*/
    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void OnEnable()
    {
        
    }
    private void Start()
    {
        _aliens = FindObjectsOfType<Alien>();
    }
    private void Update()
    {
        float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * amtToMove, Space.World);

        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        /*Vector3 position = this.transform.position;
        translation = Input.acceleration.x * movementSpeed * 50f;

        if (this.transform.position.x + translation < LeftlimitScreen)
        {
            position.x = -LeftlimitScreen;
        }
        else if (transform.position.x + translation > RightlimitScreen)
        {
            position.x = RightlimitScreen;
        }
        else
        {
            position.x += translation;
            this.transform.position = position;
        }*/

    }

    private void OnMouseDrag()
    {
        //SpriteRenderer.color = new Color(1f, 1f, 1f, .5f);4

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);

        Vector2 directionToInitialPosition = transform.position;
        this.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        /* _spaceshipWasLaunched = true;*/
        Debug.Log("ALIENAT   " + _aliens.Length);
        foreach (Alien alien in _aliens)
        {
            Debug.Log("hello"+alien);
            if (alien != null && (int)transform.position.x == (int)alien.transform.position.x)
            {
                alien.GetComponent<SpriteRenderer>().color = Color.blue;
                Debug.Log("ALIENI I ZGJEDHUR12345678: " + alien);
                chosenAlien = alien;
            }
            if (alien != null && (int)transform.position.x != (int)alien.transform.position.x)
            {
                alien.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
    private void OnMouseUp()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        Debug.Log("ALIENI I ZGJEDHUR: " + chosenAlien);
        if (chosenAlien !=null && chosenAlien.GetComponent<SpriteRenderer>().color == Color.white)
        {

            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            chosenAlien = null;
        }
        if (chosenAlien != null)
        {
            float step = 0.001f * Time.deltaTime; 
            chosenAlien.transform.position = Vector3.MoveTowards(transform.position, this.transform.position, step);
            chosenAlien.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            chosenAlien.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;


            StartCoroutine(DestroyAlien());

        }

    }

    public IEnumerator DestroyAlien()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(chosenAlien.gameObject);

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 3.0f);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "topBoundaryOutside")
        {
            Destroy(this.gameObject);
            ScoreQuestion.Instance.AddScore(1);
        }
        if(collision.gameObject.tag == "leftBoundary")
        {
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

}
