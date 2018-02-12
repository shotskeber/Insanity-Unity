using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSkillTree : MonoBehaviour {

     public Vector2 gridSize;
     public GameObject[][] gridOfGameObjects;
     
     // Use this for initialization
     void Start ()
     {
         gridSize = new Vector2(3, 4);
         gridOfGameObjects = new GameObject[(int)gridSize.x][];
         for (int x = 0; x < gridSize.x; x++)
         {
             gridOfGameObjects[x] = new GameObject[(int)gridSize.y];
             for (int y = 0; y < gridSize.y; y++)
             {
                 GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                 // manipulate gameobject here
                 gridOfGameObjects[x][y] = go;
             }
         }
	}
}
