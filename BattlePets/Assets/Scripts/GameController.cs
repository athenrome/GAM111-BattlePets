using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public Player PlayerCharacter;

    DataController data = new DataController();

    List<Ability> asdf = new List<Ability>();
    //List<Pet> PetList = new List<Pet>();

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {       	
	}

    Player CreatePlayer()
    {
        Player NewPlayer;

        NewPlayer = new Player("Player", GetPlayerPets());

        return NewPlayer;
    }

    List<Pet>GetPlayerPets()
    {
        int maxPets = 4;
        List<Pet> AvailablePets = new List<Pet>();
        List<Pet> PlayerPets = new List<Pet>();

        for (int i; PlayerPets.Count < 4; i++)
        {
            int Chooser = Random.Range(0, AvailablePets.Count);

            PlayerPets.Add(AvailablePets[i]);
            AvailablePets.Remove(AvailablePets[i]);
        }

        return PlayerPets;
    }
}
