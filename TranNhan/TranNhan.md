# Code Reflection
## Author's info
**Name:** Tran Hau Trung Nhan

**Student ID:** 300444682

**Role:** Lead Programmer

## Code Discussion
- **Quick rundown of code involvement:**
  - Dashing mechanics: all
  - Knockback & Stun & Invincibility: all
  - Movement (Jumping included): all
  - Power ups: all
  - Menus & Pausing & Credits: all
  - Mapping controls: all
  - HUD: touched
  - Map designing and editing: touched
  - Projectiles: touched
  - Sprites application: touched
  - Sounds: touched

- **Highlights:**
  - I would like to go through the stuffs that I've done that seems interesting and they will go from the order of easy to complicated, I would also skip on the small stuffs I touched on
  or small bug fixes that I've made on other people's works.
  
  - Power Ups: This part is quite simple to implement, however since this is a feature that was added literally at the last minute some corners have to be cut and the way I go around it 
  is interesting in my opinion. When the player walk into upgrade capsules they will be robbed of their controls and be granted upgrades accordingly. The normal or "right" way according 
  to me at least is to use the trigger boxes and Unreal's functions that stop player's control but this would be quite time-consuming considering we were minutes away from the deadline.
  I decided to make use of the previous work that I've already did that is already in the game, the "stunned" mechanic which is nothing but a boolean variable that get checked before
  every actions that the player can make, setting this boolean true to false accordingly to simulate the feeling that the upgrade capsule is giving the player abilities. And to trigger
  this event the capsule's blueprint has a collision hitbox component created and placed in the middle that check if the overlapping actor is the player.
  
![Upgrade1](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/Untitled.png)

![Upgrade2](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/2.png)

  - Knockback and Stun: While stun is easy to understand and straight forward same with invincibility, nothing but a boolean check before any player actions knocking the player back on damage was a journey.
  The first major road block for this was how the player receive damage, in the beginning we only use an integer variable that acts as the player's health and substract accordingly, seems
  easy and simple on paper but this pose the problem that there is no decent way to trigger the given events in unreal and I have to make a trip to other's works on how they implementing
  damage and use the node "apply damage" and make sure the player don't take 2 instead of 1 damage and communicate with other teammates and make sure they use this systems from now on.
  The second major problem was having no simple way to find the direction the player should be moved to, the original way of implementing this was putting the knockback code/blueprints
  inside the character's blueprint and have the direction opposite of where the player is facing as targeted vector, while this is very simple in term of coding or implementing the player's
  experiences suffer and it may lead to unfair situations. I made a major rework after getting feed backs, disabled the old system and have knockback applied to player whenever the enemy's
  projectiles touch the player instead, this works wonder since the only way the enemies can deal damage to the player in the game would only be through their weapons. This is however a bit
  more tedious to do and entirely defeat the purpose of simplifying the code for easier debugging.
  
  ![K&S1](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/K%26S1.png)
  
  ![K&S2](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/K%26S2.png)
  
  ![K&SOld](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/K%26SOld.png)
  
  ![K&SNew](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/K%26SNew.png)
  
  - Menus (and or Mapping controls): Pausing the game or making the main menu functional is very simple to the point of being basic, making it functional for the controller is a different story. Since the game
  was designed with the controller as the main method and intended way of playing making sure the menus work with the controller was vital. I discovered the function of checking the last input was
  very helpful in the creation of this blueprints, also thanks to this specific function or its variants I was able to place all the blueprints under 1 event. Selecting which button you are on 
  and moving it accordingly to the control was the most difficult part, the D-pad and the analog sticks are almost similar except that you gotta check the directional input of the y-axis for the analog.
  After receving inputs and using if clauses(or branches) to check which direction does the player want to input using a small algorithm to see which index should the button be on accordingly we change the index value,
  changing the color of the button. When the player use the select button or bottom face button on the controller the blueprint will take actions according to the current index value. The main menu is mostly the same
  as the pause menu but the pause menu has an extra function that resume the game when the pause button was pressed again when the game is paused. However since the event is trigger on each tick,
  pressing pause button will just pause the game and resume it immediately to combat this bug I added a delay and make sure the game will only unpause when this button is pressed after a miniscule amount of time
  has passed since the game was paused and set this timer back to 0 when the game resumed.
  
  ![Menu1](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/Menus1.png)
  
  ![Menu2](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/Menus2.png)
  
  ![Menu3](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/Menus3.png)
  
  ![Menu4](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/Menus4.png)
  
  - **Dashing** `Favorite`: This is probably the part that I have spent the most time on and with the longest history of many edits and reworks. A quick breakdown about the things I'll talk about,
  There are 3 major parts and what I did with them, new dash, old dash, dash kill. The new dash systems specifically is the part I'm most proud of and vice versa the old dash is the one I dislike the most.
  
  - Let's start with the new dash, weirdly enough even though it's new and more technological advanced it was not in the final
  game version mainly due to time constraint and I was unable to convince the rest of the group to use this dash systems. It was added in at the final stage of the game and there are a still a few bugs that
  need to be fixes but at the same time many works also need to be finished and using the new dash systems also affects other parts of the project that needs to be changed as well. It is however a very interesting
  systems, rather than the usual launch or impulse function as a method to mimic dashing I set the velocity speed of the current movement of the character to a much higher amount and since we are not using launch or
  impulse I got control over the velocity of the character and able to stop them from dashing without forcing the velocity to a halt at 0 which is very rigid and ruin the immersion. Using a count systems I stop the player
  when the dash has reached its maximum length. Also this systems allowed the character to turn when dashing and able to jump after dash for a longer faster jump. This is heavily inspired by the dashing systems of Megaman X franchise
  
  ![NewDash1](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/NewAirDash.png)
  
  ![NewDash2](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/NewAirDash2.png)
  
  ![NewDash3](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/NewGroundDash1.png)
  
  ![NewDash4](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/NewGroundDash2.png)
  
  - The old dash is a much more straight forward systems that apply an impulse or launch character in this case to the player when the dash button is pressed, overwritting the Z and X velocity I can make
  the player to dash straight when they're in the air, while this systems is perfectly fine as it is as a developer I was very limited over the control of the parameters or the way the character dash such as
  unable to turn or have any inputs during the dash, as such invincibility was given to the player when dashing to compenstate. Stopping the dash when the key is released is also a problem, with the launch character
  there is no way to stop said action without manually reducing the velocity which create a rigid motion of stopping each time, it was disabled at the final stage and the dash length was reduced.
  
  ![OldDash1](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/OldDash1.png)
  
  ![OldDash2](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/OldDash2.png)
  
  ![OldDash3](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/OldStopDash.png)
  
  - When the game core mechanic was changed, from shooting projectiles to melee-ing and deflecting attacks, a game mechanic that is closely related to dashing was also scrap. Dashing into some specific type of enemies as a 
  finisher was deemed obsolete, the player is already close to the enemies to begin with and dashing into them will only put the player in a worse position for the next enemy. Besides that there was a small issue with triggering
  component hitboxes to make the mechanic function as intended sometimes finally most importantly it was not fun overall.
  
  ![DashKill1](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/DashKill.png)
  
  ![DashKill2](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/DashKill2.png)
  
