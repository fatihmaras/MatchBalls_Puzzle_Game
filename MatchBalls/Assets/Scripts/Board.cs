using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;

    public int borderSize;

    public GameObject tilePrefab;

    Tile [,] _allTiles;
    // Start is called before the first frame update
    void Start()
    {
        _allTiles= new Tile[width,height];
        SetupTiles();
        SetupCamera();
    }

    void SetupTiles()
    {
        for(int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                GameObject tile= Instantiate(tilePrefab,new Vector3(i,j,0),Quaternion.identity);  // "as GameObject" is not neccessary
                tile.name ="Tile" + "(" +i + "," +j + ")";

                _allTiles[i,j] = tile.GetComponent<Tile>();
                tile.transform.parent = transform; 
                _allTiles[i,j].Init(i,j,this);

            }
        }
    }

    void  SetupCamera()
    {
        Camera.main.transform.position = new Vector3 ((float)(width -1 )/2 ,(float) (height-1)/2 , -10f);

        float aspectRatio = (float) Screen.width / (float) Screen.height;

        float verticalSize  = (float) height/2f + (float)borderSize;

        float horizontalSize =  ((float) width/2f + (float) borderSize ) / aspectRatio;

        Camera.main.orthographicSize = (verticalSize > verticalSize) ? verticalSize : horizontalSize;


    }
}
