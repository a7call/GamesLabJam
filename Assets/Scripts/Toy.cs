using System.Collections;
using UnityEngine;

public enum ToyType
{
    Bear,
    Bunny,
    Other
}
public class Toy : MonoBehaviour
{
    public ToyType type;
    public bool isPicked;


}
