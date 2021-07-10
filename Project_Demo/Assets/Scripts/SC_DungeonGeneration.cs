using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DungeonGeneration : MonoBehaviour
{

    [SerializeField]
    private int numberRooms;

    private SC_Room[,] rooms;

    void Start()
    {
        GenerateDungeon();
        string roomPrefabName = GenerateDungeon().PrefabName();
        GameObject roomObject = (GameObject)Instantiate(Resources.Load(roomPrefabName));
    }

    private SC_Room GenerateDungeon()
    {
        int gridSize = 3 * numberRooms;

        rooms = new SC_Room[gridSize, gridSize];

        Vector2Int initialRoomCoordinate = new Vector2Int((gridSize / 2) - 1, (gridSize / 2) - 1);

        Queue<SC_Room> roomsToCreate = new Queue<SC_Room>();
        roomsToCreate.Enqueue(new SC_Room(initialRoomCoordinate.x, initialRoomCoordinate.y));
        List<SC_Room> createdRooms = new List<SC_Room>();

        while (roomsToCreate.Count > 0 && createdRooms.Count < numberRooms)
        {
            SC_Room currentRoom = roomsToCreate.Dequeue();
            this.rooms[currentRoom.roomCoordinate.x, currentRoom.roomCoordinate.y] = currentRoom;
            createdRooms.Add(currentRoom);
            AddNeighbors(currentRoom, roomsToCreate);
        }

        foreach (SC_Room room in createdRooms)
        {
            List<Vector2Int> neighborCoordenates = room.NeighborCoordinates();
            foreach (Vector2Int coordinate in neighborCoordenates)
            {
                SC_Room neighbor = this.rooms[coordinate.x, coordinate.y];
                if (neighbor != null)
                {
                    room.Connect(neighbor);
                }
            }
        }
        return this.rooms[initialRoomCoordinate.x, initialRoomCoordinate.y];
    }

    private void AddNeighbors(SC_Room currentRoom, Queue<SC_Room> roomsToCreate)
    {
        List<Vector2Int> neighborCoordinates = currentRoom.NeighborCoordinates();
        List<Vector2Int> availableNeighbors = new List<Vector2Int>();
        foreach (Vector2Int coordinate in neighborCoordinates)
        {
            if (this.rooms[coordinate.x, coordinate.y] == null)
            {
                availableNeighbors.Add(coordinate);
            }
        }

        int numberOfNeighbors = (int)Random.Range(1, availableNeighbors.Count);

        for (int neighborIndex = 0; neighborIndex < numberOfNeighbors; neighborIndex++)
        {
            float randomNumber = Random.value;
            float roomFrac = 1f / (float)availableNeighbors.Count;
            Vector2Int chosenNeighbor = new Vector2Int(0, 0);
            foreach (Vector2Int coordinate in availableNeighbors)
            {
                if (randomNumber < roomFrac)
                {
                    chosenNeighbor = coordinate;
                    break;
                }
                else
                {
                    roomFrac += 1f / (float)availableNeighbors.Count;
                }
            }
            roomsToCreate.Enqueue(new SC_Room(chosenNeighbor));
            availableNeighbors.Remove(chosenNeighbor);
        }
    }

    private void PrintGrid()
    {
        for (int rowIndex = 0; rowIndex < this.rooms.GetLength(1); rowIndex++)
        {
            string row = "";
            for (int columnIndex = 0; columnIndex < this.rooms.GetLength(0); columnIndex++)
            {
                if (this.rooms[columnIndex, rowIndex] == null)
                {
                    row += "X";
                }
                else
                {
                    row += "R";
                }
            }
            Debug.Log(row);

        }
    }
}



