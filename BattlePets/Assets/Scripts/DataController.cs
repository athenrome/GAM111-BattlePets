using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DataController : MonoBehaviour {

    GameController game = new GameController();

    public TextAsset PetData;
    

    
    


	void Awake () {
        LoadPetData();
	}
	
    void LoadPetData()
    {

        List<PetData> RawPetData;

        System.IO.StringReader reader = new System.IO.StringReader(PetData.text);
        CsvHelper.CsvParser parser = new CsvHelper.CsvParser(reader);
        CsvHelper.CsvReader CsvReader = new CsvHelper.CsvReader(parser);
        CsvReader.Configuration.AutoMap<PetData>();

        RawPetData = CsvReader.GetRecords<PetData>().ToList();

        ProcessPetData(RawPetData);

    }

    void ProcessPetData(List<PetData> RawPetData)
    {
        Pet NewPet;

        List<Pet> NewPetList = new List<Pet>();

        foreach(PetData RawPet in RawPetData)
        {
            string PetName = RawPet.Name;
            ElementType ElementType = ChooseElement(RawPet.ElementType);
            int PetHealth = ConvertToInt(RawPet.Health);
            int PetStrength = ConvertToInt(RawPet.Strength);
            float PetSpeed = ConvertToFloat(RawPet.Speed);
            int CurrentXP = ConvertToInt(RawPet.Xp);
            int CurrentLvl = ConvertToInt(RawPet.Lvl);
            float FireRes = ConvertToFloat(RawPet.FireRes);
            float EarthRes = ConvertToFloat(RawPet.EarthRes);
            float WaterRes = ConvertToFloat(RawPet.WaterRes);
            float AirRes = ConvertToFloat(RawPet.AirRes);


            NewPet = new Pet(PetName, ElementType, PetHealth, PetStrength, PetSpeed, CurrentXP, CurrentLvl, FireRes, EarthRes, WaterRes, AirRes);

            NewPetList.Add(NewPet);
            game.PetList.Add(NewPet);
        }

        game.PetList = NewPetList;

        print(NewPetList.Count);

    }

    ElementType ChooseElement(string ToConvert)
    {

        ElementType NewPetElement = ElementType.Default;

        switch (ToConvert)
        {
            case "Air":
                NewPetElement = ElementType.Air;
                break;
            case "Earth":
                NewPetElement = ElementType.Earth;
                break;
            case "Fire":
                NewPetElement = ElementType.Fire;
                break;
            case "Water":
                NewPetElement = ElementType.Water;
                break;
        }

        return NewPetElement;
    }

    int ConvertToInt(string ToConvert)
    {
        int NewInt;

        NewInt = int.Parse(ToConvert);

        return NewInt;
    }


    float ConvertToFloat(string ToConvert)
    {
        float NewFloat;

        NewFloat = float.Parse(ToConvert);

        return NewFloat;
    }
}
