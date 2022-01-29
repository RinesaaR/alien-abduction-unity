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
        Debug.Log("ALIENAT   " + _aliens.Length);
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
        //SpriteRenderer.color = new Color(1f, 1f, 1f, .5f);4

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);

        Vector2 directionToInitialPosition = transform.position;
        this.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        /* _spaceshipWasLaunched = true;*/

        foreach (Alien alien in _aliens)
        {
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
        Debug.Log("ALIENI I ZGJEDHUR: " + chosenAlien);
        if (chosenAlien.GetComponent<SpriteRenderer>().color == Color.white)
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
    }

}
