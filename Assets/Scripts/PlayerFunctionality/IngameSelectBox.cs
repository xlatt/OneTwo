using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameSelectBox : MonoBehaviour {

    [SerializeField]
    private RectTransform squareImage;

    Vector3 startPos;
    Vector3 endPos;

	// Use this for initialization
	void Start () {
        squareImage.gameObject.SetActive(false);
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f)) {
                startPos = hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            squareImage.gameObject.SetActive(false);
        }

        if (Input.GetMouseButton(0)) {
            if (!squareImage.gameObject.activeInHierarchy)
            {
                squareImage.gameObject.SetActive(true);
            }

            endPos = Input.mousePosition;
            Vector3 squareStart = Camera.main.WorldToScreenPoint(startPos);
            squareStart.z = 0;

            Vector3 centre = (squareStart + endPos) / 2f;
            float sizeX = Mathf.Abs(squareStart.x - endPos.x);
            float sizeY = Mathf.Abs(squareStart.y - endPos.y);

            squareImage.position = centre;
            squareImage.sizeDelta = new Vector2(sizeX, sizeY);



        }

    }


}
