# EltelCandidateTest
Open Questions
(No code, written answers only)
Considering the coding task, how would you support the following requirements?
1. Display a line of movement for each moving entity, which shows the movement for 
the last n locations of the entity (user inputs value of n).
2. Support having three coordinates for each entity (i.e. (X, Y, Z) and how the display 
would reflect this.

Aswers
1. Considering we save the previos loction in the shapes class
then we only have to add a DrawLine func in the shapes draw func from the 
prev location point to the current.

2.For a 3d support we have to add the z variable to the shape object
and calculation for next steps will have to take in mind the double axis(2 angles),
shapes on the display will move in smaller steps if they have z grater then 0
