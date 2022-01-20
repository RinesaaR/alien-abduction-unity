using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _spaceshipWasLaunched;
    private float _timeSittingAround;
    [SerializeField] private float _launchPower = 500;
    private void Awake()
    {
        _initialPosition = transform.position;
    }
    //private void Start()
    //{
        //GameObject newGO = new GameObject("myTextGO");
      //  transform.SetParent(this.transform);

        
    //}
    private void Update()
    {

        GameObject newGO = new GameObject("myTextGO");
        //  transform.SetParent(this.transform);
        newGO.AddComponent<Text>().text = "Hello";
        GetComponent<Text>().color = Color.red;
        //myText.text = "Ta-dah!";

        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        //if (_spaceshipWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        //{
        //    _timeSittingAround += Time.deltaTime;
        //}

        //if (transform.position.y > 5.51 || transform.position.y < -4.87 || transform.position.x > 10 ||
        //    transform.position.x < -10 || _timeSittingAround > 3)
        //{
        //    string currentSceneName = SceneManager.GetActiveScene().name;
        //    SceneManager.LoadScene(currentSceneName);
        //}
    }
    //private void OnMouseDown()
    //{
    //    GetComponent<SpriteRenderer>().color = Color.red;
    //    GetComponent<LineRenderer>().enabled = true;
    //}
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
    private void OnMouseUp()
    {
        Vector2 directionToInitialPosition = transform.position;
        _spaceshipWasLaunched = true;
    }
    
}
