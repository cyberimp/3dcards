using UnityEngine;
using System.Collections;

public class CardDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        startPosition = gameObject.transform.position;

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }


    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);


        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    public void OnMouseUpAsButton()
    {
        gameObject.transform.position = startPosition;
    }

    public void OnMouseEnter()
    {
        gameObject.transform.Translate(0, 0.5f, -1);
        gameObject.transform.GetComponentInChildren<ParticleSystem>().Play();

    }

    public void OnMouseExit()
    {
        gameObject.transform.Translate(0, -0.5f, 1);
        gameObject.transform.GetComponentInChildren<ParticleSystem>().Stop();
    }
}
