namespace RobotSimulator
{
    public interface IRobot
    {
        void ProcessPlaceCommand(string command);
        void Move();
        void TurnLeft();
        void TurnRight();
        void Report();
    }
}
