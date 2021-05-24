using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{

    public List<Var> Vars = new List<Var>();

    private void Awake()
    {
        //Load();
    }

    void Load()
    {
        for (int i = 0; i < Vars.Count; i++)
        {
            Vars[i] = SaveManager.Load<IntVar>(Vars[i].name);
        }
    }

    private void OnDestroy()
    {
        //Save();
    }

    void Save()
    {
        foreach (var item in Vars)
        {
            SaveManager.Save(item.name, item);
        }
    }

}
