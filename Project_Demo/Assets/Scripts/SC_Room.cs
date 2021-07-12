using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Room
{

    public Vector2Int roomCoordinate;
    public Dictionary<string, SC_Room> neighbors;

    //only needs to initialize the room coordinate and a dictionary with neighbors information.
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

    /*This method will return the coordinates of all neighbors of the current room. 
    Each room has a neighbor in each one of the four directions: North, East, South and West. 
    This order is important, since it will be necessary to instantiate the Rooms in the game later.*/
    public List<Vector2Int> NeighborCoordinates()
    {
        List<Vector2Int> neighborCoordinates = new List<Vector2Int>();
        neighborCoordinates.Add(new Vector2Int(this.roomCoordinate.x, this.roomCoordinate.y - 1));
        neighborCoordinates.Add(new Vector2Int(this.roomCoordinate.x + 1, this.roomCoordinate.y));
        neighborCoordinates.Add(new Vector2Int(this.roomCoordinate.x, this.roomCoordinate.y + 1));
        neighborCoordinates.Add(new Vector2Int(this.roomCoordinate.x - 1, this.roomCoordinate.y));

        return neighborCoordinates;
    }


    //This method will check what is the direction of the room and add it alongside its direction in the neighbors dictionary.
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


    /*This method returns the name of the Room Prefab of the current room. 
    Notice that, since the NeighborCoordinates method returns the neighbors in the correct order, 
    the name returned by PrefabName matches the name of the prefab we want to instantiate.*/
    public string PrefabName()
    {
        string name = "Room_";
        foreach (KeyValuePair<string, SC_Room> neighborPair in neighbors)
        {
            name += neighborPair.Key;
        }
        return name;
    }

    public SC_Room Neighbor(string direction)
    {
        return this.neighbors[direction];
    }


}
