using System.Collections;
using System.Dynamic;
using System.Numerics;

class Player
{  
 
    //fields
    public Inventory backpack { get;}
    public int health;
    // auto property
    public Room CurrentRoom { get; set; }
    // constructor
    public Player()
    {   
    CurrentRoom = null;

    
        health = 100;

        // 25kg is best zwaar om de hele dag te dragen
        backpack = new Inventory(25);

    }

   public bool TakeFromChest(string itemName)
    {
           // TODO implementeer:
          // Haal het Item uit de Room
        
         // Zet het in je backpack
        // Bekijk de return values
       // Past het Item niet? Zet het terug in de chest
      // Laat de speler weten wat er gebeurt
     // Return true/false voor succes/mislukt
       return false;
    }
        public bool DropToChest(string itemName)
    {
        // TODO implementeer:
        // Haal Item uit je backpack
        // Zet het in de Room
        // Bekijk de return values
        // Laat de speler weten wat er gebeurt
        // Return true/false voor succes/mislukt
    return false;
    }
}
