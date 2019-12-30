using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ingredients : MonoBehaviour
{
    private string Name;
    private Dictionary<string, int> Subject = new Dictionary<string, int>();
    // Start is called before the first frame update

    
    public int GetCountByName(string name)
    {
        return Subject[name];
    }
    public void PushSubject(string ingredient, int count)
    {
        Subject.Add(ingredient, count);
    }

    public Dictionary<string,int> GetSubjects()
    {
        return Subject;
    }
    public string[] GetAllKeysSubjects()
    {
        int i=0;
        string[] Array = new string[10];
        Dictionary<string, int>.KeyCollection keyColl = Subject.Keys;
        foreach (string s in keyColl)
        {
            i++;
            Array[i] = s;
            print("Key = {0}"+ s);
        }
        return Array;
    }
}
