public class Player : Character
{
    // Player Stats
    void Start()
    {
        // Overrides the updated player health on element switch.
        if (hp == 0)
            hp = 100;
        
        dmg = 10;
        range = 1;
    }

    void Attack()
    {
        
    }
}
