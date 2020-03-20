using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace IA_project
{
    public partial class mainWindow : Form
    {
        //private Form activeForm = null;
        public Dictionary<int, Terrain> terrainsDictionary = null;

        public mainWindow()
        {
            InitializeComponent();
        }

        #region Functionality_design
        /*
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childFormPanel.Controls.Add(childForm);
            Width = menuPanel.Width + childForm.Width;
            Height = childForm.Height;
            AddOwnedForm(childForm);
            childForm.ShowDialog();
        }
        */
        #endregion

        #region Events
        private void configMapBtn_Click(object sender, EventArgs e)
        {
            Map configMapWindow = new Map();
            AddOwnedForm(configMapWindow);
            configMapWindow.ShowDialog();
        }

        private void mainBtn_Click(object sender, EventArgs e)
        {

        }

        private void configPlayerBtn_Click(object sender, EventArgs e)
        {
            if(terrainsDictionary == null)
            {
                MessageBox.Show(this, "Primero configure los terrenos", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach(var item in terrainsDictionary)
                {
                    Debug.WriteLine(item.Key + ":" + item.Value.Name);
                }
                Character confiCharacterWindow = new Character(terrainsDictionary);
                AddOwnedForm(confiCharacterWindow);
                confiCharacterWindow.ShowDialog();
            }
        }
        #endregion
    }
}
