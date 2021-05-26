using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/Vars/Change/String")]
public class StringVarChange : VarChange
{

    public string NewValue;

    /// <summary>
    /// How to modify the string variable.
    /// </summary>
    public StringOp StringOp;

}
