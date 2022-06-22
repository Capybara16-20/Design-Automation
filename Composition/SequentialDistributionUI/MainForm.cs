using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SequentialDistribution;

namespace SequentialDistributionUI
{
    public partial class MainForm : Form
    {
        private CompositionProcessor processor;
        List<List<string>> steps;
        private const int minStep = 0;
        private int maxStep;
        private int currentStep;

        public MainForm()
        {
            InitializeComponent();
            InitComponents();
        }

        private void menuItemOpen_Click(object sender, EventArgs e) => ReadLists();
        private void menuItemCompose_Click(object sender, EventArgs e) => Compose();
        private void menuItemExit_Click(object sender, EventArgs e) => Exit();
        private void btnStepUp_Click(object sender, EventArgs e) => StepUp();
        private void btnStepBack_Click(object sender, EventArgs e) => StepBack();

        public void InitComponents()
        {
            menuItemCompose.Enabled = false;
            btnStepBack.Enabled = false;
            btnStepUp.Enabled = false;

        }

        private void ReadLists()
        {
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filePath = openFileDialog.FileName;
            try
            {
                processor = new CompositionProcessor(filePath);

                ShowElementsByChain();
                ShowChainsByElement();

                lbCalculation.Items.Clear();
                lbResult.Items.Clear();

                menuItemCompose.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowElementsByChain()
        {
            const string elementsByChainMessage = "Элементы, инцидентные цепям:";

            string[] elementsByChain = processor.GetElementsByChainStrings();
            lbElements.Items.Clear();
            lbElements.Items.Add(elementsByChainMessage);
            lbElements.Items.AddRange(elementsByChain);
        }

        private void ShowChainsByElement()
        {
            const string chainsByElementMessage = "Цепи, инцидентные элементам:";

            string[] chainsByElement = processor.GetChainsByElementStrings();
            lbChains.Items.Clear();
            lbChains.Items.Add(chainsByElementMessage);
            lbChains.Items.AddRange(chainsByElement);
        }

        private void Compose()
        {
            int elementsCount = (int)nudElementsCount.Value;
            int pinsCount = (int)nudPinsCount.Value;
            processor.Compose(elementsCount, pinsCount);

            steps = processor.Steps;
            currentStep = minStep;
            maxStep = steps.Count - 1;

            lbCalculation.Items.Clear();
            lbCalculation.Items.AddRange(steps[currentStep].ToArray());

            btnStepUp.Enabled = true;

            ShowComposedBlocks();
        }

        private void ShowComposedBlocks()
        {
            const string composedBlocksMessage = "Сформированные блоки:";

            string[] composedBlocks = processor.GetComposedBlocksStrings();
            lbResult.Items.Clear();
            lbResult.Items.Add(composedBlocksMessage);
            lbResult.Items.AddRange(composedBlocks);
        }

        private static void Exit()
        {
            Application.Exit();
        }

        private void StepBack()
        {
            currentStep--;

            lbCalculation.Items.Clear();
            lbCalculation.Items.AddRange(steps[currentStep].ToArray());

            btnStepUp.Enabled = true;
            if (currentStep == minStep)
                btnStepBack.Enabled = false;
        }

        private void StepUp()
        {
            currentStep++;

            lbCalculation.Items.Clear();
            lbCalculation.Items.AddRange(steps[currentStep].ToArray());

            btnStepBack.Enabled = true;
            if (currentStep == maxStep)
                btnStepUp.Enabled = false;
        }
    }
}
