using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Camera main = null;
    Transform trans = null;

    private void Start()
    {
        main = Camera.main;
        trans = transform;
    } // Start

    private Vector3 screenPoint;
    private Vector3 offset;

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        screenPoint = main.WorldToScreenPoint(trans.position);
        offset = trans.position - main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    } // OnMouseDown

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = main.ScreenToWorldPoint(curScreenPoint) + offset;

        trans.position = curPosition;
    } // OnMouseDrag

    private void OnMouseUp()
    {
        Debug.Log("Released " + gameObject.name.ToString());
    } // OnMouseUp

} // Class