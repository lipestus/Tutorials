using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOwnWay : MonoBehaviour {

    public Transform surface, playerBase;

    #region private variables
    private float yPos;
    private Collider2D col;
    #endregion

    void Awake()
    {
        InitializeVariables();
    }
	// Update is called once per frame
	void Update () {
        yPos = playerBase.position.y;
        if (yPos > surface.position.y)
            col.enabled = true;
        else { col.enabled = false; }
    }

    void InitializeVariables()
    {
        playerBase = GameObject.Find("Player").transform;
        col = GetComponent<BoxCollider2D>();
    }
}
