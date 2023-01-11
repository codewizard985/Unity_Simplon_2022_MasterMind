using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class SecretCode : MonoBehaviour
{
    /**
     * A "Sprite" is a visual object that can move on a grid. It can have different shapes and colors, be animated and be associated with an image. 
     * It is positioned on a grid either using an index or an address. 
     * Each grid has a collection of Sprites accessible in design mode through the Sprites property.
     * **/
    [SerializeField] Color Yellow, Blue, Red, Green, White, Black;

    /**
     * "string[]" can create a single-dimensional array using the "new" operator specifying the array element type and the number of elements.
     * Arrays can store any element type you specify.
     **/
    public string[] secretCode = new string[4];

    /**
     * A Dictionary<TKey,TValue> contains a collection of key/value pairs. Its Add method takes two parameters, one for the key and one for the value. 
     * One way to initialize a Dictionary<TKey,TValue>, or any collection whose Add method takes multiple parameters, is to enclose each set of parameters in braces.
     * Another option is to use an index initializer.
     * The dictionary is a collection of maps. 
     * Dictionaries aid in the management of data in Key-Value pairs, allowing us to quickly access and alter the information.
     * 
     * There's no built-in map in the C# language. For all the mapping needs, we utilize a "Dictionary".
     **/
    private Dictionary<string, Color> mapColor= new Dictionary<string, Color>();

    /**
     * Awake is called when the script instance is being loaded.
     *  Awake initialize variables or states before the application starts.
    **/
    void Awake()
    {
        mapColor.Add("yellow", Yellow);    //adding a key/value using the Add() method
        mapColor.Add("blue", Blue);
        mapColor.Add("red", Red);
        mapColor.Add("green", Green);
        mapColor.Add("white", White);
        mapColor.Add("black", Black);
    }

    // The computer choose a secret color code randomnly.
    // This will be done by a public function who will be returning an array with the secret code.
    public Array GetNewSecretCode()
    {
        for (int i = 0; i < secretCode.Length; i++)
        {
            int rnd = UnityEngine.Random.Range(0, mapColor.Count); // "count" take a random number from dictionary length
            secretCode.SetValue(mapColor.ElementAt(rnd).Key, i);   // "SetValue" put a key of the dictionary.
            // "ElementAt" take the number that was generated randomly with (rnd) and take its key.
        }

        // print the color on screen
        // "Transform" is used to store and manipulate the position, rotation and scale of the object.
        transform.Find("Peg").GetComponent<MeshRenderer>().material.color = mapColor[secretCode[0]];  // "ToString" returns the name of the object.
        transform.Find("Peg 1").GetComponent<Image>().color = mapColor[secretCode.GetValue(1).ToString()];
        transform.Find("Peg 2").GetComponent<Image>().color = mapColor[secretCode.GetValue(2).ToString()];
        transform.Find("Peg 3").GetComponent<Image>().color = mapColor[secretCode.GetValue(3).ToString()];

        return secretCode;
    }
}
