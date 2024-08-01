# Unity VR Project

## Walkthrough Video
[Watch the walkthrough video on youtube!](https://youtu.be/7GUOh9UAUyA)

## Start scene
![image](readme%20images/image.png)
The initial scene shows a simple UI that contains instructions about the game and a play button, set within a forest environment similar to the one in the game.

## Broken down car
![image1](readme%20images/image-1.png)
The user finds themselves on a dirt road in a forest. On one side, there is a fence blocking the road, behind which is their car with the lights on, a broken window, and the hood raised with smoke coming out, indicating that the car has a problem. This, therefore, makes the user understand that they should not interact with the car itself, but should follow the road on the side of the fence where the user is located.

## Fuse box
![image2](readme%20images/image-2.png)
A short distance from the starting point, the player can find a cabinet attached to the first light pole (from which sparks are emitted to help the user notice it). They will need to interact with the cabinet by opening the door (using grab interaction) and lifting the lever to turn on the lights along the road. Once the lights are on, additional visual effects such as sparks from all the lamps and sounds from both the lamps and the fuse box will be played, and the user will be able to continue along the path. Some parts of the fuse box are also modified at runtime while the lever is being lifted, such as the voltage indicator and the LED that shows whether the lights are on or off.
<div style="display: flex; justify-content: space-between;">
    <img src="readme%20images/image-3.png" alt="image3" style="width: 65%;"/>
    <img src="readme%20images/image-4.png" alt="image4" style="width: 35%;"/>
</div>

## Dirty path
In the next part of the path, there is a Trigger Zone that plays a creepy sound (as if there were a monster or an animal in the distance) in 3D coming from the forest, to add to the horror atmosphere.

## Monster's shadow jumpscare
![image5](readme%20images/image-5.png)
The player continues along the path, reaching a fallen lamp post whose light keeps flickering on and off and emitting sparks. As the player approaches, the shadow of a monster is shown on a rock until the shadow appears to run towards the player.
![image6](readme%20images/image-6.png)

## Monster's attack
![image7](readme%20images/image-7.png)
The player continues along the path until they see a human figure in the distance. The player tries to catch their attention and asks for help, but when the figure turns and starts approaching, the player realizes it is not a person but a monster. The monster keeps approaching until a lightning bolt scares it away, making it run off.
![image8](readme%20images/image-8.png)

## Guard dog
![image9](readme%20images/image-9.png)
The player reaches the end of the path, arriving at a house surrounded by a fence and protected by a guard dog. They need to find a way to make the dog friendly before they can enter the enclosure. The player then finds a piece of meat on a nearby table and throws it to the dog. The dog will become friendly from then on, and the gate will be opened.

## House's courtyard
![image10](readme%20images/image-10.png)
![image11](readme%20images/image-11.png)
The player manages to enter the courtyard, but the house door does not open. They then proceed to explore the garden in search of a mechanism to unlock the door.

## The cans game
![image12](readme%20images/image-12.png)
The player finds a basket of metal balls on the right side of the courtyard, and cans stacked on top of crates. They throw a ball at the cans, knocking them down. The house door is then opened.

## The first room and the paintings puzzle
![image14](readme%20images/image-14.png)
![image13](readme%20images/image-13.png)
The player opens the door and enters the first room of the house, where they find the body of a person without skin. The next door is locked. The player must then solve the picture puzzle by hanging the pictures on the wall in the correct order, based on which part of the game depicted in the pictures preceded or followed the others in the game (the solution is the car in the first picture, followed by the fallen lamp, and then the house).

## The flamethrowers trap
![image15](readme%20images/image-15.png)
The player enters the last room of the house and starts the final mini-game by pressing the button on the wall. By pressing the 'play' button, the game will start. The player must survive 6 rounds by avoiding the flamethrowers, moving using raycast teleportation.
![image16](readme%20images/image-16.png)

## Final scene
![image17](readme%20images/image-17.png)
The final scene is simply a copy of the initial one, displaying the message "You won!" or "You lost!".