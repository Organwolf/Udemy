using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

// Practice using bitboards

public class CreateBoard : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject housePrefab;
    public GameObject treePrefab;
    public Text score;
    GameObject[] tiles;
    // Every type of cell needs it's own bitboard
    long dirtBB = 0;
    long treeBB = 0;
    long desertBB;
    long playerBB = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Board 8x8 
        tiles = new GameObject[64];

        for(int row=0; row<8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                int randomTile = UnityEngine.Random.Range(0, tilePrefabs.Length);
                Vector3 pos = new Vector3(col, 0, row);
                GameObject tile = Instantiate(tilePrefabs[randomTile], pos, Quaternion.identity);
                tile.name = tile.tag + "_" + row + "_" + col;
                tiles[row * 8 + col] = tile;
                if(tile.tag == "Dirt")
                {
                    dirtBB = SetCellState(dirtBB, row, col);
                }
                if (tile.tag == "Desert")
                {
                    desertBB = SetCellState(desertBB, row, col);
                }
            }
        }
        Debug.Log("Total Desert tiles: " + CellCount(desertBB));
        Debug.Log("Dirt cells = " + CellCount(dirtBB));
        InvokeRepeating("PlantTree", 1, 1);
    }

    void PlantTree()
    {
        int rr = UnityEngine.Random.Range(0, 8);
        int rc = UnityEngine.Random.Range(0, 8);
        if(GetCellState(dirtBB & ~playerBB, rr, rc))
        {
            GameObject tree = Instantiate(treePrefab);
            tree.transform.parent = tiles[rr * 8 + rc].transform;
            tree.transform.localPosition = Vector3.zero;
            treeBB = SetCellState(treeBB, rr, rc);
        }
    }

    void printBB(string name, long bitboard)
    {
        Debug.Log(name + ": " + Convert.ToString(bitboard, 2).PadLeft(64, '0'));
    }

    long SetCellState(long bitboard, int row, int col)
    {
        long newBit = 1L << (row * 8 + col);
        return (bitboard |= newBit);
    }

    bool GetCellState(long bitboard, int row, int col)
    {
        // if there is a 1 at mask pos return true
        long mask = 1L << (row * 8 + col);
        return ((bitboard & mask) != 0);
    }

    int CellCount(long bitboard)
    {
        int count = 0;
        long bb = bitboard;
        while(bb!=0)
        {
            bb &= bb - 1;
            count++;
        } return count;
    }

    void CalculateScore()
    {
        score.text = "Score: " + CellCount(dirtBB & playerBB) * 1
                               + CellCount(desertBB & playerBB) * 2;
                                
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                int row = (int)hit.collider.gameObject.transform.position.z;
                int col = (int)hit.collider.gameObject.transform.position.x;
                if (GetCellState((dirtBB & ~treeBB) | desertBB, row, col))
                {
                    GameObject house = Instantiate(housePrefab);
                    house.transform.parent = hit.collider.gameObject.transform;
                    house.transform.localPosition = Vector3.zero;
                    playerBB = SetCellState(playerBB, row, col);
                    CalculateScore();
                }
            }
        }
    }
}
