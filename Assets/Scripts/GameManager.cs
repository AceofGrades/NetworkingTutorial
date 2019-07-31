using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public string fileName = "GameData.xml";
    private GameData data = new GameData();

    public void Start()
    {
        Load(Application.dataPath + "/" + fileName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            player = FindObjectOfType<PlayerScript>().transform;
            data.position = player.position;
            data.rotation = player.rotation;
            data.dialogue = new string[]
            {
                "Hello",
                "World!"
            };
            Save(Application.dataPath + "/" + fileName);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Load(Application.dataPath + "/" + fileName);
            player = FindObjectOfType<PlayerScript>().transform;
            player.position = data.position;
            player.rotation = data.rotation;
        }
    }

    public void Load(string path)
    {
        var serializer = new XmlSerializer(typeof(GameData));
        var stream = new FileStream(path, FileMode.Open);
        data = (GameData)serializer.Deserialize(stream);
        stream.Close();
        Debug.Log("Successfully Loaded from " + path);
    }

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(GameData));
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, data);
        stream.Close();
        Debug.Log("File Successfully created in " + path);
    }
}
