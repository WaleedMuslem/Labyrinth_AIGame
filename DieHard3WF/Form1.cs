using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AICore;

namespace DieHard3WF
{
    public partial class Form1 : Form
    {
        Graphics g;
        int spaceHorisontal = 50;
        int spaceVertical = 50;
        int canWidth;
        int canHeight;
        int index = 0;

        Brush brushWater = new SolidBrush(Color.LightBlue);
        Pen penCan = new Pen(Color.Black, 3);
        BacktrackLabyrinthBall backtrack = new BacktrackLabyrinthBall(100, true);
        LabyrinthBallNode terminalNode;
        List<LabyrinthBallNode> solution;
        public Form1()
        {
            InitializeComponent();
            canWidth = (canvas.Width - 3 * spaceHorisontal) / 2;
            canHeight = canvas.Height - 2 * spaceVertical;
            terminalNode = backtrack.Search();
            solution = backtrack.GetSolution(terminalNode).ToList();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                canvas.Invalidate();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (index < solution.Count - 1)
            {
                index++;
                canvas.Invalidate();
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            PrintState(solution[index].State);
        }

        private void PrintState(LabyrinthBallState state)
        {
            #region Water
            if (state.Can5 > 0)
                g.FillRectangle(brushWater, spaceHorisontal, spaceVertical + (5 - state.Can5) * (canHeight / 5), canWidth, canHeight - (5 - state.Can5) * (canHeight / 5));
            if (state.Can3 > 0)
                g.FillRectangle(brushWater, 2 * spaceHorisontal + canWidth, spaceVertical + (5 - state.Can3) * (canHeight / 5), canWidth, canHeight - (5 - state.Can3) * (canHeight / 5));
            #endregion

            #region Cans
            g.DrawLine(penCan, spaceHorisontal, spaceVertical, spaceHorisontal, spaceVertical + canHeight);
            g.DrawLine(penCan, spaceHorisontal, spaceVertical + canHeight, spaceHorisontal + canWidth, spaceVertical + canHeight);
            g.DrawLine(penCan, spaceHorisontal + canWidth, spaceVertical, spaceHorisontal + canWidth, spaceVertical + canHeight);

            g.DrawLine(penCan, 2 * spaceHorisontal + canWidth, spaceVertical, 2 * spaceHorisontal + canWidth, spaceVertical + canHeight);
            g.DrawLine(penCan, 2 * spaceHorisontal + canWidth, spaceVertical + canHeight, 2 * spaceHorisontal + 2 * canWidth, spaceVertical + canHeight);
            g.DrawLine(penCan, 2 * spaceHorisontal + 2 * canWidth, spaceVertical, 2 * spaceHorisontal + 2 * canWidth, spaceVertical + canHeight);
            #endregion
        }
    }
}
