# ScoreBoardGame

Football World Cup Score Board


## Project Structure

* ScoreBoardLib

* * The implementation of the story board (Class Library). This contains all the logic for the Score Board.

* ScoreBoardGame

* * This contains the executable that runs the game. It's a Console Application with a simple menu UI.

* ScoreBoardTest

* * A test project containing the tests used to develop the application using TDD.



## Assumptions made from reading intructions

Game has 4 options.

* 1. Start a game.
* * I guess I have to simulate a game starting at 0-0, and this score would change automatically over time (In a real world app this score would be returned by "data partners" I assume).

* 2. Finish Game.
* * I finish the match and store it temporally, including current score. I remove the oldest match from the scoreboard.

* 3. Update score.
* * Store the finished match into the scoreboard collection.

* 4. Get a summary of games by total score.
* * Display the scoreboard collection items ordered by bigger total score.


### Thoughts:

Step 2 finish game and removes the oldest match from scoreboard, and step 3 registers the new one. I don't think that makes sense. I think that is better to remove the oldest match in step 3, just before the new one gets registered, otherwise, we might run into bugs, for example, if you run step 2 and then step 4, the played match will be not registered, but you will lose the oldest one too. If you do this several times you could even clear the scoreboard collection.

I will move the removal of oldest match to step 3, right before insertion of the new one.


Also, removal of oldest match needs to be conditional, because if we start from an empty leaderboard it will store only the latest match, because we remove one each time a one new is inserted.
To fix this, I will add a MaxMatches property to the scoreboard, so oldest match only gets deleted if scoreboard item count exceeds this ammount.


Options 1 and 2, that can be called in any order, makes possible starting several games whitout finishing previous ones. To keep it simple, I will limit the game to have only 1 game started at a time. To start a new one you have to finish the previous one.

There is also the possibility to start and finish several matches and then run step 3, to keep things simple I will limit that too to just one match.
