using ContractorsCatalogue.App.Contractors;
using ContractorsCatalogue.Domain.Entities;
using System;
using System.Windows.Forms;

namespace ContractorsCatalogue.DesktopApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateForm(this);
            createForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(dgvContractors.SelectedRows.Count == 1)
            {
                var createForm = new CreateForm(this, (Contractor)dgvContractors.SelectedRows[0].DataBoundItem);
                createForm.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvContractors.SelectedRows.Count; i++)
            {
                var contractorsCRUD = new ContractorCRUD();
                var Contractors = contractorsCRUD.Delete((Contractor)dgvContractors.SelectedRows[i].DataBoundItem);
            }
            RefreshGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        public void RefreshGrid()
        {

            var contractorsCRUD = new ContractorCRUD();
            var Contractors = contractorsCRUD.GetAll();

            dgvContractors.DataSource = Contractors;
        }
    }
}
