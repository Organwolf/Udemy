using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CreateBoard : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public GameObject housePrefab;
    public Text score;
    // Every type of cell needs it's own bitboard
    long dirtBB;

    // Start is called before the first frame update
    void Start()
    {
        // Board 8x8 
        for(int row=0; row<8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                int randomTile = UnityEngine.Random.Range(0, tilePrefabs.Length);
                Vector3 pos = new Vector3(col, 0, row);
                GameObject tile = Instantiate(tilePrefabs[randomTile], pos, Quaternion.identity);
                tile.name = tile.tag + "_" + row + "_" + col;
                if(tile.tag == "Dirt")
                {
                    dirtBB = SetCellState(dirtBB, row, col);
                    //printBB("Dirt", dirtBB);
                }
            }
        }
        Debug.Log("Dirt cells = " + CellCount(dirtBB));
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
