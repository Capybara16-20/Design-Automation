using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SequentialLayout;

namespace SequentialLayoutUI
{
    public partial class Form : System.Windows.Forms.Form
    {
        private LayoutProcessor processor;
        private const int shift = 10;

        public Form()
        {
            InitializeComponent();

            menuItemArrange.Enabled = false;
        }

        private void menuItemLoadLists_Click(object sender, EventArgs e) => LoadLists();
        private void menuItemArrange_Click(object sender, EventArgs e) => ArrangeBlocks();
        private void Form_Resize(object sender, EventArgs e) => LocateCells();
        private void menuItemExit_Click(object sender, EventArgs e) => Exit();

        private void LocateCells()
        {
            if (pCells.Width > pCells.Controls[0].Width + shift * 2)
            {
                Point location = new Point(shift, shift);

                foreach (Control control in pCells.Controls)
                {
                    if (location.X > pCells.Width - (control.Width + shift))
                    {
                        location.Y += control.Height + shift;
                        location.X = shift;
                    }

                    control.Left = location.X;
                    control.Top = location.Y;
                    location.X += control.Width + shift;
                }
            }
        }

        private void LoadLists()
        {
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filePath = openFileDialog.FileName;
            try
            {
                processor = new LayoutProcessor(filePath);

                ShowCells();

                menuItemArrange.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowCells()
        {
            pCells.Controls.Clear();
            for (int i = 0; i < processor.ChainsByElements.Count; i++)
            {
                CellUserControl cell = new CellUserControl(i, processor.ChainsByElements[i]);
                pCells.Controls.Add(cell);
            }

            LocateCells();
        }

        private void ArrangeBlocks()
        {
            int maxElements = (int)nudElementsCount.Value;
            int maxPins = (int)nudPinsCount.Value;
            List<List<int>> blocks = processor.ArrangeBlocks(out List<List<string>> calculations, maxElements, maxPins);

            for (int i = 1; i < calculations.Count; i++)
            {
                CellUserControl cell = (CellUserControl)pCells.Controls[i];

                int block = blocks.Select((elements, index) => new { index, elements })
                    .Where(m => m.elements.Contains(i)).Select(m => m.index + 1).First();
                cell.AddCalculations(calculations[i], block);
            }
            LocateCells();
        }

        private static void Exit()
        {
            Application.Exit();
        }
    }
}
