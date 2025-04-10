using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameboard : MonoBehaviour
{
    int index = -1;

    public int Playerturn()
    {
        index++;
        return index % 2;
    }
}
