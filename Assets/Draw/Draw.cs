using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    [SerializeField] Camera cam = null;
    [SerializeField] LineRenderer trailPrefab = null;
    

    private LineRenderer currentTrail;
    private List<Vector3> points = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        if (!cam)
        {
            cam = Camera.main;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            createNewLine();
        }

        if (Input.GetMouseButton(0))
        {
            addPoint();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            deletePoint();
        }

    }

    private void createNewLine()
    {
        currentTrail = Instantiate(trailPrefab);
        currentTrail.transform.SetParent(transform, true);
        points.Clear();
    }

    private void updateLinePoints()
    {
        if(currentTrail != null && points.Count > 1)
        {
            currentTrail.positionCount = points.Count;
            currentTrail.SetPositions(points.ToArray());
        }
    }

    private void addPoint()
    {
        if(cam == null)
        {
            return;
        }

        var Ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(Ray, out hit))
        {
            if (hit.collider.CompareTag("writeable"))
            {
                points.Add(hit.point);
                updateLinePoints();
                return;
            }
            else
                return;
        }


    }

    private void deletePoint()
    {
        if (transform.childCount != 0)
        {
            foreach (Transform R in transform)
            {
                Destroy(R.gameObject);
            }
        }
    }
}
