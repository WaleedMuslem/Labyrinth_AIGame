using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class LabyrinthBallState : AbstractState, IOperatorHandler<Direction>
    {
        static public char[,] labyrinth = new char[,]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', ' ', ' ', '#', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', '#', ' ', '#', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', '#', 'G', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', ' ', ' ', '#', '#', '#', ' ', '#', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        public LabyrinthBallState()
        {
            this.row = 3;
            this.col = 9;
        }

        //private int row, col;
        private int row;
        private int col;

       

        public int Row { get { return row; } }
        public int Col { get { return col; } }

        public override bool IsState()
        {

            // Check if the row and column indices are within the bounds of the labyrinth
            if (this.row < 0 || this.row >= labyrinth.GetLength(0) || this.col < 0 || this.col >= labyrinth.GetLength(1))
                return false;

            // Check if the cell is a wall
            //if (labyrinth[this.row, this.col] == '#')
            //    return false;

            return true; // The state is valid
        }

        public override bool IsGoalState()
        {
            // Check if the cell at the given indices contains the goal marker ('G')
            if (labyrinth[this.row, this.col] == 'G')
                return true;

            return false; // The state is not the goal state
        }

        public bool IsOperator(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (labyrinth[this.row - 1,this.col] == '#')
                    {
                        return false;
                    }
                    break;
                case Direction.Down:
                    if (labyrinth[this.row + 1, this.col] == '#')
                    {
                        return false;
                    }
                    break;
                case Direction.Left:
                    if (labyrinth[this.row , this.col - 1] == '#')
                    {
                        return false;
                    }
                    break;
                case Direction.Right:
                    if (labyrinth[this.row , this.col + 1] == '#')
                    {
                        return false;
                    }
                    break;

            }
            return true;
        }



        public bool ApplyOperator(Direction directiont)
        {
            if (!IsOperator(directiont))
                return false;

            int newRow = this.row;
            int newCol = this.col;

            switch (directiont)
            {
                case Direction.Up:
                    while (labyrinth[this.row, this.col] != '#')
                    {
                        this.row--;
                    }
                    this.row++;
                    break;
                case Direction.Down:
                    while (labyrinth[this.row, this.col] != '#')
                    {
                        this.row++;
                    }
                    this.row--;
                    break;
                case Direction.Left:
                    while (labyrinth[this.row, this.col] != '#')
                    {
                        this.col--;
                    }
                    this.col++;
                    break;
                case Direction.Right:
                    while (labyrinth[this.row, this.col] != '#')
                    {
                        this.col++;
                    }
                    this.col--;
                    break;
            }

            // Check if the new position is a valid move (not a wall)
            if (IsState())
            {
                return true; // The operator was successfully applied
            }

            return false;
        }



        public override string ToString()
        {
            return String.Format("row : {0} , col : {1}", row, col);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is LabyrinthBallState)) return false;
            LabyrinthBallState other = (LabyrinthBallState)obj;
            return this.row == other.row && this.col == other.col;
        }


    }
}
