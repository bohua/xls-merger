using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XlsMerger
{
	
	class Store : IEquatable<Store>
	{
		public string storeNumber { get; set; }
		public string filePath { get; set; }
		public string totalAmount { get; set; }
		public string face { get; set; }

		public Store(string number, string path, string amount)
		{
			this.storeNumber = number;
			this.filePath = path;
			this.totalAmount = amount;
		}

		public bool Equals(Store other)
		{
			if (this.storeNumber == other.storeNumber && this.filePath == other.filePath)
			{
				return true;
			}
			return false;
		}

        public bool hasFile(string filePath) {
            return this.filePath.Equals(filePath);
        }
	}

	class StoreBuilder
	{
		public string invoiceNumber { get; set; }
		public string filePath { get; set; }
		public string totalAmount { get; set; }

		public Store build()
		{
			if (this.totalAmount == null) {
				this.totalAmount = "0.00";
			}

			Store sto = new Store(this.invoiceNumber, this.filePath, this.totalAmount);
			sto.face = string.Format("单据号:{0}  金额:{1}", this.invoiceNumber, this.totalAmount);

			return sto;
		}
	}
}
