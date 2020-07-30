using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo.Properties;
using Neo.Model;
using Neo.Wallets;
using System.Collections.Specialized;
using Neo.SmartContract;
using Neo.VM;

namespace Neo.UI
{
    public partial class AssetCollectionDialog : Form
    {
        UInt160 assetHash = UInt160.Zero;
        UInt160 toAddress = UInt160.Zero;
        private TransactionSender transactionSender;
        public AssetCollectionDialog(StringCollection nep5List)
        {
            InitializeComponent();
            transactionSender = TransactionSender.GetInstance();
            foreach (var s in nep5List)
            {
                comboBoxAssetHash.Items.Add(s);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!transactionSender.isFinished)
            {
                TransactionNotCompletedError();
            }
            if (textBoxCollectTo.Text.Trim().Length != 34)
            {
                CollectToHashError();
                return;
            }
            else
            {
                toAddress = textBoxCollectTo.Text.Trim().ToScriptHash();
                transactionSender.assetsToSend.SetTargetAccountHash(toAddress);
            }
            if (!UInt160.TryParse(comboBoxAssetHash.Text, out assetHash))
            {
                AssetHashError();
                return;
            }
            transactionSender.GetTransaction(assetHash);
            if (transactionSender.StartToSend())
            {
                MessageBox.Show("Completed");
            }
            else 
            {
                MessageBox.Show("Break");
            }
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            if (comboBoxAssetHash.Text.Length != 42)
            {
                AssetHashError();
                return;
            }
            else if (!transactionSender.isFinished) 
            {
                TransactionNotCompletedError();
                return;
            }
            
            if (UInt160.TryParse(comboBoxAssetHash.Text, out assetHash))
            {
                this.CalculateAssetList();
                var result = transactionSender.assetsToSend.GetAssetList(assetHash);                
                AssetCollectionPreviewDialog previewDialog = new AssetCollectionPreviewDialog(result.accountRecords);
                previewDialog.ShowDialog();
            }
            else 
            {
                AssetHashError();
                return;
            }                
        }

        private void CalculateAssetList()
        {
            UInt160[] addresses = Program.CurrentWallet.GetAccounts().Select(p => p.ScriptHash).ToArray();
            foreach (string s in Settings.Default.NEP5Watched)
            {
                UInt160 script_hash = UInt160.Parse(s);
                byte[] script;
                using (ScriptBuilder sb = new ScriptBuilder())
                {
                    foreach (UInt160 address in addresses)
                        sb.EmitAppCall(script_hash, "balanceOf", address);
                    sb.Emit(OpCode.DEPTH, OpCode.PACK);
                    script = sb.ToArray();
                }
                using (ApplicationEngine engine = ApplicationEngine.Run(script, testMode: true))
                {
                    if (engine.State.HasFlag(VMState.FAULT)) continue;
                    var result = (Neo.VM.Types.Array)engine.ResultStack.Pop();
                    AssetCollectionList collection = new AssetCollectionList();
                    collection.AddAssetsList(script_hash, addresses, result);
                    transactionSender.SetAssetList(collection);
                }
            }
        }

        private void AssetHashError() 
        {
            MessageBox.Show("Asset Hash is not correct!");
        }

        private void CollectToHashError() 
        {
            MessageBox.Show("Collect To Address is not correct!");
        }

        private void TransactionNotCompletedError() 
        {
            MessageBox.Show("Transactions not completed.");
        }
    }
}
