using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public List<Pet> PetList = new List<Pet>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        print("game" + PetList.Count);
	
	}



}
