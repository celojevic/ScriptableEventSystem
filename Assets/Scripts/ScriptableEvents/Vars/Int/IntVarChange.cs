using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/Vars/Change/Int")]
public class IntVarChange : VarChange
{

    /// <summary>
    /// How much to change the int variable current value.
    /// </summary>
    public int Val;

    /// <summary>
    /// How to modify the int variable's current value by the Val.
    /// </summary>
    public MathOp MathOp;

}
