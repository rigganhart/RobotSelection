namespace RobotSelection.Models;

public class SelectedRobot : Robot
{
  public double distanceToGoal {get; set;}

  public SelectedRobot(Robot robot, double distanceToGoal)
  {
    this.distanceToGoal = distanceToGoal;
    this.batteryLevel = robot.batteryLevel;
    this.robotId = robot.robotId;
    this.x = robot.x;
    this.y = robot.y;
  }
}