- **Bad Code:** Ironically the part that I'm most proud of is also the part that I dislike the most, specifically the old dash systems and the one that is in the final version of the game
While it is not "bad" code in my opinion it is very messy since this was made at the near beginning of the project and I have yet to get into the habit of clearly seperate chunks of nodes and 
commenting, also as was talked above in the code highlights there are problems with the old dash systems and how it is very limiting.

![BadCode](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/BadCode.png)

## Reflection
- What I have learnt: while it sounds cheesy the most important parts that I've learned is probably communication when working on this project. There are many features and mechanics that
were scrap and were not implemented in the making of the project shows that while ideas that might seems brilliant to you it might not hold the same values to others or to the players, it is
proven when we moved from a projectile based game to a melee based game or when we have to use a technically worse dashing systems in favor for a better feel in the game. I have also discovered
my strong points in certain aspects when coding and making blueprints and splitting the works according to your abilities is the many advantages when working with a group of people and I should also
improve my skills in applying sprites and animations. Other than that, I've also improved much on many technical areas that I couldn't name all such as applying sound, music moving sprites and maps in
2D environments.

- The most important thing that will stay with me in future development would be the skills and habits to commenting codes clearly and placement of codes in blocks and chunks to be easier on the eyes,
even if you are the owner, developer of the code it is tiring to go through a messy code especially you are the one who comes into contact with it the most. 

- Comparision of good looking code and bad looking code of mine:

![BadCodeVs](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/BadCode.png)

![GoodCodeVs](https://github.com/guerinchev/Kvetch_II/blob/master/TranNhan/GoodCode.png)

## Video Link: https://youtu.be/fzI9be1E16c 
