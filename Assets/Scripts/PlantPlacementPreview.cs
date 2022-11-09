using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPlacementPreview : MonoBehaviour
{
    public GameObject player;
    private Vector3 initialScale;
    public GameObject badPlacementIndicator;
    private int collisions;
    private static Vector2 getMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    public void Start()
    {
        initialScale = transform.localScale;
    }

    public void OnTriggerEnter2D()
    {
        collisions++;
    }
    
    public void OnTriggerExit2D()
    {
        collisions--;
    }

    private static Vector2 getMousePositionGridlined()
    {
        Vector2 MousePosition = getMousePosition();
        MousePosition -= new Vector2(0.5f, 0.5f);
        MousePosition = new Vector2(Mathf.Round(MousePosition.x), Mathf.Round(MousePosition.y));
        MousePosition += new Vector2(0.5f, 0.5f);
        return MousePosition;
    }

    public bool CanPlantHere()
    {
        return collisions == 0;
    }

    // Update is called once per frame
    void Update()
    {
        MainCharacter mc = player.GetComponent<MainCharacter>();
        bool holdingSeeds = mc.HeldItem().item == Item.SEEDS;
        if (holdingSeeds)
        {
            transform.localScale = initialScale;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }

        badPlacementIndicator.SetActive(!CanPlantHere());
        
        transform.position = (Vector3) getMousePositionGridlined() + new Vector3(0,0, -0.1f);
    }
}