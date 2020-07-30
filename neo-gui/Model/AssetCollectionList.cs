using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMArray = Neo.VM.Types.Array;

namespace Neo.Model
{
    public class AssetCollectionList
    {
        public UInt160 targetAccountHash = null;
        public List<AssetList> assetLists = new List<AssetList>();

        public bool AddAssetsList(UInt160 assetHash, UInt160[] account, VMArray amount)
        {
            if (account.Length != amount.Count()) return false;
            amount.Reverse();
            AssetList assetList = new AssetList(assetHash, account, amount);
            assetLists.Add(assetList);
            return true;
        }

        public bool AddAssetList(UInt160 assetHash, UInt160 account, BigInteger amount) 
        {
            var assetList = this.GetAssetList(assetHash);
            if (assetList == null)
            {
                assetList = new AssetList(assetHash, account, amount);
                assetLists.Add(assetList);
                return true;
            }
            else 
            {
                 return assetList.Add(account, amount);
            }
        }

        public AssetList GetAssetList(UInt160 assetHash)
        {
            foreach (var asset in assetLists)
            {
                if (asset.scriptHash == assetHash)
                {
                    return asset;
                }
            }
            return null;
        }

        public void SetTargetAccountHash(UInt160 accountHash)
        {
            targetAccountHash = accountHash;
        }

        public int AssetListCount()
        {
            return assetLists.Count();
        }
    }
}
