using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo.Wallets;
using System.Numerics;
using System.Windows.Forms;

namespace Neo.UI
{
    public partial class AssetCollectionPreviewDialog : Form
    {
        public AssetCollectionPreviewDialog(Dictionary<UInt160, BigInteger> accountRecords)
        {
            InitializeComponent();
            showResult(accountRecords);
        }

        public void showResult(Dictionary<UInt160, BigInteger> accountRecords)
        {
            foreach (var accountRecord in accountRecords)
            {
                richTextBox1.AppendText(accountRecord.Key.ToAddress() + " -> " + accountRecord.Value.ToString());
                richTextBox1.AppendText("\r\n");
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
