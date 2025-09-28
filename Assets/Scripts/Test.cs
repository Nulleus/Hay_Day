using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    // Add an impulse which produces a change in angular velocity (specified in degrees).
    [System.Serializable]
    public class LootItem
    {
        public string Name;
        [Range(0f, 1f)] public float Probability; // вероятность 0–1
    }

    // Таблица лута можно задать прямо в инспекторе
    public List<LootItem> lootTable = new List<LootItem>
    {
        new LootItem { Name = "Ширпотреб", Probability = 0.76f },
        new LootItem { Name = "Промышленное качество", Probability = 0.18f },
        new LootItem { Name = "Засекреченное", Probability = 0.0020f },
        new LootItem { Name = "Тайное", Probability = 0.0005f }
    };
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    private void Start()
    {
        // Расчет выпавшего предмета при старте сцены
        LootItem droppedItem = GetDroppedItem(lootTable);

        if (droppedItem != null)
            Debug.Log($"Выпал предмет: {droppedItem.Name}");
        else
            Debug.Log("Ничего не выпало.");
    }

    public LootItem GetDroppedItem(List<LootItem> table)
    {
        float randomValue = Random.value; // 0–1
        float cumulative = 0f;

        foreach (var item in table)
        {
            cumulative += item.Probability;
            if (randomValue <= cumulative)
                return item;
        }
        return null; // если сумма вероятностей < 1
    }

    private void OnEnable()
    {

    }

    // Start is called before the first frame update

}
