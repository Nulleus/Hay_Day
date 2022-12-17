using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

public class Test : MonoBehaviour
{
    [ShowInInspector]
    Root MyDeserializedClass;
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class MissingIngredient
    {
        public string ingredient_name { get; set; }
        public int count_ingredients { get; set; }
    }

    public class Root
    {
        public List<MissingIngredient> MissingIngredients { get; set; }
    }

    private void OnEnable()
    {
        var myJsonResponse = "{ 'missingingredients': [ { 'ingredient_name': 'corn', 'count_ingredients': 1 }, { 'ingredient_name': 'soybean', 'count_ingredients': 2 } ] }";
        
        MyDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    }
    // Start is called before the first frame update

}
