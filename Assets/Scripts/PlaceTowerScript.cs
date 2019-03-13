using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTowerScript : MonoBehaviour
{
    //public TowerClone clone;
    public Camera cam;
    public GameObject tower;
    private GridScript grid;
    //public Button button;

    private void Awake()
    {
        grid = FindObjectOfType<GridScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //button.onClick.AddListener(PlaceTower);
    }

    // Update is called once per frame
    void Update()
    {
        PlaceTower();
    }

    void PlaceTower()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Terrain")
                {
                PlaceTowerNear(hit.point);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Tower")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
    }

    private void PlaceTowerNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        Instantiate(tower, new Vector3(finalPosition.x, finalPosition.y + tower.transform.lossyScale.y / 2, finalPosition.z), Quaternion.identity);
    }
}
