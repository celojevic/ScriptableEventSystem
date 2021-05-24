using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    #region Singleton

    public static GlobalVariables Instance;


    private void Awake()
    {
        Instance = this;
    }
    
    #endregion

    public List<Var> Vars = new List<Var>();


}
