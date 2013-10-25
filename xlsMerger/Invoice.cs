using System;
using System.Collections.Generic;
using System.Text;

namespace XlsMerger
{
	class Invoice : IEquatable<Invoice>
	{
		public string invoiceNumber { get; set; }
		public string filePath { get; set; }
		public string totalAmount { get; set; }
		public string face { get; set; }

		public Invoice( string number, string path, string amount) {
			this.invoiceNumber = number;
			this.filePath = path;
			this.totalAmount = amount;
		}

		public bool Equals(Invoice other) {
			if (this.invoiceNumber == other.invoiceNumber && this.filePath == other.filePath) {
				return true;
			}
			return false;
		}
	}

	class InvoiceBuilder {
		public string invoiceNumber { get; set; }
		public string filePath { get; set; }
		public string totalAmount { get; set; }

		public Invoice build() {
			if (this.totalAmount == null) {
				this.totalAmount = "0.00";
			}

			Invoice inv = new Invoice(this.invoiceNumber, this.filePath, this.totalAmount);
			inv.face = string.Format("单据号:{0}  金额:{1}", this.invoiceNumber, this.totalAmount);

			return inv;
		}
	}
}
