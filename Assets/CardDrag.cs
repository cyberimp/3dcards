using UnityEngine;
using System.Collections;

public class CardDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 startPosition;
    private bool isDragging;
    private bool isSelected;

    // Use this for initialization
    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
       // startPosition = gameObject.transform.position;

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
        //    gameObject.transform.GetComponentInChildren<ParticleSystem>().Play();
        if (!isSelected)
        {
            isSelected = true;
            LeanTween.cancel(gameObject);
            LeanTween.moveLocal(gameObject, startPosition + new Vector3(0,1,-1), 0.2f);
        }

    }

    public void OnMouseExit()
    {
        //  gameObject.transform.GetComponentInChildren<ParticleSystem>().Stop();
        if (isSelected)
        {
            isSelected = false;
            LeanTween.cancel(gameObject);
            LeanTween.moveLocal(gameObject, startPosition, 0.2f);
        }
    }
}
