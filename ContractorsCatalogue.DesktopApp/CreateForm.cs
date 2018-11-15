using ContractorsCatalogue.App.Contractors;
using ContractorsCatalogue.Domain.Entities;
using System;
using System.Windows.Forms;

namespace ContractorsCatalogue.DesktopApp
{
    public partial class CreateForm : Form
    {
        public enum Mode
        {
            Create,
            Update,
        }

        private MainForm _form;
        private Mode _mode;
        private Contractor newContractor;

        public CreateForm(MainForm form)
        {
            _form = form;
            _mode = Mode.Create;

            InitializeComponent();

            btnCreate.Text = "Create";

            newContractor = new Contractor();
        }

        public CreateForm(MainForm form, Contractor contractor)
        {
            _form = form;
            _mode = Mode.Update;
                                 
            InitializeComponent();

            tbxFirstName.Text = contractor.FirstName;
            tbxLastName.Text = contractor.LastName;
            tbxNIP.Text = contractor.NIP;
            btnCreate.Text = "Update";

            newContractor = new Contractor() { Id = contractor.Id };
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            newContractor.FirstName = tbxFirstName.Text;
            newContractor.LastName = tbxLastName.Text;
            newContractor.NIP = tbxNIP.Text;

            var contractorCrud = new ContractorCRUD();

            bool result = _mode == Mode.Create 
                ? contractorCrud.Create(newContractor) 
                : contractorCrud.Update(newContractor);

            if (result)
            {
                this.Close();
                _form.RefreshGrid();
            }
            else
            {
                //Communicate about failure
            }
        }
    }
}
