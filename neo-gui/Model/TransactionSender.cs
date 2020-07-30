using System;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo.SmartContract;
using Neo.VM;
using Neo.Network.P2P.Payloads;
using Neo.UI.Wrappers;
using Neo.Network.P2P;
using Akka.Actor;

namespace Neo.Model
{
    public class TransactionSender
    {        
        private static readonly object padlock = new object();
        private static TransactionSender instance = null;
        private Dictionary<UInt160, InvocationTransaction> transactions;
        public bool isFinished = true;
        public AssetCollectionList assetsToSend = new AssetCollectionList();

        public static TransactionSender GetInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TransactionSender();
                    }
                }
            }
            return instance;
        }

        public bool SetAssetList(AssetCollectionList collection)
        {
            if (isFinished == true)
            {
                assetsToSend = collection;
                return true;
            }
            else 
            {
                return false;
            }
        }

        private TransactionSender() { }
        
        public bool StartToSend()
        {
            isFinished = false;
            foreach (var transaction in transactions)
            {
                if (!this.SendTransaction(transaction.Key, transaction.Value))
                {
                    return false;
                }
            }
            isFinished = true;
            return true;
        }

        public bool SendTransaction(UInt160 fromAddress, InvocationTransaction tx)
        {
            var sign = new TransactionAttributeWrapper
            {
                Usage = TransactionAttributeUsage.Script,
                Data = fromAddress.ToArray()
            };
            InvocationTransaction result = Program.CurrentWallet.MakeTransaction(new InvocationTransaction
            {
                Version = tx.Version,
                Script = tx.Script,
                Gas = tx.Gas,
                Attributes = new TransactionAttribute[] { sign.Unwrap() },
                Outputs = tx.Outputs
            }, change_address: UInt160.Zero, fee: Fixed8.Zero);
            Neo.UI.Helper.SignByAccount(result);
            return true;
        }

        public bool GetTransaction(UInt160 assetHash)
        {
            if (isFinished == false)            
            {
                return false;
            }
            AssetList assetList = assetsToSend.GetAssetList(assetHash);
            if (assetList == null)             
            {
                return false;
            }
            Dictionary<UInt160, InvocationTransaction> results = new Dictionary<UInt160, InvocationTransaction>();
            foreach (var record in assetList.accountRecords) 
            {
                if (record.Value == 0) continue;
                using (ScriptBuilder sb = new ScriptBuilder())
                {
                    sb.EmitAppCall(assetList.scriptHash, "transfer", record.Key, assetsToSend.targetAccountHash, record.Value);
                    var transaction = new InvocationTransaction
                    {
                        Version = 1,
                        Script = sb.ToArray(),
                        Attributes = new List<TransactionAttribute>().ToArray(),
                    };
                    results.Add(record.Key, transaction);
                }
            }
            transactions = results;
            return true;
        }
    }
}
