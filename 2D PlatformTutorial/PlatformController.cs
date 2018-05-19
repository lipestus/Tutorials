using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    #region public variables
    public Transform surface, playerBase;
    #endregion

    #region private variables
    private Vector2 direction;
    private int layerMask;
    private float posY;
    private Collider2D col;
    #endregion

    // Use this for initialization
    private void Awake()
    {
        InitializeVariables();
    }

    private void FixedUpdate()
    {
        EnableOwnWay();
    }

    // Update is called once per frame
    void Update()
    {
        posY = playerBase.position.y;
    }

    // initialize variables on Awake method
    void InitializeVariables()
    {
        playerBase = GameObject.Find("Player").transform;
        col = GetComponent<BoxCollider2D>();
        layerMask = LayerMask.GetMask("PlatformEdge");
        direction = Vector2.down;
    }

    //Method to enable platform collider when player's Y axis is greater than the surface Y axis
    void EnableOwnWay()
    {
        if (posY > surface.position.y)
        {
            col.enabled = true;
            ShootRay();
        }
        else { col.enabled = false; }
    }

    void ShootRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerBase.position, direction, 0.3f, layerMask);
        if(hit)
        {
            if (Input.GetKey(KeyCode.S))
                col.enabled = false;
        }
    }
}
