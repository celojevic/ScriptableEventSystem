using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/Vars/Change/Bool")]
public class BoolVarChange : VarChange
{

    /// <summary>
    /// How to modify the bool variable's current value.
    /// True will set it true, false will set it false, and switch will set it opposite its current value.
    /// </summary>
    public BoolOp BoolOp;

}
