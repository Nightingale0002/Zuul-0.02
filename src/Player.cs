using System.Collections;
using System.Dynamic;
using System.Numerics;

class Player
{  
 
    private bool dead;
    //fields
    public int health;
    // auto property
    public Room currentRoom { get; set; }
    // constructor
    public Player()
    {   
    currentRoom = null;

    
        health = 100;

    }

    
   

}
