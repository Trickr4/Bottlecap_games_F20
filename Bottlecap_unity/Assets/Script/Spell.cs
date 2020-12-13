using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    // Start is called before the first frame update
    
    private bool casted = false;
    [SerializeField] private MeshRenderer showSpell;
    [SerializeField] private Animator showAni;
    public GameObject spellcaster;
    float castDelay;
    float castDuration;
    
    void Start()
    {
        showAni.enabled = false;
        showSpell.enabled = false;
        transform.Find("Parts/aoeFire2").gameObject.GetComponent<SpellHurtBox>().spellcaster = spellcaster;
        transform.Find("Parts/aoeFire2").gameObject.GetComponent<BoxCollider>().enabled = false;
        castDelay = spellcaster.GetComponent<SpellcasterEnemy>().castDelay;
        castDuration = spellcaster.GetComponent<SpellcasterEnemy>().castDuration;
    }

    // Update is called once per frame
    void Update()
    {
        
        float time = Time.deltaTime;
        if(castDelay <= 0 && !casted)
        {
            showSpell.enabled = true;
            casted = true;
            showAni.enabled = true;
            transform.Find("Parts/aoeFire2").gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            castDelay -= time;
        }
        if(casted)
        {
            if(castDuration <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                castDuration -= time;
            }
        }
    }
}
