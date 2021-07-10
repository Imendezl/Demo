using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DungeonGeneration : MonoBehaviour
{

    [SerializeField]
    private int numberRooms;
    private SC_Room[,] rooms;
    private static SC_DungeonGeneration instance = null;
    private SC_Room currentRoom;



    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            this.currentRoom = GenerateDungeon();
        }
        else
        {
            string roomPrefabName = instance.currentRoom.PrefabName();
            GameObject roomObject = (GameObject)Instantiate(Resources.Load(roomPrefabName));
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        string roomPrefabName = this.currentRoom.PrefabName();
        GameObject roomObject = (GameObject)Instantiate(Resources.Load(roomPrefabName));
    }

    private SC_Room GenerateDungeon()
    {
        //Define the size of the grid where the rooms will be saved
        int gridSize = 3 * numberRooms;

        rooms = new SC_Room[gridSize, gridSize];

        //Coordinates in the grid center
        Vector2Int initialRoomCoordinate = new Vector2Int((gridSize / 2) - 1, (gridSize / 2) - 1);

        //Create an empty dictionary when the rooms will be saved
        Queue<SC_Room> roomsToCreate = new Queue<SC_Room>();
        //Add the initial room
        roomsToCreate.Enqueue(new SC_Room(initialRoomCoordinate.x, initialRoomCoordinate.y));
        //List where the created rooms are saved
        List<SC_Room> createdRooms = new List<SC_Room>();

        /*While the number of rooms is less than a desired number “n”, repeat:
            Pick the first room in the rooms_to_create list
            Add the room to the grid in the correspondent location
            Create a random number of neighbors and add them to rooms_to_create*/
        while (roomsToCreate.Count > 0 && createdRooms.Count < numberRooms)
        {
            SC_Room currentRoom = roomsToCreate.Dequeue();
            this.rooms[currentRoom.roomCoordinate.x, currentRoom.roomCoordinate.y] = currentRoom;
            createdRooms.Add(currentRoom);
            AddNeighbors(currentRoom, roomsToCreate);
        }

        //Connect the neighbor rooms
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

        /* Checking what neighbor coordinates are actually available to be selected as having rooms
        (A coordinate is available only if there is not any other room occupying its place)*/
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

    public void MoveToRoom(SC_Room room)
    {
        this.currentRoom = room;
    }

    public SC_Room CurrentRoom()
    {
        return this.currentRoom;
    }



}



