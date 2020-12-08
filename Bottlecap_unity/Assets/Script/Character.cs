using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected float hp;
    protected float dmg;
    protected float speed;
    [SerializeField] protected Sprite image;
    //range is times 100 px
    protected float range;

    public float getHP(){return hp;}
    public float getDMG(){return dmg;}
    public float getSPEED(){return speed;}
    public Sprite getIMAGE(){return image;}
    public float getRANGE(){return range;}

}
