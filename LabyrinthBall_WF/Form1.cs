using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AICore;

namespace LabyrinthBall_WF
{
    public partial class Form1 : Form
    {
        int index = 0;
        private const int CellSize = 28;
        Graphics g;
        LabyrinthBallNode terminalNode;
        List<LabyrinthBallNode> solution;
        GraphSearchLabyrinthBall searchingAlgorithm;
        BacktrackLabyrinthBall backtrack = new BacktrackLabyrinthBall(19, true);


        public Form1()
        {
            InitializeComponent();
            index = 0;
            //terminalNode = backtrack.Search();
            //solution = backtrack.GetSolution(terminalNode).ToList();
        }


        private void PrintState(LabyrinthBallState state)
        {
            int numCols = LabyrinthBallState.labyrinth.GetLength(0);
            int numRows = LabyrinthBallState.labyrinth.GetLength(1);

            for (int x = 0; x < numRows; x++)
            {
                for (int y = 0; y < numCols; y++)
                {
                    Rectangle cellRect = new Rectangle(y * CellSize, x * CellSize, CellSize, CellSize);

                    // Draw the ball
                    if (state.Row == x && state.Col == y)
                        g.FillEllipse(Brushes.Blue, cellRect);

                    else if (LabyrinthBallState.labyrinth[x, y] == '#')
                    {
                        g.FillEllipse(Brushes.Black, cellRect);
                    }
                    else if(LabyrinthBallState.labyrinth[x, y] == 'G')
                    {
                        g.FillEllipse(Brushes.Green, cellRect);
                    }
                    else
                    {
                        g.FillEllipse(Brushes.White, cellRect);
                    }
                }
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            if (solution != null)
            {
                if (index > 0)
                {
                    index--;
                    canvas.Invalidate();

                }
            }
        }

        private void btnForward_Click_1(object sender, EventArgs e)
        {
            if (solution != null)
            {
                if (index < solution.Count - 1)
                {
                    index++;
                    canvas.Invalidate();
                }
            }
            
        }

        private void canvas_Paint_1(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (terminalNode != null)
            {
                PrintState(solution[index].State);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: this.GetTrialAndErrorSolution(); break;
                case 1: this.GetBacktrackSolution(); break;
                case 2: this.GetDepthFirstSolution(); break;
                case 3: this.GetBreadthFirstSolution(); break;
            }
        }

        private void ResetSolution()
        {
            this.index = 0;
            this.terminalNode = this.searchingAlgorithm.Search();
            this.solution = this.searchingAlgorithm.GetSolution(terminalNode).ToList();
            canvas.Invalidate();
        }

        private void GetTrialAndErrorSolution()
        {
            this.searchingAlgorithm = new TrialAndErrorLabyrinthBall();
            this.ResetSolution();
        }

        private void GetBacktrackSolution()
        {
            this.searchingAlgorithm = new BacktrackLabyrinthBall(100,true);
            this.ResetSolution();
        }

        private void GetDepthFirstSolution()
        {
            this.searchingAlgorithm = new DepthFirstLabyrinthBall(true);
            this.ResetSolution();
        }

        private void GetBreadthFirstSolution()
        {
            this.searchingAlgorithm = new BreadthFirstLabyrinthBall(true);
            this.ResetSolution();
        }
    }  
}
