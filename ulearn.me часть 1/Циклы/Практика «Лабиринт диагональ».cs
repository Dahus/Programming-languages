// Вставьте сюда финальное содержимое файла DiagonalMazeTask.cs


namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            if (height > width)
            {
                MoveX(robot, width, height);
            } else
            {
                MoveY(robot, width, height);
            }
		}

        public static void MoveX(Robot robot, int width, int height)
        {
            while (!robot.Finished)
            {
                for (int i = 0; i < (height - 3) / (width - 3 + 1); i++)
                {
                    robot.MoveTo(Direction.Down);
                }
                if (!robot.Finished)
                { 
                    robot.MoveTo(Direction.Right);
                }
            }
        }

        public static void MoveY(Robot robot, int width, int height)
        {
            while (!robot.Finished)
            {
                for (int i = 0; i < (width - 3) / (height - 3 + 1); i++)
                {
                    robot.MoveTo(Direction.Right);
                }
                if (!robot.Finished)
                {
                    robot.MoveTo(Direction.Down);
                }
            }
        }

    }
}