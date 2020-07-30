using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMArray = Neo.VM.Types.Array;

namespace Neo.Model
{
    public class AssetList
    {
        public UInt160 scriptHash;
        public Dictionary<UInt160, BigInteger> accountRecords;

        public AssetList(UInt160 assetHash, UInt160 account, BigInteger amount)
        {
            scriptHash = assetHash;
            accountRecords = new Dictionary<UInt160, BigInteger>();
            accountRecords.Add(account, amount);
        }

        public AssetList(UInt160 assetHash, UInt160[] accounts, VMArray amounts)
        {
            scriptHash = assetHash;
            accountRecords = new Dictionary<UInt160, BigInteger>();
            try
            {
                for (int i = 0; i < accounts.Length && i < amounts.Count(); i++)
                {
                    accountRecords.Add(accounts[i], amounts[i].GetBigInteger());
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Add(UInt160 account, BigInteger amount)
        {
            if (accountRecords.ContainsKey(account))
            {
                return false;
            }
            else 
            {
                accountRecords.Add(account, amount);
            }
            return true;
        }
    }
}
