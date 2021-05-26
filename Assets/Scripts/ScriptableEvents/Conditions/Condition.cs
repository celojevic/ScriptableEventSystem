using UnityEngine;

public abstract class Condition<T> : Condition where T : System.IComparable<T>
{

    [Tooltip("The Var to compare to the indicated value.")]
    public Var<T> VarToCompare;

    [Tooltip("The equality operator used to compare the VarToCompare's value and the ValueToCompare.")]
    public EqualityOp EqualityOp;

    [Tooltip("The Value to compare to the Var's value.")]
    public T ValueToCompare;

    [Tooltip("If true, the comparison result is reversed.")]
    public bool ReverseComparison = false;

    #region Editor
#if UNITY_EDITOR

    /// <summary>
    /// Makes sure you assign the right type of Var.
    /// </summary>
    private void OnValidate()
    {
        CheckType();
        CheckEqualityOp();
    }

    /// <summary>
    /// Checks if the VarToCompare's type matches that of the derived class.
    /// </summary>
    protected abstract void CheckType();

    void CheckEqualityOp()
    {
        if (typeof(T) == typeof(bool))
        {
            if (EqualityOp > EqualityOp.EqualTo)
            {
                Debug.LogWarning("Can only use EqualTo or NotEqualTo for bools.");
                EqualityOp = EqualityOp.NotEqualTo;
            }
        }
    }

#endif
    #endregion

    /// <summary>
    /// Compares the VarToCompare.Value to the ValueToCompare based on the EqualityOp.
    /// Returns true if it meets the operation conditions, false otherwise.
    /// </summary>
    /// <returns></returns>
    public bool Compare()
    {
        bool value;

        switch (EqualityOp)
        {
            case EqualityOp.NotEqualTo:
                value = (VarToCompare.Value.CompareTo(ValueToCompare) != 0);
                break;
            case EqualityOp.EqualTo:
                value = (VarToCompare.Value.CompareTo(ValueToCompare) == 0);
                break;

            case EqualityOp.LessThan:
                value = (VarToCompare.Value.CompareTo(ValueToCompare) < 0);
                break;
            case EqualityOp.GreaterThan:
                value = (VarToCompare.Value.CompareTo(ValueToCompare) > 0);
                break;

            case EqualityOp.LessThanOrEqualTo:
                value = (VarToCompare.Value.CompareTo(ValueToCompare) <= 0);
                break;
            case EqualityOp.GreaterThanOrEqualTo:
                value = (VarToCompare.Value.CompareTo(ValueToCompare) >= 0);
                break;

            default:
                return false;
        }

        if (ReverseComparison)
            value = !value;

        return value;
    }

}

/// <summary>
/// Needed to keep the type class truly generic in fields, 
/// i.e. you must declare a type for a Condition[] array without this inheritance
/// and we don't want that.
/// </summary>
public class Condition : ScriptableObject { }
