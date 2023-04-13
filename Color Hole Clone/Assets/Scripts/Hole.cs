using DG.Tweening;
using UnityEngine;

public class Hole : MonoBehaviour
{
    Camera mainCamera;
    bool canTranslate;
    Vector3 reelPosition;
    float positionZ, positionY;
    public Transform doorTransform;


    private void Awake()
    {
        if (Camera.main) mainCamera = Camera.main;
        positionY = transform.position.y;
    }
    

    private void Update()
    {
        if(!GameManager.finish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 holePosition = gameObject.transform.position;
                positionZ = mainCamera.WorldToScreenPoint(holePosition).z;
                reelPosition = holePosition - GetMouseWorldPos();
            }

            if (Input.GetMouseButton(0))
            {
                if (!GameManager.firstPartEnded)
                {
                    transform.position = new Vector3(Mathf.Clamp(GetMouseWorldPos().x + reelPosition.x, -2.175f, 2.175f), positionY, Mathf.Clamp(GetMouseWorldPos().z + reelPosition.z, -3.5f, 2.5f));
                }
                else
                {
                    if (!canTranslate)
                        transform.position = new Vector3(Mathf.Clamp(GetMouseWorldPos().x + reelPosition.x, -2.175f, 2.175f), positionY, Mathf.Clamp(GetMouseWorldPos().z + reelPosition.z, 11.538f, 17.559f));
                }
            }
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        var touchPoint = Input.mousePosition;
        touchPoint.z = positionZ;
        return mainCamera.ScreenToWorldPoint(touchPoint);
    }
    public void HorizontalMove()
    {
        canTranslate = true;
        transform.DOMoveX(0, 1f).OnComplete(DoorMove);
    }
    public void DoorMove()
    {
        doorTransform.DOMoveY(2,1.5f).OnComplete(VerticalMove);
    }

    public void VerticalMove()
    {
        Object.FindObjectOfType<CameraMove>().Movement();
        transform.DOMoveZ(11.54f, 5f).OnComplete(AllowMove);
    }


    public void AllowMove()
    {
        canTranslate = false;
    }
}