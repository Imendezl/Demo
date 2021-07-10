using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Room
{

    public Vector2Int roomCoordinate;
    public Dictionary<string, SC_Room> neighbors;

    public SC_Room(int xCoordinate, int yCoordinate)
    {
        this.roomCoordinate = new Vector2Int(xCoordinate, yCoordinate);
        this.neighbors = new Dictionary<string, SC_Room>();
    }

    public SC_Room(Vector2Int roomCoordinate)
    {
        this.roomCoordinate = roomCoordinate;
        this.neighbors = new Dictionary<string, SC_Room>();
    }

    public List<Vector2Int> NeighborCoordinates()
    {
        List<Vector2Int> neighborCoordinates = new List<Vector2Int>();
        neighborCoordinates.Add(new Vector2Int(this.roomCoordinate.x, this.roomCoordinate.y - 1));
        neighborCoordinates.Add(new Vector2Int(this.roomCoordinate.x + 1, this.roomCoordinate.y));
        neighborCoordinates.Add(new Vector2Int(this.roomCoordinate.x, this.roomCoordinate.y + 1));
        neighborCoordinates.Add(new Vector2Int(this.roomCoordinate.x - 1, this.roomCoordinate.y));

        return neighborCoordinates;
    }

    public void Connect(SC_Room neighbor)
    {
        string direction = "";
        if (neighbor.roomCoordinate.y < this.roomCoordinate.y)
        {
            direction = "N";
        }
        if (neighbor.roomCoordinate.x > this.roomCoordinate.x)
        {
            direction = "E";
        }
        if (neighbor.roomCoordinate.y > this.roomCoordinate.y)
        {
            direction = "S";
        }
        if (neighbor.roomCoordinate.x < this.roomCoordinate.x)
        {
            direction = "W";
        }
        this.neighbors.Add(direction, neighbor);
    }

    public string PrefabName()
    {
        string name = "Room_";
        foreach (KeyValuePair<string, SC_Room> neighborPair in neighbors)
        {
            name += neighborPair.Key;
        }
        return name;
    }


}
