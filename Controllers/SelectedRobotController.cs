using RobotSelection.Models;
using RobotSelection.Services;
using Microsoft.AspNetCore.Mvc;

namespace RobotSelection.Controllers;

[ApiController]
[Route("[controller]")]
public class SelectRobotController: ControllerBase
{
  public SelectRobotController()
  {
  }

  [HttpPost]
  public async Task <IActionResult> Create(Load load){
    List<Robot> robots = await RobotService.GetAll();
    List<SelectedRobot> selectedRobots = new List<SelectedRobot>();
   
    foreach (Robot robot in robots)
    {
      int xDiff = (Math.Max(robot.x,load.x) - Math.Min(robot.x, load.x));

      double xSquared = Math.Pow(xDiff,2);

      int yDiff = Math.Max(robot.y, load.y) - Math.Min(robot.y, load.y);

      double ySquared = Math.Pow(yDiff,2);
      

      double distance = Math.Sqrt((xSquared + ySquared));
    
      selectedRobots.Add(new SelectedRobot(robot, distance));
    }

    selectedRobots.Sort((x,y) => x.distanceToGoal.CompareTo(y.distanceToGoal));

    SelectedRobot closestRobot = selectedRobots[0];
    return CreatedAtAction(nameof(Create), new { id = closestRobot.robotId}, closestRobot );
  }
}