using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MultilayerTracing;

namespace MultilayerTracingUI
{
    public partial class MainForm : Form
    {
        private int rows;
        private int cols;
        private int fieldsCount = 0;
        private List<char[,]> tracingFields = new List<char[,]>();

        public MainForm()
        {
            InitializeComponent();

            InitElements();
        }

        private void MainForm_Resize(object sender, EventArgs e) => ChangeFieldsLocation();
        private void btnAddField_Click(object sender, EventArgs e) => AddField();
        private void btnRemoveField_Click(object sender, EventArgs e) => RemoveField();
        private void btnAddSource_Click(object sender, EventArgs e) => AddSourceCell();
        private void btnAddTarget_Click(object sender, EventArgs e) => AddTargetCell();
        private void btnAddLockCell_Click(object sender, EventArgs e) => AddLockCell();
        private void btnClearCell_Click(object sender, EventArgs e) => AddClearCell();
        private void btnShowPath_Click(object sender, EventArgs e) => ShowPath();

        private void InitElements()
        {
            btnRemoveField.Enabled = false;
        }

        private void ChangeFieldsLocation()
        {
            if (pFields.Controls.Count > 0)
            {
                if (pFields.Width > pFields.Controls[0].Width)
                {
                    int x = 0;
                    int y = 0;
                    foreach (Control control in pFields.Controls)
                    {
                        if (x > pFields.Width - control.Width)
                        {
                            y += control.Height;
                            x = 0;
                        }
                        control.Left = x;
                        control.Top = y;
                        x += control.Width;
                    }
                }
            }
        }

        private void AddSourceCell()
        {
            btnAddSource.Enabled = false;
            btnAddTarget.Enabled = true;
            btnAddLockCell.Enabled = true;
            btnClearCell.Enabled = true;
        }

        private void AddTargetCell()
        {
            btnAddSource.Enabled = true;
            btnAddTarget.Enabled = false;
            btnAddLockCell.Enabled = true;
            btnClearCell.Enabled = true;
        }

        private void AddLockCell()
        {
            btnAddSource.Enabled = true;
            btnAddTarget.Enabled = true;
            btnAddLockCell.Enabled = false;
            btnClearCell.Enabled = true;
        }

        private void AddClearCell()
        {
            btnAddSource.Enabled = true;
            btnAddTarget.Enabled = true;
            btnAddLockCell.Enabled = true;
            btnClearCell.Enabled = false;
        }

        private void AddField()
        {
            rows = (int)nudRows.Value;
            cols = (int)nudColumns.Value;
            nudRows.Enabled = false;
            nudColumns.Enabled = false;

            char[,] tracingField = new char[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    tracingField[i, j] = TracingProcessor.FreeCell;

            fieldsCount++;
            btnRemoveField.Enabled = true;

            string fieldName = string.Format("Поле {0}", fieldsCount);
            FieldControl field = new FieldControl(rows, cols, fieldName,
                btnAddSource, btnAddTarget, btnAddLockCell, btnClearCell, pFields, ref tracingField);
            pFields.Controls.Add(field);

            if (fieldsCount > 1)
            {
                FieldControl control = pFields.Controls.OfType<FieldControl>().First();
                if (control.Source != null)
                {
                    field.Source = new FieldCell(control.Source.X, control.Source.Y);
                    field.DrawSourceCell(control.Source.Y, control.Source.X);

                    tracingField[control.Source.Y, control.Source.X] = TracingProcessor.SourceCell;
                }
                if (control.Target != null)
                {
                    field.Target = new FieldCell(control.Target.X, control.Target.Y);
                    field.DrawTargetCell(control.Target.Y, control.Target.X);

                    tracingField[control.Target.Y, control.Target.X] = TracingProcessor.TargetCell;
                }
            }

            tracingFields.Add(tracingField);

            ChangeFieldsLocation();
        }

        private void RemoveField()
        {
            fieldsCount--;
            if (fieldsCount == 0)
            {
                btnRemoveField.Enabled = false;
                nudRows.Enabled = true;
                nudColumns.Enabled = true;
            }
            pFields.Controls.RemoveAt(fieldsCount);
            tracingFields.RemoveAt(fieldsCount);

            ChangeFieldsLocation();
        }

        private void ShowPath()
        {
            if (CheckCalculateData(out Cell sourceCell, out Cell targetCell))
            {
                List<PathCell> path = CalculatePath(sourceCell, targetCell);
                if (path != null)
                {
                    foreach (PathCell cell in path)
                    {
                        FieldControl field = pFields.Controls.OfType<FieldControl>().ToArray()[cell.FieldIndex];
                        field.DrawPathCell(cell.Cell.Y, cell.Cell.X);
                    }
                }
                else
                {
                    MessageBox.Show("Пути не существует.");
                }
            }
            else
            {
                MessageBox.Show("Данные не введены.");
            }
        }

        private List<PathCell> CalculatePath(Cell sourceCell, Cell targetCell)
        {
            List<PathCell> path = TracingProcessor.CalculatePath(tracingFields, sourceCell, targetCell);
            return path;
        }

        private bool CheckCalculateData(out Cell sourceCell, out Cell targetCell)
        {
            sourceCell = null;
            targetCell = null;

            if (fieldsCount != 0)
            {
                FieldControl fieldControl = pFields.Controls.OfType<FieldControl>().First();
                if (fieldControl.Source != null)
                {
                    sourceCell = new Cell(fieldControl.Source.Y, fieldControl.Source.X);
                    if (fieldControl.Target != null)
                    {
                        targetCell = new Cell(fieldControl.Target.Y, fieldControl.Target.X);
                        
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
