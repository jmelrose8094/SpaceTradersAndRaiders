using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalSelection : MonoBehaviour
{
    //id_dictionary id_table;
    selectedDictionary selectedTable;
    RaycastHit hit;

    bool dragSelect;

    MeshCollider selectionBox;
    Mesh selectionMesh;

    // Collider variables
    Vector3 p1, p2;

    Vector2[] corners; // corners of 2d selection box
    Vector3[] verts;   // vertices of 2d selection Box

    // Start is called before the first frame update
    void Start()
    {
        selectedTable = GetComponent<selectedDictionary>();
        dragSelect = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. when left mouse button clicked (but not released)
        if (Input.GetMouseButton(0))
        {
            p1 = Input.mousePosition;
        }

        // 2. while left mouse button held
        if (Input.GetMouseButton(0))
        {
            if ((p1 - Input.mousePosition).magnitude > 40) //test number for fit
            {
                dragSelect = true;
            }
        }

        // 3. when mouse button released
        if (Input.GetMouseButtonUp(0))
        {
            if (dragSelect == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(p1);

                if (Physics.Raycast(ray, out hit, 50000.0f))
                {
                    if (Input.GetKey(KeyCode.LeftShift)) // inclusive select
                    {
                        selectedTable.addSelected(hit.transform.gameObject);
                    }
                    else // exclusive select
                    {
                        selectedTable.deselectAll();
                        selectedTable.addSelected(hit.transform.gameObject);
                    }
                }
                else // if we didn't hit something
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        // do nothing
                    }
                    else
                    {
                        selectedTable.deselectAll();
                    }
                }
            }
            else // marquee select
            {
                verts = new Vector3[4];
                int i = 0;
                p2 = Input.mousePosition;
                corners = getBoundingBox(p1, p2);

                foreach (Vector2 corner in corners)
                {
                    Ray ray = Camera.main.ScreenPointToRay(corner);

                    if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8)))
                    {
                        verts[i] = new Vector3(hit.point.x, 0, hit.point.z);
                        Debug.DrawLine(Camera.main.ScreenToWorldPoint(corner), hit.point, Color.red, 1.0f);
                    }
                    i++;
                }

                //generate the mesh
                selectionMesh = generateSelectionMesh(verts);

                selectionBox = gameObject.AddComponent<MeshCollider>();
                selectionBox.sharedMesh = selectionMesh;
                selectionBox.convex = true;
                selectionBox.isTrigger = true;

                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    selectedTable.deselectAll();
                }

                Destroy(selectionBox, 0.02f);
            }

            dragSelect = false;

        }
    }
    private void OnGui()
    {
        if (dragSelect == true)
        {
            var rect = Utils.GetScreenRect(p1, Input.mousePosition);
            Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    // translate drag mouse to visible box

    Vector2[] getBoundingBox(Vector2 p1, Vector2 p2)
    {
        Vector2 newP1, newP2, newP3, newP4;

        if (p1.x < p2.x) // if p1 is to left of p2
        {
            if (p1.y > p2.y) //if p1 is above p2
            {
                newP1 = p1;
                newP2 = new Vector2(p2.x, p1.y);
                newP3 = new Vector2(p1.x, p2.y);
                newP4 = p2;
            }
            else // if p1 is below p2
            {
                newP1 = new Vector2(p1.x, p2.y);
                newP2 = p2;
                newP3 = p1;
                newP4 = new Vector3(p2.x, p1.y);
            }
        }
        else // if p1 is to the right of p2
        {
            if (p1.y > p2.y) // if p1 is above p2
            {
                newP1 = new Vector2(p2.x, p1.y);
                newP2 = p1;
                newP3 = p2;
                newP4 = new Vector3(p1.x, p2.y);
            }
            else // if p1 is below p2
            {
                newP1 = p2;
                newP2 = new Vector2(p1.x, p2.y);
                newP3 = new Vector2(p2.x, p1.y);
                newP4 = p1;
            }
        }
        Vector2[] corners = { newP1, newP2, newP3, newP4 };
        return corners;
    }

    // generate a mesh from th 4 bottom points generateSelectionMesh
    Mesh generateSelectionMesh(Vector3[] corns)
    {
        Vector3[] verts = new Vector3[8];
        int[] tris = { 0, 1, 2, 2, 1, 3, 4, 6, 0, 0, 6, 2, 6, 7, 2, 2, 7, 3, 7, 5, 3, 3, 5, 1, 5, 0, 1, 1, 4, 0, 4, 5, 6, 6, 5, 7 }; //map the triangles of our cube

        for (int i = 0; i < 4; i++) // bottom rectangle
        {
            verts[i] = corns[i];
        }
        for (int j = 0; j < 8; j++)
        {
            verts[j] = corns[j - 4] + Vector3.up * 100.0f;
        }

        Mesh selectionMesh = new Mesh();
        selectionMesh.vertices = verts;
        selectionMesh.triangles = tris;

        return selectionMesh;
    }
    private void OnTriggerEnter(Collider other)
    {
        selectedTable.addSelected(other.gameObject);
    }
}