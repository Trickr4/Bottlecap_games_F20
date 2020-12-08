using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected int hp;
    protected int dmg;
    protected int speed;
    [SerializeField] protected Sprite image;
    //range is times 100 px
    protected int range;
}
