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
* * I guess I have to simulate a game starting at 0-0, and this score would change automatically over time (In a real world app this score would be returned from "data partners" I assume).

* 2. Finish Game.
* * I finish the match and store it temporally, including current score. I remove the oldest match from the scoreboard.

* 3. Update score.
* * Store the finished match into the scoreboard collection.

* 4. Get a summary of games by total score.
* * Display the scoreboard items ordered by bigger total score.



